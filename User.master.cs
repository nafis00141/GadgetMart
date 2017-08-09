using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["USERNAME"] != null)
            {

                getAllCatagory();


            }
            else
            {
                Response.Redirect("~/SignIn.aspx");
            }
        }
        
    }

    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        Session["USERNAME"] = null;
        Response.Redirect("~/Default.aspx");
    }


    public void getAllCatagory()
    {
        ProductDAO pdao = new ProductDAO();

        DataTable dataTable = pdao.getCatagory();

        RepCat.DataSource = dataTable;

        RepCat.DataBind();

    }
    protected void btnCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Cart.aspx");
    }

}
