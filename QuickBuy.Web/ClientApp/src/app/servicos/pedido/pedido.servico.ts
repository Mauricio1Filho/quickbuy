import { Injectable, Inject } from "@angular/core";
import { BaseUrlApi } from "../../modelo/ambiente/base.url.api";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Pedido } from "../../modelo/pedido/pedido";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class PedidoServico {

  public _baseUrlApi: BaseUrlApi;

  constructor(private http: HttpClient, baseUrlApi: BaseUrlApi) {
    this._baseUrlApi = baseUrlApi;
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  public efetivarCompra(pedido: Pedido): Observable<number> {
    return this.http.post<number>(environment.urlAPI.pedido + "api/pedido", JSON.stringify(pedido), { headers: this.headers });
  }

}
