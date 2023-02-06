using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private IHttpContextAccessor _httpContextAccessor;
        private IWebHostEnvironment _hostingEvironment;
        public ProdutoController(IProdutoRepositorio produtoRepositorio,
                                    IHttpContextAccessor httpContextAccessor, IWebHostEnvironment hostingEnvironment)
        {
            _produtoRepositorio = produtoRepositorio;
            _httpContextAccessor = httpContextAccessor;
            _hostingEvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_produtoRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            try
            {
                produto.Validate();
                if (!produto.EhValido)
                {
                    return BadRequest(produto.ObterMensagensValidacao());
                }
                if (produto.Id > 0)
                {
                    _produtoRepositorio.Atualizar(produto);
                }
                else
                {
                    _produtoRepositorio.Adicionar(produto);
                }
                return Created("api/produto", produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody] Produto produto)
        {
            try
            {
                _produtoRepositorio.Remover(produto);
                return Json(_produtoRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("EnviarArquivo")]
        public IActionResult EnviarArquivo()
        {
            try
            {
                var caminho = createFile(_httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"]);
                //UploadFtpFile(caminho);
                return Json(Path.GetFileName(caminho));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        private static string GerarNovoNomeArquivo(string nomeArquivo, string extensao)
        {
            var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();
            var novoNomeArquivo = new string(arrayNomeCompacto).Replace(" ", "-");
            novoNomeArquivo = $"{novoNomeArquivo}_{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}{DateTime.Now.Hour}{DateTime.Now.Minute}.{extensao}";
            return novoNomeArquivo;
        }

        public string createFile(IFormFile formFile)
        {
            var nomeArquivo = formFile.FileName;
            var extensao = nomeArquivo.Split(".").Last();
            string novoNomeArquivo = GerarNovoNomeArquivo(nomeArquivo, extensao);
            var pastaArquivos = _hostingEvironment.WebRootPath + "\\arquivos\\";
            var nomeCompletoArquivo = pastaArquivos + novoNomeArquivo;

            using (var streamArquivo = new FileStream(nomeCompletoArquivo, FileMode.Create))
            {
                formFile.CopyTo(streamArquivo);
            }

            return nomeCompletoArquivo;
        }
        public void UploadFtpFile(string caminho)
        {
            FtpWebRequest request;
            string absoluteFileName = Path.GetFileName(caminho);
            var serverPath = string.Format(@"ftp://{0}/{1}", "192.168.0.83", absoluteFileName);
            request = WebRequest.Create(new Uri(serverPath)) as FtpWebRequest;
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.UseBinary = true;
            request.UsePassive = true;
            request.KeepAlive = true;
            request.Credentials = new NetworkCredential("anonymous", "quickbuy@quickbuy.com");
            request.ConnectionGroupName = "group";

            using (FileStream fs = new FileStream(caminho, FileMode.Open))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(buffer, 0, buffer.Length);
                requestStream.Flush();
                requestStream.Close();
                FileInfo fInfo = new FileInfo(caminho);
                fInfo.Delete();

            }




        }
    }
}
