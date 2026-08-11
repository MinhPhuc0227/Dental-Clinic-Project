using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToReceptionist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Receptionist",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Receptionist");
        }
    }
}
