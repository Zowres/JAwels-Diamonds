using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab.Factory
{
    public class CartFactory
    {
        public Cart createNewItem(int userId, int jewelId, int Quantity)
        {
            Cart cart = new Cart();
            cart.UserId = userId;
            cart.JewelId = jewelId;
            cart.Quantity = Quantity;

            return cart;
        }
    }
}