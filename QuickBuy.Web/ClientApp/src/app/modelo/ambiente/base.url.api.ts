import { Inject, Injectable } from "@angular/core";



@Injectable({
  providedIn: "root"
})

export class BaseUrlApi {
  public readonly usuario = "http://localhost:5005/"
  public readonly produto = "http://localhost:5005/"
  
}
