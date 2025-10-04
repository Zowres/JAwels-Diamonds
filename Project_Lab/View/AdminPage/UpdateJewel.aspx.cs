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
    public partial class UpdateJewel : System.Web.UI.Page
    {
        
        JewelController jc = new JewelController();
        UserController uc = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int jewelId;
                checkAdmin();
                BindCategoryDropdown();
                BindBrandDropdown();

                if (int.TryParse(Request.QueryString["id"], out jewelId))
                {

                    MsJewel jewel = jc.getJewel(jewelId);

                    if (jewel != null)
                    {
                        JewelNameTB.Text = jewel.JewelName;
                        JewelPriceTB.Text = Convert.ToString(jewel.JewelPrice);
                        JewelYearTB.Text = Convert.ToString(jewel.JewelReleaseYear);
                        ddlBrand.SelectedValue = Convert.ToString(jewel.BrandId);
                        ddlCategory.SelectedValue = Convert.ToString(jewel.CategoryId);

                    }
                    else
                    {
                        Response.Redirect("~/View/DetailPage.aspx?id=" + jewelId);

                    }
                }



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


        protected void UpdateJewelBtn_Click(object sender, EventArgs e)
        {
            int jewelId = Convert.ToInt32(Request.QueryString["id"]);
            String jewelName = JewelNameTB.Text;
            String jewelPrice = JewelPriceTB.Text;
            String brandName = ddlBrand.SelectedValue;
            String categoryName = ddlCategory.SelectedValue;
            String jewelYear = JewelYearTB.Text;


            String errorMsg = jc.validationUpdateJewel(jewelId,jewelName, categoryName,
                                                       brandName, jewelPrice,
                                                       jewelYear);

            if (errorMsg != null)
            {
                
            }
            else
            {
                
                Response.Redirect("~/View/DetailPage.aspx?id=" + jewelId);
            }
            ErrorMsg.Text = errorMsg;
        }
    }
}



