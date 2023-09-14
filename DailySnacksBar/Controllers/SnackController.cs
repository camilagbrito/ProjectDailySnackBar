using DailySnacksBar.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DailySnacksBar.Controllers
{
    public class SnackController : Controller
    {
        private readonly ISnackRepository _snackRepository;

        public SnackController(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }

        public IActionResult List()
        {
            var snacks = _snackRepository.Snacks;

            return View(snacks);
        }
    }
}
