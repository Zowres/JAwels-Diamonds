using Project_Lab.Handler;
using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab.Controller
{
    public class OrderController
    {
        OrderHandler oh = new OrderHandler();
        public List<TransactionHeader> getAllTransactionByUserId(int userId)
        {
            return oh.getAllTransactionByUserId(userId);
        }

        public List<TransactionDetailView> getAllTransactionDetail(int transactionId) {
            return oh.getAllTransactionDetail(transactionId);   
        }

        public void updateStatusTransactionReject(int transactionId)
        {
            oh.updateStatusTransactionReject(transactionId);
        }

        public void updateStatusTransactionConfirm(int transactionId)
        {
            oh.updateStatusTransactionConfirm(transactionId);
        }

    } 
}