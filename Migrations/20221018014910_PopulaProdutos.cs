﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaProdutos : Migration
    {
    protected override void Up(MigrationBuilder mb)
    {
      mb.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) VALUES ('Coca-Cola Diet', 'Refrigerange de Cola 350ml', 5.45, 'cocacola.jpg', 50, now(), 1)");
      mb.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) VALUES ('Lanche de Atum', 'Lanche de Atum com maionese', 8.50, 'atum.jpg', 10, now(), 2)");
      mb.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) VALUES ('Pudim 100g', 'Pudim de leite condensado 100g', 6.75, 'pudim.jpg', 20, now(), 3)");
    }

    protected override void Down(MigrationBuilder mb)
    {
      mb.Sql("DELETE FROM Produtos");
    }
  }
}
