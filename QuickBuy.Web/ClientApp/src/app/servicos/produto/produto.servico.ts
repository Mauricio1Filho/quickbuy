import { Inject, Injectable, OnInit, } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Produto } from "../../modelo/produto/produto";
import { BaseUrlApi } from "../../modelo/ambiente/base.url.api";

@Injectable({
  providedIn: "root"
})

export class ProdutoServico implements OnInit {

  private _baseUrlApi: BaseUrlApi;
  public produtos: Produto[];

  constructor(private http: HttpClient, baseUrlApi: BaseUrlApi) {
    this._baseUrlApi = baseUrlApi;
  }

  ngOnInit(): void {
    this.produtos = [];
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  public cadastrar(produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(this._baseUrlApi.produto + "api/produto", JSON.stringify(produto), { headers: this.headers });
  }

  public salvar(produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(this._baseUrlApi.produto + "api/produto/salvar", JSON.stringify(produto), { headers: this.headers });
  }

  public deletar(produto: Produto): Observable<Produto[]> {
    return this.http.post<Produto[]>(this._baseUrlApi.produto + "api/produto/deletar", JSON.stringify(produto), { headers: this.headers });
  }

  public obterTodosProdutos(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this._baseUrlApi.produto + "api/produto");
  }

  public obterProduto(produtoId: number): Observable<Produto> {
    return this.http.get<Produto>(this._baseUrlApi.produto + "api/produto");
  }

  enviarArquivo(arquivoSelecionado: File): Observable<string> {
    const formData: FormData = new FormData();
    formData.append("arquivoEnviado", arquivoSelecionado, arquivoSelecionado.name)
    return this.http.post<string>(this._baseUrlApi.produto + "api/produto/enviarArquivo", formData);
  }
}
