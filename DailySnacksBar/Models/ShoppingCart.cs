using DailySnacksBar.Context;
using Microsoft.EntityFrameworkCore;

namespace DailySnacksBar.Models
{
    public class ShoppingCart
    {

        private readonly SnackBarDbContext _context;

        public ShoppingCart(SnackBarDbContext context)
        {
            _context = context;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

   
        public static ShoppingCart GetShoppingCart (IServiceProvider services) {
            
           ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<SnackBarDbContext>();

            string shoppingCartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString();

            session.SetString("ShoppingCartId", shoppingCartId);

            return new ShoppingCart(context)
            {
                ShoppingCartId = shoppingCartId
            };
        }

        public void AddToShoppingCart(Snack snack)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(x =>
            x.Snack.Id == snack.Id && x.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Snack = snack,
                    Quantity = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
                    
            }
            else
            {
                shoppingCartItem.Quantity ++;
            }

            _context.SaveChanges();
        }

        public void RemoveToShoppingCart(Snack snack)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(x =>
            x.Snack.Id == snack.Id && x.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
               if(shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }

            }
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems =
                _context.ShoppingCartItems
                .Where(x => x.ShoppingCartId == ShoppingCartId)
                .Include(x => x.Snack)
                .ToList());
                
        }

        public void ClearShoppingCart()
        {
            var shoppingCartItems = _context.ShoppingCartItems
                                    .Where(x => x.ShoppingCartId == ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(shoppingCartItems);
            _context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems
                .Where(x => x.ShoppingCartId == ShoppingCartId)
                .Select(x => x.Snack.Price * x.Quantity).Sum();
            return total;
        }
    }
}
