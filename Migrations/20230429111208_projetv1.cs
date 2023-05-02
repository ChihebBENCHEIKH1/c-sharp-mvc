using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_de_stock.Migrations
{
    /// <inheritdoc />
    public partial class projetv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_idClient",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_idProduit",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Commandes");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_idProduit",
                table: "Commandes",
                newName: "IX_Commandes_idProduit");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_idClient",
                table: "Commandes",
                newName: "IX_Commandes_idClient");

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "quantiteDemandee",
                table: "Commandes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commandes",
                table: "Commandes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Clients_idClient",
                table: "Commandes",
                column: "idClient",
                principalTable: "Clients",
                principalColumn: "IdClient",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Products_idProduit",
                table: "Commandes",
                column: "idProduit",
                principalTable: "Products",
                principalColumn: "IdProduit",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Clients_idClient",
                table: "Commandes");

            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Products_idProduit",
                table: "Commandes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commandes",
                table: "Commandes");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "quantiteDemandee",
                table: "Commandes");

            migrationBuilder.RenameTable(
                name: "Commandes",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Commandes_idProduit",
                table: "Orders",
                newName: "IX_Orders_idProduit");

            migrationBuilder.RenameIndex(
                name: "IX_Commandes_idClient",
                table: "Orders",
                newName: "IX_Orders_idClient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_idClient",
                table: "Orders",
                column: "idClient",
                principalTable: "Clients",
                principalColumn: "IdClient",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_idProduit",
                table: "Orders",
                column: "idProduit",
                principalTable: "Products",
                principalColumn: "IdProduit",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
