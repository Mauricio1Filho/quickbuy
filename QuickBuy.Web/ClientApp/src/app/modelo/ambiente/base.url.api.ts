import { Inject, Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})

export class BaseUrlApi {
  public readonly usuario = "http://app.quickbuy.net.br:4050/"
  public readonly produto = "http://app.quickbuy.net.br:4050/"
  public readonly pedido =  "http://app.quickbuy.net.br:4050/"
}
