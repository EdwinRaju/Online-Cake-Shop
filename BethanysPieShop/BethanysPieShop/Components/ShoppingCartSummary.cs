using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCart _shoppingcart;
        public ShoppingCartSummary(IShoppingCart shoppingcart)
        {
            _shoppingcart = shoppingcart;
        }
        public IViewComponentResult Invoke()
        {
            var items = _shoppingcart.GetShoppingCartItems();
            _shoppingcart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingcart, _shoppingcart.GetShoppingCartTotal());
            _shoppingcart.GetShoppingCartTotal();
            return View(shoppingCartViewModel);
        }
    }
}
