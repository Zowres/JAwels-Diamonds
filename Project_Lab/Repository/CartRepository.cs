using Project_Lab.Factory;
using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Project_Lab.Model.CartViewModel;

namespace Project_Lab.Repository
{
    public class CartRepository
    {
        DatabaseEntities db = new DatabaseEntities();
        CartFactory cf = new CartFactory();
        public List<CartViewModel> getListCartView(int userId)
        {
            List<CartViewModel> cartItems = (from ci in db.Carts
                                    where ci.UserId == userId
                                    select new CartViewModel
                                    {
                                        JewelId = ci.JewelId,
                                        JewelName = ci.MsJewel.JewelName,
                                        JewelPrice = ci.MsJewel.JewelPrice,
                                        Brand = ci.MsJewel.MsBrand.BrandName,
                                        Quantity = ci.Quantity
                                    }).ToList(); ;

            return cartItems;
        }


        public Cart getCart(int userId)
        {
            Cart cartItems = (from ci in db.Carts
                                             where ci.UserId == userId
                                             select ci).FirstOrDefault();

            return cartItems;
        }

        public List<Cart> getListCart(int userId)
        {
            List<Cart> cartItems = (from ci in db.Carts
                              where ci.UserId == userId
                              select ci).ToList();

            return cartItems;
        }


        public void createNewCart(int jewelId, int userId) {
            Cart cart = (from ci in db.Carts where jewelId == ci.JewelId && ci.UserId == userId select ci).FirstOrDefault();
            if (cart != null)
            {
                cart.Quantity++;
            }
            else
            {
                Cart newCart = cf.createNewItem(userId, jewelId, 1);
                db.Carts.Add(newCart);
            }
            db.SaveChanges();
        }

        public int totalPrice(int userid)
        {
            Cart cartItems = getCart(userid);
            if (cartItems == null)
            {
                return 0;
            }
            else
            {
                int total = (from item in db.Carts
                                 where item.UserId == userid
                                 select item.Quantity * item.MsJewel.JewelPrice).Sum();
                return total;
            }

            
        }
        public void updateQuantity(int newQuantity, int jewelId, int userId)
        {
            Cart cart = (from ci in db.Carts where jewelId == ci.JewelId && userId == ci.UserId select ci).FirstOrDefault();

            if(cart != null)
            {
                cart.Quantity = newQuantity;    
                db.SaveChanges();
            }
            
        }

        public void deleteItem(int jewelId , int userId)
        {
            Cart cart = (from ci in db.Carts where jewelId == ci.JewelId && ci.UserId == userId select ci).FirstOrDefault();
            if(cart != null)
            {
                db.Carts.Remove(cart);  
                db.SaveChanges();
            }
            return;
        }

        public void deleteAllCartUser(int userId)
        {
            List<Cart> cart = (from ci in db.Carts where userId == ci.UserId select ci).ToList();
            db.Carts.RemoveRange(cart);
            db.SaveChanges();   
            return;
        }

        public int getLastTransactionId()
        {
            int lastId = (from tr in db.TransactionHeaders orderby tr.TransactionId descending select tr.TransactionId).FirstOrDefault();

            return lastId;
        }
    }
}