using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaDelivery.Migrations
{
    /// <inheritdoc />
    public partial class addSizes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sizes_SizeId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_SizeId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Pizzas");

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

            migrationBuilder.CreateIndex(
                name: "IX_PizzaSizeOfPizza_SizeOfPizzasId",
                table: "PizzaSizeOfPizza",
                column: "SizeOfPizzasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaSizeOfPizza");

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeId",
                table: "Pizzas",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizeId",
                table: "Pizzas",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
