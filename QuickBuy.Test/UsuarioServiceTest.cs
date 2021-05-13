using Moq;
using QuickBuy.Dominio;
using QuickBuy.Dominio.Entidades;
using QuickBuy.Dominio.Interfaces;
using System;
using Xunit;

namespace QuickBuy.Test
{
    public class UsuarioServiceTest
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioServiceTest()
        {
            _usuarioService = new UsuarioService();
        }

        [Theory]
        [InlineData(123)]     
        public void Must_Return_Usuario(int idUsuario)
        {
            var result = _usuarioService.GetUsuario(idUsuario);
            Assert.True(result != null && result.Id.Equals(idUsuario));
        }

        [Theory]
        [InlineData("CPF", "5000010014441")]      
        public void Must_Cadastra_Usuario(string  type, string doc)
        {
            Assert.True(type.Equals("CPF")  && doc.Length == 11); 
            
            
        }
    }
}
