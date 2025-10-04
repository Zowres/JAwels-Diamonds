using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab.Factory
{
    public class JewelFactory
    {
        public MsJewel createNewJewel(string name,int categoryID,int brandID,int price, int year)
        {
            MsJewel jewel = new MsJewel();
            
            jewel.JewelName = name;
            jewel.JewelPrice = price;
            jewel.JewelReleaseYear = year;
            jewel.CategoryId = categoryID;          
            jewel.BrandId = brandID;

            return jewel;
        }
    }
}