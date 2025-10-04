using Project_Lab.Factory;
using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using System.Web.Util;

namespace Project_Lab.Repository
{
    public class TransactionRepository
    {
        DatabaseEntities db = new DatabaseEntities();
        TransactionFactory trf = new TransactionFactory();
        public void insertTransactionHeader(int transactionId, int userId, DateTime date, String paymentMethod, String transactionStatus)
        {
            TransactionHeader th = trf.createTransactionHeader(transactionId, userId, date, paymentMethod, transactionStatus);
            db.TransactionHeaders.Add(th);
            db.SaveChanges();
        }



        public List<TransactionHeader> getAllTransactionByUserId(int userId)
        {
            List<TransactionHeader> listTransaction = (from transaction in db.TransactionHeaders where userId == transaction.UserId select transaction).ToList();
            return listTransaction;
        }
        public void insertTransactionDetail(int transactionId, int jewelId, int quantity)
        {
            TransactionDetail td = trf.createTransactionDetail(transactionId, jewelId, quantity);
            db.TransactionDetails.Add(td);
            db.SaveChanges();
        }

        public List<TransactionDetailView> getAllTransactionDetail(int transactionId)
        {
            List<TransactionDetailView> listTransaction = (from td in db.TransactionDetails
                                                      join j in db.MsJewels on td.JewelId equals j.JewelId
                                                      where td.TransactionId == transactionId   
                                                      select new TransactionDetailView
                                                      {
                                                          TransactionId = transactionId,
                                                          Quantity =  td.Quantity,
                                                          JewelName = j.JewelName
                                                      }).ToList();
            return listTransaction;
        }
         
        public List<TransactionHeader> getAllTransactionForAdmin()
        {
            List<TransactionHeader> listTransaction = (from transaction in db.TransactionHeaders
                                                       where transaction.TransactionStatus != "Done" && transaction.TransactionStatus != "Rejected"
                                                       select transaction).ToList();
            return listTransaction;
        }

        public void updateStatusTransaction(int transactionId, String status)
        {
            TransactionHeader th = (from transaction in db.TransactionHeaders where transactionId == transaction.TransactionId select transaction).FirstOrDefault();
            
            if(th != null)
            {
                th.TransactionStatus = status;
                db.SaveChanges();
            }
            
        }

        public List<TransactionHeader> getListTransactionReport()
        {
            List<TransactionHeader> list = (from t in db.TransactionHeaders
                                            where t.TransactionStatus == "Done"
                                            select t).ToList();

            return list;
        }
    }
}