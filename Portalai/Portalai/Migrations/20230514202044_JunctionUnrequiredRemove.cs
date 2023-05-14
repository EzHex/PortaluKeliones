using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portalai.Migrations
{
    public partial class JunctionUnrequiredRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portals_PortalJunctions_PortalJunctionId",
                table: "Portals");

            migrationBuilder.AlterColumn<int>(
                name: "PortalJunctionId",
                table: "Portals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Portals_PortalJunctions_PortalJunctionId",
                table: "Portals",
                column: "PortalJunctionId",
                principalTable: "PortalJunctions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portals_PortalJunctions_PortalJunctionId",
                table: "Portals");

            migrationBuilder.AlterColumn<int>(
                name: "PortalJunctionId",
                table: "Portals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Portals_PortalJunctions_PortalJunctionId",
                table: "Portals",
                column: "PortalJunctionId",
                principalTable: "PortalJunctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
