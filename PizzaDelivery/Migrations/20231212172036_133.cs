using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaDelivery.Migrations
{
    /// <inheritdoc />
    public partial class _133 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_PizzaWithSizes_PizzaId",
                table: "OrderLines");

            migrationBuilder.DropTable(
                name: "PizzaSizeOfPizza");

            migrationBuilder.DropTable(
                name: "PizzaWithSizes");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Pizzas_PizzaId",
                table: "OrderLines",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Pizzas_PizzaId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Pizzas");

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaSizeOfPizza",
                columns: table => new
                {
                    PizzasId = table.Column<int>(type: "int", nullable: false),
                    SizeOfPizzasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaSizeOfPizza", x => new { x.PizzasId, x.SizeOfPizzasId });
                    table.ForeignKey(
                        name: "FK_PizzaSizeOfPizza_Pizzas_PizzasId",
                        column: x => x.PizzasId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaSizeOfPizza_Sizes_SizeOfPizzasId",
                        column: x => x.SizeOfPizzasId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaWithSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaWithSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaWithSizes_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaWithSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaSizeOfPizza_SizeOfPizzasId",
                table: "PizzaSizeOfPizza",
                column: "SizeOfPizzasId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaWithSizes_PizzaId",
                table: "PizzaWithSizes",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaWithSizes_SizeId",
                table: "PizzaWithSizes",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_PizzaWithSizes_PizzaId",
                table: "OrderLines",
                column: "PizzaId",
                principalTable: "PizzaWithSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
