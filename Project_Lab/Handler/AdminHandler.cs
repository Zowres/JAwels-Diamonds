using Project_Lab.Model;
using Project_Lab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab.Handler
{
    public class AdminHandler
    {
        TransactionRepository tr = new TransactionRepository();
        public List<TransactionHeader> getAllTransactionForAdmin()
        {
            return tr.getAllTransactionForAdmin();
        }

        public List<TransactionHeader> getAllTransactionReport()
        {
            return tr.getListTransactionReport();  
        }

        public void updateStatusTransactionArrived(int transactionId)
        {
            tr.updateStatusTransaction(transactionId, "Arrived");
        }

        public void updateStatusTransactionShipmentPending(int transactionId)
        {
            tr.updateStatusTransaction(transactionId, "Shipment Pending");
        }

    }
}