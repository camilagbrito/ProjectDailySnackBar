using DailySnacksBar.Models;
using Microsoft.EntityFrameworkCore;

namespace DailySnacksBar.Context
{
    public class SnackBarDbContext: DbContext
    {
        public SnackBarDbContext(DbContextOptions<SnackBarDbContext> options): base(options)
        {

        }

        public DbSet<Category>  Categories { get; set; }
        public DbSet<Snack> Snacks { get; set; }
    }
}
