using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using QuickBuy.Repositorio.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Repositorio.Repositorios
{
    public class PedidoRepositorio : BaseRepositorio<Pedido>, IPedidoRepositorio
    {

        private readonly QuickBuyContexto _quickBuyContexto;


        public PedidoRepositorio(QuickBuyContexto quickBuyContexto) : base(quickBuyContexto)
        {
            _quickBuyContexto = quickBuyContexto;
        }

        public IEnumerable<Pedido> ObterPorIdUsuario(int idUsuario)
        {
            return _quickBuyContexto.Pedidos.Where(o => o.UsuarioId == idUsuario).ToList();
        }
    }
}