using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelsFreak.Data.Migrations
{
    /// <inheritdoc />
    public partial class tableupdateTourPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TourPackageLocation",
                table: "TourPackages",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TourPackageLocation",
                table: "TourPackages");
        }
    }
}
