using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Forum.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[,]
                {
                    { new Guid("4d0ce161-1f1a-490f-a91c-524c9afbcbd5"), "Balancing workout routines with a busy schedule.", "Fitness and You" },
                    { new Guid("5a5c9def-916e-43ae-aa89-a11b426b7c7c"), "Predicting the next big trends in technology.", "The Future of Software" },
                    { new Guid("839aa81e-78d0-4df1-9481-dff5be26b04c"), "The journey of becoming a leading aeronautical engineer.", "Engineering Dreams" },
                    { new Guid("91307edc-06ec-48fe-8836-78e4eb484558"), "Solving complex problems in .Net and React.", "Coding Challenges" },
                    { new Guid("9b7a178b-3e08-4264-aa4d-c0f83d21dd71"), "A brief look into aeronautical advancements.", "Exploring the Sky" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
