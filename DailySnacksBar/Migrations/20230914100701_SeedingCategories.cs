using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailySnacksBar.Migrations
{

    public partial class SeedingCategories : Migration
    {
   
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(Name, Description)" +
                "VALUES('Normal', 'Snacks with normal ingredients')");

            migrationBuilder.Sql("INSERT INTO Categories(Name, Description)" +
               "VALUES('Natural', 'Snacks with healthy ingredients')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
