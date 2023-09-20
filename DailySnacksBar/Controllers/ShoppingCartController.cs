using DailySnacksBar.Models;
using DailySnacksBar.Models.ViewModels;
using DailySnacksBar.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DailySnacksBar.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ISnackRepository snackRepository, ShoppingCart shoppingCart)
        {
            _snackRepository = snackRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var itens = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = itens;

            var shoppingCartVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartVM);
        }

        public IActionResult AddToShoppingCart(int snackId)
        {
            var selectSnack = _snackRepository.Snacks.FirstOrDefault(x => x.Id == snackId);

            if (selectSnack != null)
            {
                _shoppingCart.AddToShoppingCart(selectSnack);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveToShoppingCart(int snackId)
        {
            var selectSnack = _snackRepository.Snacks.FirstOrDefault(x => x.Id == snackId);

            if (selectSnack != null)
            {
                _shoppingCart.RemoveToShoppingCart(selectSnack);
            }

            return RedirectToAction("Index");
        }
    }
}
