import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { Produto } from '../../modelo/produto/produto';
import { ProdutoServico } from '../../servicos/produto/produto.servico';
import { LojaCarrinho } from '../carrinho/loja.carrinho';
 

@Component({
  selector: "loja-app-produto",
  templateUrl: "./loja.produto.component.html",
  styleUrls: ["./loja.produto.component.css"]
})

export class LojaProdutoComponent implements OnInit {
  public produto: Produto;
  public carrinhoCompras: LojaCarrinho;

  ngOnInit(): void {
    this.carrinhoCompras = new LojaCarrinho();
    var produtoDetalhe = sessionStorage.getItem('produtoDetalhe');
    if (produtoDetalhe) {
      this.produto = JSON.parse(produtoDetalhe);
    }
  }

  constructor(private produtoServico: ProdutoServico, private router: Router) {

  }

  public comprar() {
    this.carrinhoCompras.adicionar(this.produto);
    this.router.navigate(["/loja-efetivar"]);
  }
  //get urlServerImage() {
  //  return environment.urlServerImages;
  //}
}
