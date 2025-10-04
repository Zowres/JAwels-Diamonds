using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab.Factory
{
    public class TransactionFactory
    {

        public TransactionHeader createTransactionHeader(int transactionId,int userId,DateTime date ,String paymentMethod,String transactionStatus) {
        
            TransactionHeader transaction = new TransactionHeader();
            transaction.TransactionId = transactionId;
            transaction.UserId = userId;
            transaction.PaymentMethod = paymentMethod;  
            transaction.TransactionStatus = transactionStatus;
            transaction.TransactionDate = date;
            return transaction;
        }

        public TransactionDetail createTransactionDetail(int transactionId, int jewelId,int quantity) { 
            TransactionDetail transaction = new TransactionDetail();    
            transaction.TransactionId = transactionId;  
            transaction.JewelId = jewelId;
            transaction.Quantity = quantity;

            return transaction; 
        
        }
    }
}