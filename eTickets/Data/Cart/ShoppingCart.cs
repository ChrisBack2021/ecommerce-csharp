using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }




        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }



        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.Movie.Id == movie.Id && x.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount >= 1)
                {
                    shoppingCartItem.Amount--;
                } else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }               
            }
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId).Include(x => x.Movie).ToList());
        }

        public double GetShoppingCartTotal()
        {
            double total = _context.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId).Select(x => x.Movie.Price * x.Amount).Sum();
            return total;
        }
    }
}
