import { Inject, Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Usuario } from "../../modelo/usuario/usuario";
import { BaseUrlApi } from "../../modelo/ambiente/base.url.api";

@Injectable({
  providedIn: "root"
})
export class UsuarioServico {

  private baseUrlApi: BaseUrlApi

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, baseUrlApi: BaseUrlApi) {
    this.baseUrl = baseUrl;
    this.baseUrlApi = baseUrlApi;
  }

  private baseUrl: string;
  private _usuario: Usuario;

  set usuario(usuario: Usuario) {
    sessionStorage.setItem("usuario-autenticado", JSON.stringify(usuario));
    this._usuario = usuario;
  }

  get usuario(): Usuario {
    let usuario_json = sessionStorage.getItem("usuario-autenticado");
    this._usuario = JSON.parse(usuario_json);
    return this._usuario;
  }

  public usuario_autenticado(): boolean {
    return this._usuario != null && this._usuario.email != "" && this._usuario.senha != "";
  }

  public limpar_sessao() {
    sessionStorage.setItem("usuario-autenticado", null);
    this._usuario = null;
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  public verificarUsuario(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(this.baseUrlApi.usuario + "api/usuario/verificarUsuario", usuario, { headers: this.headers });
  }

  public cadastrarUsuario(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(this.baseUrlApi.usuario + "api/usuario", usuario, { headers: this.headers });
  }
}
