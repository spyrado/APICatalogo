using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaCategorias : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
          mb.Sql("INSERT INTO Categorias (Nome, ImagemUrl) VALUES ('Bebidas', 'bebidas.jpg')");
          mb.Sql("INSERT INTO Categorias (Nome, ImagemUrl) VALUES ('Lanches', 'lanches.jpg')");
          mb.Sql("INSERT INTO Categorias (Nome, ImagemUrl) VALUES ('Sobremesas', 'Sobremesas.jpg')");
        }

        protected override void Down(MigrationBuilder mb)
        {
          mb.Sql("DELETE FROM Categorias");
        }
    }
}
