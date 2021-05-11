import { Component, OnInit } from "@angular/core";

@Component({
  templateUrl: "./loja.compra.sucesso.component.html",
  styleUrls: ["./loja.compra.sucesso.component.css"]
})

export class LojaCompraSucessoComponent implements OnInit {
  public pedidoId: string;


  ngOnInit(): void {
    this.pedidoId = sessionStorage.getItem("pedidoId");
  }
}
