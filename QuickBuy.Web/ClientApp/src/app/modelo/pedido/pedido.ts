import { ItemPedido } from "../item-pedido/itemPedido";

export class Pedido {
  public id: number;
  public dataPedido: Date;
  public usuarioId: number;
  public dataPrevisaoEntrega: Date;
  public cep: string;
  public estado: string;
  public cidade: string;
  public enderecoCompleto: string;
  public numeroEndereco: number;
  public formaPagamentoId: number;
  public itensPedido: ItemPedido[];

  constructor() {
    this.itensPedido = [];
  }
}
