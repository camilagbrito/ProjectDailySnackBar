using Microsoft.AspNetCore.Mvc;

namespace DailySnacksBar.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
