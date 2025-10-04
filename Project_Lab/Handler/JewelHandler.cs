using Project_Lab.Factory;
using Project_Lab.Model;
using Project_Lab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab.Handler
{
    public class JewelHandler
    {
        JewelRepository jr = new JewelRepository(); 
        public List<MsJewel> getAllJewel()
        {
            List<MsJewel> msJewels = jr.getAllJewel();
            return msJewels;    
        }

        public MsJewel getJewel(int id)
        {
            return jr.getJewel(id);
        }

        public String getBrandName(int id)
        {
            return jr.getBrandName(id);
        }

        public String getBrandCountry(int id)
        {
            return jr.getBrandCountry(id);
        }

        public String getCategory(int id)
        {
            return jr.getCategory(id);
        }
        public String getBrandClass(int id)
        {
            return jr.getBrandClass(id);
        }

        public List<MsCategory> getCategories()
        {
            return jr.getCategories();
        }

        public List<MsBrand> getBrands()
        {
            return jr.getBrands();
        }
        

        public bool validateDate(String date)
        {
            return DateTime.Now.Year <= Convert.ToInt32(date);

        }

        public bool checkPrice(int price)
        {
            return price <= 25;
        }

        public void insertNewJewel(String name, String category, String brand, String price, String year)
        {
            jr.insertJewel( name, Convert.ToInt32(category), Convert.ToInt32(brand), Convert.ToInt32(price),Convert.ToInt32(year));  
        }


        public void updateNewJewel(int id,String name, String category, String brand, String price, String year)
        {
            jr.updateJewel(id, name, Convert.ToInt32(category), Convert.ToInt32(brand), Convert.ToInt32(price), Convert.ToInt32(year));
        }

        public void deleteJewel(int id)
        {
            jr.deleteJewel(id);
        }

    }
}