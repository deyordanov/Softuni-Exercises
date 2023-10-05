using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetsStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedGrammaticalError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCards_AspNetUsers_ClientIdd",
                table: "ClientCards");

            migrationBuilder.DropIndex(
                name: "IX_ClientCards_ClientIdd",
                table: "ClientCards");

            migrationBuilder.RenameColumn(
                name: "ClientIdd",
                table: "ClientCards",
                newName: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCards_ClientId",
                table: "ClientCards",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCards_AspNetUsers_ClientId",
                table: "ClientCards",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCards_AspNetUsers_ClientId",
                table: "ClientCards");

            migrationBuilder.DropIndex(
                name: "IX_ClientCards_ClientId",
                table: "ClientCards");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "ClientCards",
                newName: "ClientIdd");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCards_ClientIdd",
                table: "ClientCards",
                column: "ClientIdd",
                unique: true,
                filter: "[ClientIdd] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCards_AspNetUsers_ClientIdd",
                table: "ClientCards",
                column: "ClientIdd",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
