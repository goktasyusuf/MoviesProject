using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_WriterId",
                table: "Movies",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Writers_WriterId",
                table: "Movies",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Writers_WriterId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_WriterId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Movies");
        }
    }
}
