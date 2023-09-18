using DailySnacksBar.Context;

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
    }
}
