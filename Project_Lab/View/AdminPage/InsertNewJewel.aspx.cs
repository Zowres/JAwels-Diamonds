using Project_Lab.Controller;
using Project_Lab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Lab.View.AdminPage
{
    public partial class InsertNewJewel : System.Web.UI.Page
    {
        JewelController jc = new JewelController();
        UserController uc = new UserController();
            protected void Page_Load(object sender, EventArgs e)
            {
                if(!IsPostBack)
                {
                    checkAdmin();
                    BindCategoryDropdown();    
                    BindBrandDropdown();

                }
            }

            private void checkAdmin()
            {
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
                    Response.Redirect("~/View/HomePage.aspx");
                }
            
                else if (!uc.validateUserAdmin(user.UserId))
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }

        }

        private void BindCategoryDropdown()
        {
            List<MsCategory> categories = jc.GetCategories();

            ddlCategory.DataSource = categories;

            ddlCategory.DataTextField = "CategoryName"; 

            ddlCategory.DataValueField = "CategoryId"; 
            ddlCategory.DataBind();

            ddlCategory.Items.Insert(0, new ListItem("-- Select Category --", ""));
        }

        private void BindBrandDropdown()
        {
            List<MsBrand> brands = jc.GetBrands();

            ddlBrand.DataSource = brands;

            ddlBrand.DataTextField = "BrandName"; 

            ddlBrand.DataValueField = "BrandId"; 

            ddlBrand.DataBind();

            ddlBrand.Items.Insert(0, new ListItem("-- Select Brand --", ""));
        }

        protected void SubmitJewel_Click(object sender, EventArgs e)
        {
            String jewelName = JewelNameTB.Text;
            String jewelPrice = JewelPriceTB.Text;
            String brandName = ddlBrand.SelectedValue;
            String categoryName = ddlCategory.SelectedValue;
            String jewelYear = JewelYearTB.Text;


            String errorMsg = jc.validationInsertJewel(jewelName,categoryName,
                                                       brandName,jewelPrice,
                                                       jewelYear);

            if(errorMsg != null)
            {

                ErrorMsg.Text = errorMsg;
                
            }
            else
            {
                ErrorMsg.Text = "Jewel Successfully inserted";

            }

        }

        protected void CancelInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HomePage.aspx");
        }
    }
}