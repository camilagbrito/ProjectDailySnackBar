using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailySnacksBar.Migrations
{
    public partial class SeedingSnacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId, ShortDescription, DetailedDescription, IsAvailable, ImgThumbnailUrl, ImgUrl, IsFavorite, Name, Price)" +
                           "VALUES(1,'Bread, burger, ham, egg, cheese, salad and fries', 'A delicious bread with the best quality of burger, ham, egg, cheese, salad and fries',1, '/images/hamburgerSalad1.jpg', '/images/hamburgerSalad1.jpg', 0, 'Hamburger Salad', 12.50)");
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId, ShortDescription, DetailedDescription, IsAvailable, ImgThumbnailUrl, ImgUrl, IsFavorite, Name, Price)" +
                          "VALUES(1,'Bread, ham, cheese, tomato and fries', 'A delicious sliced bread with the best quality of ham,  cheese, and tomato with fries',1, '/images/toast.jpg', '/images/toast.jpg', 0, 'Grilled ham and cheese sandwich', 8.00)");
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId, ShortDescription, DetailedDescription, IsAvailable, ImgThumbnailUrl, ImgUrl, IsFavorite, Name, Price)" +
                          "VALUES(1,'Bread, burger, cheese and fries', 'A delicious bread with the best quality of burger, cheese and fries',1, '/images/cheeseburger1.jpg', '/images/cheeseburger1.jpg', 0, 'Cheese Burger', 11.00)");
            migrationBuilder.Sql("INSERT INTO Snacks(CategoryId, ShortDescription, DetailedDescription, IsAvailable, ImgThumbnailUrl, ImgUrl, IsFavorite, Name, Price)" +
                          "VALUES(2,'Home-made bread, white cheese, turkey chest and salad', 'A delicious and healthy sandwich with the best and more natural ingredients',1, '/images/natural.jpg', '/images/natural.jpg', 1, 'Natural sandwich', 15.00)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Snacks");
        }
    }
}
