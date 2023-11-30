using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyExpenseTracker.Repository.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabaseWithBankTableOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Acrynonym = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Acrynonym", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "SBI", "State Bank of India", "National" },
                    { 2, "HDFC", "HDFC Bank", "National" },
                    { 3, "ICICI", "ICICI Bank", "National" },
                    { 4, "AXIS", "Axis Bank", "National" },
                    { 5, "BOB", "Bank of Baroda", "National" },
                    { 6, "BOI", "Bank of India", "National" },
                    { 7, "CBI", "Central Bank of India", "National" },
                    { 8, "PNB", "Punjab National Bank", "National" },
                    { 9, "UBI", "Union Bank of India", "National" },
                    { 10, "KOTAK", "Kotak Mahindra Bank Ltd.", "National" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
