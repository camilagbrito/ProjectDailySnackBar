using DailySnacksBar.Models;

namespace DailySnacksBar.Repositories.Interfaces
{
    public interface ISnackRepository
    {
        IEnumerable<Snack> Snacks { get; }

        IEnumerable<Snack> FavoriteSnacks { get; }

        Snack GetSnackById(int id);
    }
}
