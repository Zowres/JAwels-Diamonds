using Project_Lab.Handler;
using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Lab.Controller
{
    public class JewelController
    {
        JewelHandler jh = new JewelHandler();
        public List<MsJewel> getAllJewel()
        {
            List<MsJewel> jewelList = jh.getAllJewel();
            return jewelList;
        }
        public MsJewel getJewel(int id)
        {
            return jh.getJewel(id);
        }

        public String getBrandName(int id)
        {
            return jh.getBrandName(id);
        }

        public String getBrandCountry(int id)
        {
            return jh.getBrandCountry(id);
        }
        
        public String getCategory(int id)
        {
            return jh.getCategory(id);
        }

        public String getBrandClass(int id)
        {
            return jh.getBrandClass(id);
        }

        public List<MsCategory> GetCategories()
        {
            return jh.getCategories();
        }
        public List<MsBrand> GetBrands()
        {
            return jh.getBrands();
        }

        public String validationInsertJewel(String name, String category, String brand, String price, String year)
        {
            String errorMsg = null;

            if(name.Length < 3 || name.Length > 25)
            {
                return "Jewel Name must be between 3 to 25 characters (inclusive)";
            }
            else if (string.IsNullOrEmpty(category))
            {
                return "Category must be selected from a dropdown list of category names.";
            }
            else if (string.IsNullOrEmpty(brand))
            {
                return "Brand must be selected from a dropdown list of brand names.";
            }
            else if (!int.TryParse(price, out int resultPrice))
            {
                return "Price must be number not alphabet.";
            }
            else if (jh.checkPrice(resultPrice))
            {
                return "Price must be more than $25.";
            }
            else if (!int.TryParse(year, out int resultYear))
            {
                return "Year must be a number.";
            }
            else if(jh.validateDate(year))
            {
                return "year must be less than the current year.";
            }
            else
            {
                jh.insertNewJewel(name,category,brand,price,year);
                errorMsg = null;
            }   
            return errorMsg;
        }

        public String validationUpdateJewel(int id,String name, String category, String brand, String price, String year)
        {
            String errorMsg = null;

            if (name.Length < 3 || name.Length > 25)
            {
                return "Jewel Name must be between 3 to 25 characters (inclusive)";
            }
            else if (string.IsNullOrEmpty(category))
            {
                return "Category must be selected from a dropdown list of category names.";
            }
            else if (string.IsNullOrEmpty(brand))
            {
                return "Brand must be selected from a dropdown list of brand names.";
            }
            else if (!int.TryParse(price, out int resultPrice))
            {
                return "Price must be number not alphabet.";
            }
            else if (jh.checkPrice(resultPrice))
            {
                return "Price must be more than $25.";
            }
            else if (!int.TryParse(year, out int resultYear))
            {
                return "Year must be a number.";
            }
            else if (jh.validateDate(year))
            {
                return "year must be less than the current year.";
            }
            else
            {
                jh.updateNewJewel(id,name, category, brand, price, year);
                errorMsg = null;
            }
            return errorMsg;
        }

        public void deleteJewel(int id)
        {
            jh.deleteJewel(id);
        }

    }
}