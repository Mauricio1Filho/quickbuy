﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickBuy.Repositorio.Contexto;

namespace QuickBuy.Repositorio.Migrations
{
    [DbContext(typeof(QuickBuyContexto))]
    partial class QuickBuyContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("QuickBuy.Dominio.Entidades.ItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PedidoId");

                    b.Property<int>("ProdutoId");

                    b.Property<int>("Quantidade")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("ItemPedidos");
                });

            modelBuilder.Entity("QuickBuy.Dominio.Entidades.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("DataPedido");

                    b.Property<DateTime>("DataPrevisaoEntrega");

                    b.Property<string>("EderecoCompleto")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("FormaPagamentoId");

                    b.Property<int>("NumeroEndereco")
                        .HasMaxLength(8);

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("FormaPagamentoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("QuickBuy.Dominio.Entidades.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("NomeArquivo");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(19,4)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("QuickBuy.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("EhAdministrador");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("QuickBuy.Dominio.OBjetoDeValor.FormaPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("FormaPagamento");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Forma de Pagamento Boleto",
                            Nome = "Boleto",
                            Tipo = 0
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Forma de Pagamento Cartao de Credito",
                            Nome = "Cartao de Credito",
                            Tipo = 0
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Forma de Pagamento Deposito",
                            Nome = "Deposito",
                            Tipo = 0
                        });
                });

            modelBuilder.Entity("QuickBuy.Dominio.Entidades.ItemPedido", b =>
                {
                    b.HasOne("QuickBuy.Dominio.Entidades.Pedido")
                        .WithMany("ItensPedidos")
                        .HasForeignKey("PedidoId");
                });

            modelBuilder.Entity("QuickBuy.Dominio.Entidades.Pedido", b =>
                {
                    b.HasOne("QuickBuy.Dominio.OBjetoDeValor.FormaPagamento", "FormaPagamento")
                        .WithMany()
                        .HasForeignKey("FormaPagamentoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuickBuy.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
