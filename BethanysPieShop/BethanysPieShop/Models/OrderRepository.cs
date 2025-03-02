﻿using BethanysPieShop.Models;

public class OrderRepository : IOrderRepository
{
    private readonly BethanysPieShopContext _bethanysPieShopContext;
    private readonly IShoppingCart _shoppingCart;

    public OrderRepository(BethanysPieShopContext bethanysPieShopContext, IShoppingCart shoppingCart) // Use IShoppingCart here
    {
        _bethanysPieShopContext = bethanysPieShopContext;
        _shoppingCart = shoppingCart; // No change needed here
    }

    public void CreateOrder(Order order)
    {
        order.OrderPlaced = DateTime.Now;
        List<ShoppingCartItem> shoppingCartItems = _shoppingCart.ShoppingCartItems;
        order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
        order.OrderDetails = new List<OrderDetail>();

        foreach (ShoppingCartItem shoppingCartItem in shoppingCartItems)
        {
            var orderDetail = new OrderDetail
            {
                Amount = shoppingCartItem.Amount,
                PieId = shoppingCartItem.Pie.PieId,
                Price = shoppingCartItem.Pie.Price
            };
            order.OrderDetails.Add(orderDetail);
        }

        _bethanysPieShopContext.Orders.Add(order);
        _bethanysPieShopContext.SaveChanges();
    }
}
