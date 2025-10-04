using Project_Lab.Factory;
using Project_Lab.Model;
using Project_Lab.View.AdminPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Project_Lab.Repository
{
    public class JewelRepository
    {
        DatabaseEntities db = new DatabaseEntities();
        JewelFactory jf = new JewelFactory();
        public List<MsJewel> getAllJewel()
        {
            List<MsJewel> listJewel = (from jwl in db.MsJewels select jwl).ToList();
            return listJewel;
        }
        public MsJewel getJewel(int id)
        {
            MsJewel jewel = (from jwl in db.MsJewels where id == jwl.JewelId select jwl).FirstOrDefault();
            return jewel;
        }

        public String getBrandName(int id)
        {
            String brand = (from brd in db.MsBrands where id == brd.BrandId select brd.BrandName).FirstOrDefault();
            return brand;
        }

        public String getBrandCountry(int id)
        {
            String brandCountry = (from gbc in db.MsBrands where id == gbc.BrandId select gbc.BrandCountry).FirstOrDefault();
            return brandCountry;
        }
        
        public String getCategory(int id)
        {
            String category = (from ctg in db.MsCategories where id == ctg.CategoryId select ctg.CategoryName).FirstOrDefault();
            return category;
        }

        public String getBrandClass(int id)
        {
            String brandClass = (from bc in db.MsBrands where id == bc.BrandId select bc.BrandClass).FirstOrDefault();
            return brandClass;
        }

        public List<MsCategory> getCategories()
        {
            List<MsCategory> categoryList = (from cl in db.MsCategories select cl).ToList();
            return categoryList;
        }

        public List<MsBrand> getBrands()
        {
            List<MsBrand> brandList = (from bl in db.MsBrands select bl).ToList();
            return brandList;
        }

        

        

        public void insertJewel( String name,int category , int brand, int price, int year)
        {
            MsJewel jewel = jf.createNewJewel(name, category, brand, price, year);
            db.MsJewels.Add(jewel);
            db.SaveChanges();               
        }

        public void updateJewel(int id, String name, int category, int brand, int price, int year)
        {

            var jewel = db.MsJewels.FirstOrDefault(j => j.JewelId == id);
            if (jewel != null)
            {
                jewel.JewelName = name; 
                jewel.JewelPrice = price; 
                jewel.JewelReleaseYear = year;
                jewel.BrandId = brand;
                jewel.CategoryId = category;

                db.SaveChanges();
            }
        }

        public void deleteJewel(int id)
        {
            MsJewel jewel = db.MsJewels.Find(id);
            if(jewel != null)
            {
                
                List<Cart> listCart = (from c in db.Carts where c.JewelId == jewel.JewelId select c).ToList();
                
                db.Carts.RemoveRange(listCart);

                //remove in transaction header and detail

                List<TransactionHeader> thList = (from th in db.TransactionHeaders
                                                  join td in db.TransactionDetails on th.TransactionId equals td.TransactionId
                                                  where td.JewelId == jewel.JewelId
                                                  select th).Distinct().ToList();
                foreach (TransactionHeader transactionHeader in thList)
                {
                    List<TransactionDetail> tdList = (from t in db.TransactionDetails
                                                      where t.TransactionId
                                                      == transactionHeader.TransactionId
                                                      select t).ToList();
                    if(tdList != null)
                    {
                        db.TransactionDetails.RemoveRange(tdList);
                        db.TransactionHeaders.Remove(transactionHeader);
                    }
                }

                

                db.MsJewels.Remove(jewel);
                db.SaveChanges();



            }

            


            
            return;
        }

    }
}