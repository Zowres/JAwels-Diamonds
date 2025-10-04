using Project_Lab.Controller;
using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        JewelController jc = new JewelController();
        UserController uc = new UserController();
        CartController cc = new CartController();
        protected void Page_Load(object sender, EventArgs e)
        {
 
            if (!IsPostBack)
            {
                int jewelId;
                if (int.TryParse(Request.QueryString["id"], out jewelId))
                {
                   
                    MsJewel jewel = jc.getJewel(jewelId);
                    if (jewel != null)
                    {
                        // Display jewel details on the page
                        JewelName.Text = jewel.JewelName;
                        JewelPrice.Text = Convert.ToString(jewel.JewelPrice);
                        JewelYear.Text = Convert.ToString(jewel.JewelReleaseYear);
                        JewelBrandName.Text = jc.getBrandName(jewel.BrandId);
                        CategoryName.Text = jc.getCategory(jewel.CategoryId);
                        JewelCountry.Text = jc.getBrandCountry(jewel.BrandId);
                        JewelClass.Text = jc.getBrandClass(jewel.BrandId);

                        // Add other details as needed
                    }
                    else
                    {
                        // Handle case where jewel is not found

                    }
                }
                else
                {
                    // Handle invalid or missing id
                    Response.Redirect("~/View/HomePage.aspx");
                }

                MsUser user = Session["user"] as MsUser;

                if (user == null)
                {
                    HttpCookie userCookie = Request.Cookies["user_cookie"];

                    if (userCookie != null)
                    {
                        string id = userCookie.Value;

                        if (string.IsNullOrEmpty(id))
                        {
                            user = null;
                            Session["user"] = user;
                            userCookie = null;
                        }
                        else
                        {
                            user = uc.getCookie(id);
                            Session["user"] = user;
                        }

                    }
                }

                if (user == null)
                {
                    // Guest
                    UpdateJewel.Visible = false;
                    DeleteJewel.Visible = false;
                    AddToCart.Visible = false;
                }
                else if (uc.validateUserAdmin(user.UserId))
                {
                    // Admin   
                    UpdateJewel.Visible = true;
                    DeleteJewel.Visible = true; 
                    AddToCart.Visible = false;
                }
                else
                {
                    // Customer
                    AddToCart.Visible = true;
                    UpdateJewel.Visible = false;
                    DeleteJewel.Visible = false;

                }

            }
        }

        protected void UpdateJewel_Click(object sender, EventArgs e)
        {
            int jewelId = Convert.ToInt32(Request.QueryString["id"]);
            Response.Redirect("AdminPage/UpdateJewel.aspx?id=" + jewelId);
        }

        protected void DeleteJewel_Click(object sender, EventArgs e)
        {
            int jewelId = Convert.ToInt32(Request.QueryString["id"]);

            jc.deleteJewel(jewelId);
            Response.Redirect("~/View/Homepage.aspx");
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            MsUser user = Session["user"] as MsUser;
            int jewelId = Convert.ToInt32(Request.QueryString["id"]);

            cc.createCart(jewelId, user.UserId);
            Response.Redirect(Request.RawUrl);
        }
    }
        
}
