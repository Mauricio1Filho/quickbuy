import { Produto } from "../../modelo/produto/produto";

export class LojaCarrinho {

  public produtos: Produto[] = [];

  public adicionar(produto: Produto) {
    var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
    if (!produtoLocalStorage) {
      this.produtos.push(produto);
      localStorage.setItem("produtoLocalStorage", JSON.stringify(this.produtos));
    }
    else {
      this.produtos = JSON.parse(produtoLocalStorage);
      this.produtos.push(produto);
      localStorage.setItem("produtoLocalStorage", JSON.stringify(this.produtos));
    }
  }

  public obterProdutos(): Produto[] {
    var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
    if (produtoLocalStorage)
      return JSON.parse(produtoLocalStorage);
  }

  public removerProduto(produto: Produto) {
    var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
    if (produtoLocalStorage) {
      this.produtos = JSON.parse(produtoLocalStorage);
      this.produtos = this.produtos.filter(p => p.id != produto.id);
      localStorage.setItem("produtoLocalStorage", JSON.stringify(this.produtos));
    }
  }

  public atualizar(produtos: Produto[]) {
    localStorage.setItem("produtoLocalStorage", JSON.stringify(produtos));
  }

  public limparCarrinhoCompras() {
    localStorage.setItem("produtoLocalStorage", "");
  }
}