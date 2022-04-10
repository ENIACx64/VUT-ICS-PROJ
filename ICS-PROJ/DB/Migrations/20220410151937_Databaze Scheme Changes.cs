using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class DatabazeSchemeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarEntities_UserEntities_UserEntityID",
                table: "CarEntities");

            migrationBuilder.RenameColumn(
                name: "UserEntityID",
                table: "CarEntities",
                newName: "OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_CarEntities_UserEntityID",
                table: "CarEntities",
                newName: "IX_CarEntities_OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_CarEntities_UserEntities_OwnerID",
                table: "CarEntities",
                column: "OwnerID",
                principalTable: "UserEntities",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarEntities_UserEntities_OwnerID",
                table: "CarEntities");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "CarEntities",
                newName: "UserEntityID");

            migrationBuilder.RenameIndex(
                name: "IX_CarEntities_OwnerID",
                table: "CarEntities",
                newName: "IX_CarEntities_UserEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_CarEntities_UserEntities_UserEntityID",
                table: "CarEntities",
                column: "UserEntityID",
                principalTable: "UserEntities",
                principalColumn: "ID");
        }
    }
}
