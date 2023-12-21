using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaDelivery.Migrations
{
    /// <inheritdoc />
    public partial class _122 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Sizes",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Sizes",
                newName: "Size");
        }
    }
}
