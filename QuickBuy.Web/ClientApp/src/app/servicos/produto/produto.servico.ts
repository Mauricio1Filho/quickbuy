import { Inject, Injectable, OnInit, } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Produto } from "../../modelo/produto/produto";

import { environment } from "../../../environments/environment";


@Injectable({
  providedIn: "root"
})

export class ProdutoServico implements OnInit {  
  public produtos: Produto[];

  constructor(private http: HttpClient) {
    
  }

  ngOnInit(): void {
    this.produtos = [];
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  public cadastrar(produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(environment.urlAPI.produto + "api/produto", produto, { headers: this.headers });
  }

  public salvar(produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(environment.urlAPI.produto + "api/produto/salvar", produto, { headers: this.headers });
  }

  public deletar(produto: Produto): Observable<Produto[]> {
    return this.http.post<Produto[]>(environment.urlAPI.produto + "api/produto/deletar", produto, { headers: this.headers });
  }

  public obterTodosProdutos(): Observable<Produto[]> {    
    return this.http.get<Produto[]>(environment.urlAPI.produto + "api/produto");
  }

  public obterProduto(produtoId: number): Observable<Produto> {   
    return this.http.get<Produto>(environment.urlAPI.produto + "api/produto");
  }

  enviarArquivo(arquivoSelecionado: File): Observable<string> {
    const formData: FormData = new FormData();
    formData.append("arquivoEnviado", arquivoSelecionado, arquivoSelecionado.name)
    return this.http.post<string>("http://192.168.0.84:5004/" + "api/produto/enviarArquivo", formData);
  }
}
