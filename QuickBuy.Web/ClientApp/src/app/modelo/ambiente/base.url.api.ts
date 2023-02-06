import { Inject, Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})

export class BaseUrlApi {
  public readonly usuario = "http://localhost:4050/"
  public readonly produto = "http://localhost:4050/"
  public readonly pedido =  "http://localhost:4050/"
}
