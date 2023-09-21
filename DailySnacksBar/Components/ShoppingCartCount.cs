using DailySnacksBar.Models;
using DailySnacksBar.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DailySnacksBar.Components
{
    public class ShoppingCartCount: ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartCount(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartVM);
        }

    }
}
