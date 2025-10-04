using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab.Model
{
    public class CartViewModel
    {
        public int JewelId { get; set; }
        public string JewelName { get; set; }
        public decimal JewelPrice { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal => JewelPrice * Quantity;

    }
}