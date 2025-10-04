using Project_Lab.Model;
using Project_Lab.Repository;
using System;
using System.Collections.Generic;


namespace Project_Lab.Handler
{
    public class CartHandler
    {
        CartRepository cr = new CartRepository(); 
        TransactionRepository tr = new TransactionRepository();
        public List<CartViewModel> getListCartView(int userId)
        {
            return cr.getListCartView(userId);
        }

        public int totalPrice(int userId)
        {
            return cr.totalPrice(userId);
        }

        public void updateQuantity(int newQuantity, int jewelId, int userId)
        {
            cr.updateQuantity(newQuantity, jewelId,userId);
        }

        public void deleteItem(int jewelId, int userId)
        {
            cr.deleteItem(jewelId, userId); 
        }

        public void createNewCart(int jewelId, int userId)
        {
            cr.createNewCart(jewelId,userId);
        }

        public void deleteAllCarts(int userId)
        {
            cr.deleteAllCartUser(userId);    
        }

        private int getLastTransactionId()
        {
            int lastId = 0;

            if(cr.getLastTransactionId() > 0)
            {
                lastId = cr.getLastTransactionId() + 1;
            }
            else
            {
                lastId = 1;
            }


            return lastId;
        }

        private DateTime getTimeNow()
        {
            DateTime now = DateTime.Now;
            return now;
        }

        public void addTransaction(int userId, String paymentMethod)
        {
            int TransactionId = getLastTransactionId();
            DateTime date = getTimeNow();   
            List<Cart> listCart = cr.getListCart(userId);
            String status = "Payment Pending";
            tr.insertTransactionHeader(TransactionId, userId, date, paymentMethod, status);

            
            if(listCart == null) {
                return;
            }

            foreach(Cart cart in listCart)
            {
                
                tr.insertTransactionDetail(TransactionId, cart.JewelId, cart.Quantity);
            }

        }

    }
}