using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaDelivery.Migrations
{
    /// <inheritdoc />
    public partial class addPizzaImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Pizzas",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Pizzas");
        }
    }
}
