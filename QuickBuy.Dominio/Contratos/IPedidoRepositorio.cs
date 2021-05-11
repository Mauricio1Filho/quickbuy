using QuickBuy.Dominio.Entidades;
using System.Collections.Generic;

namespace QuickBuy.Dominio.Contratos
{
    public interface IPedidoRepositorio : IBaseRepositorio <Pedido>
    {
       IEnumerable<Pedido> ObterPorIdUsuario(int idUsuario);
        
    }
}