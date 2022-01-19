using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_API_QLS.Migrations
{
    public partial class MigrationQLS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bandocs_Quequans_QuequanId",
                table: "Bandocs");

            migrationBuilder.DropIndex(
                name: "IX_Bandocs_QuequanId",
                table: "Bandocs");

            migrationBuilder.DropColumn(
                name: "QuequanId",
                table: "Bandocs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuequanId",
                table: "Bandocs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bandocs_QuequanId",
                table: "Bandocs",
                column: "QuequanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bandocs_Quequans_QuequanId",
                table: "Bandocs",
                column: "QuequanId",
                principalTable: "Quequans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
