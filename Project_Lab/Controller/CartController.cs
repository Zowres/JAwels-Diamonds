using Project_Lab.Handler;
using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab.Controller
{
    public class CartController
    {
        CartHandler ch = new CartHandler();
        public List<CartViewModel> getListCartView(int userId)
        {
            return ch.getListCartView(userId);  
        }

        public int totalPrice(int userId)
        {
            return ch.totalPrice(userId);
        }
        public void createCart(int jewelId, int userId)
        {
            ch.createNewCart(jewelId, userId);
        }

        public void updateQuantity(int newQuantity, int jewelId, int userId)
        {
            if (newQuantity < 0) return; 

            ch.updateQuantity(newQuantity, jewelId, userId);
        }

        public void deleteItem(int jewelId, int userId)
        {

            ch.deleteItem(jewelId, userId); 
        }

        public void deleteAllCarts(int userId)
        {
            ch.deleteAllCarts(userId);
        }

        public void addTransaction(int userId, String paymentMethod)
        {
           
            ch.addTransaction(userId, paymentMethod);
        }
    }
}