using DailySnacksBar.Context;
using DailySnacksBar.Models;
using DailySnacksBar.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DailySnacksBar.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private readonly SnackBarDbContext _context;

        public SnackRepository(SnackBarDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Snack> Snacks => _context.Snacks.Include(x => x.Category);

        public IEnumerable<Snack> FavoriteSnacks => _context.Snacks.Where(x => x.IsFavorite).Include(x => x.Category);

        public Snack GetSnackById(int id)
        {
            return _context.Snacks.FirstOrDefault(x => x.Id == id);
        }
    }
}
