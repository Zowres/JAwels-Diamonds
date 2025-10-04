using Project_Lab.Handler;
using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab.Controller
{

    public class AdminController
    {
        AdminHandler ah = new AdminHandler();
        public List<TransactionHeader> getAllTransactionForAdmin()
        {
            return ah.getAllTransactionForAdmin();
        }

        public List<TransactionHeader> getAllTransactionReport()
        {
            return ah.getAllTransactionReport();
        }

        public void updateStatusTransactionArrived(int transactionId)
        {
            ah.updateStatusTransactionArrived(transactionId);
        }

        public void updateStatusTransactionShipmentPending(int transactionId)
        {
            ah.updateStatusTransactionShipmentPending(transactionId);
        }
    }
}