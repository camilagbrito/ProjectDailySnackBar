using DailySnacksBar.Context;
using DailySnacksBar.Models;
using DailySnacksBar.Repositories.Interfaces;

namespace DailySnacksBar.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SnackBarDbContext _context;

        public CategoryRepository(SnackBarDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> categories => _context.Categories;
    }
}
