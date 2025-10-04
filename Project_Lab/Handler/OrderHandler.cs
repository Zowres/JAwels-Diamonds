using Project_Lab.Model;
using Project_Lab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab.Handler
{
    public class OrderHandler
    {
        TransactionRepository tr = new TransactionRepository();
        public List<TransactionHeader> getAllTransactionByUserId(int userId)
        {
            return tr.getAllTransactionByUserId(userId);
        }

        public List<TransactionDetailView> getAllTransactionDetail(int transactionId)
        {
            return tr.getAllTransactionDetail(transactionId);
        }

        public void updateStatusTransactionReject(int transactionId)
        {
            tr.updateStatusTransaction(transactionId, "Rejected");
        }


        public void updateStatusTransactionConfirm(int transactionId)
        {
            tr.updateStatusTransaction(transactionId, "Done");
        }


    }
}