using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurants.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContectNumber",
                table: "Restaurants",
                newName: "ContactNumber");

            migrationBuilder.RenameColumn(
                name: "ContectEmail",
                table: "Restaurants",
                newName: "ContactEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                table: "Restaurants",
                newName: "ContectNumber");

            migrationBuilder.RenameColumn(
                name: "ContactEmail",
                table: "Restaurants",
                newName: "ContectEmail");
        }
    }
}
