using System;
using System.Collections.Generic;
using System.Linq;
using QuickBuy.Dominio.OBjetoDeValor;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public ICollection <ItemPedido> ItensPedidos { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }
        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();
           if (!ItensPedidos.Any())
               mensagemValidacao.Add("Erro : Pedido nao pode ficar sem item de pedido");

           if(string.IsNullOrEmpty(CEP))


        }
    }
}