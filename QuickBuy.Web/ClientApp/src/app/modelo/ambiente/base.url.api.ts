import { Inject, Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})

export class BaseUrlApi {
  public readonly usuario = "http://192.168.0.84:5010/"
  public readonly produto = "http://192.168.0.84:5010/"
  public readonly pedido =  "http://192.168.0.84:5010/"
  
}
