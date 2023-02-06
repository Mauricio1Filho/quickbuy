import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { ItemPedido, } from '../../modelo/item-pedido/itemPedido';
import { Pedido } from '../../modelo/pedido/pedido';
import { Produto } from '../../modelo/produto/produto';
import { PedidoServico } from '../../servicos/pedido/pedido.servico';
import { UsuarioServico } from '../../servicos/usuario/usuario.servico';
import { LojaCarrinho } from '../carrinho/loja.carrinho';

@Component({
  selector: "loja-efetivar",
  templateUrl: "./loja.efetivar.component.html",
  styleUrls: ["./loja.efetivar.component.css"]
})

export class LojaEfetivarComponent implements OnInit {
  public carrinhoCompras: LojaCarrinho;
  public produtos: Produto[];
  public total: number

  ngOnInit(): void {
    this.carrinhoCompras = new LojaCarrinho();
    this.produtos = this.carrinhoCompras.obterProdutos();
    this.atualizarTotal();
  }

  constructor(private usuarioServico: UsuarioServico, private pedidoServico: PedidoServico, private router: Router) {

  }

  public atualizarPreco(produto: Produto, quantidade: number) {

    if (!produto.precoOriginal) {
      produto.precoOriginal = produto.preco;
    }
    if (quantidade <= 0) {
      quantidade = 1;
      produto.quantidade = quantidade;
    }
    produto.preco = produto.precoOriginal * quantidade;
    this.carrinhoCompras.atualizar(this.produtos);
    this.atualizarTotal();
  }
  public remover(produto: Produto) {
    this.carrinhoCompras.removerProduto(produto);
    this.produtos = this.carrinhoCompras.obterProdutos();
    this.atualizarTotal();
  }
  public atualizarTotal() {
    console.log("obj :",this.produtos);
    this.total = this.produtos.reduce((acc, produto) => acc + produto.preco, 0);
    
  }

  public finalizarCompra() {
    this.pedidoServico.efetivarCompra(this.criarPedido())
      .subscribe(
        pedidoId => {
          sessionStorage.setItem("pedidoId", pedidoId.toString());
          this.produtos = [];
          this.carrinhoCompras.limparCarrinhoCompras();
          this.router.navigate(["/compra-sucesso"])
        },
        e => {

        }
      );
  }

  public criarPedido(): Pedido {
    let pedido = new Pedido();
    pedido.usuarioId = this.usuarioServico.usuario.id;
    pedido.cep = "06310310";
    pedido.cidade = "Carapicuiba";
    pedido.estado = "Sao Paulo";
    pedido.dataPrevisaoEntrega = new Date();
    pedido.formaPagamentoId = 1;
    pedido.numeroEndereco = 319;
    pedido.enderecoCompleto = "meu piru de roda";
    

    this.produtos = this.carrinhoCompras.obterProdutos();

    for (let produto of this.produtos) {
      let itemPedido = new ItemPedido();
      itemPedido.produtoId = produto.id;

      if (!produto.quantidade)
        produto.quantidade = 1;
      itemPedido.quantidade = produto.quantidade;

      pedido.itensPedido.push(itemPedido);
    }
    return pedido;
  }

  //get urlServerImage() {
  //  return environment.urlServerImages;
  //}
}
