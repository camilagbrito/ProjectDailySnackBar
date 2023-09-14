using DailySnacksBar.Models;

namespace DailySnacksBar.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> categories { get; }
    }
}
