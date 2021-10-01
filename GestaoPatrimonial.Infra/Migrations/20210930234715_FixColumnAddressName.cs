using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoPatrimonial.Data.Migrations
{
    public partial class FixColumnAddressName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adrress",
                table: "Addresses",
                newName: "PublicPlace");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicPlace",
                table: "Addresses",
                newName: "Adrress");
        }
    }
}
