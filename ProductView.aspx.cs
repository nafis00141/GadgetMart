using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductView : System.Web.UI.Page
{
    int PID;

    int quanity;

    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (Request.QueryString["PID"] != null)
        {
            PID = Convert.ToInt32(Request.QueryString["PID"]);

            
                
                getProductsIMG(PID);
                getProductsData(PID);
            
        }
        else
        {
            Response.Redirect("~/Products.aspx");
        }
        
    }

    private void getProductsIMG(int pID)
    {
        ProductDAO productDao = new ProductDAO();

        DataTable dataTable = productDao.getSelectedProductIMG(pID);

        rptrImages.DataSource = dataTable;

        rptrImages.DataBind();
       
    }

    private void getProductsData(int pID)
    {
        ProductDAO productDao = new ProductDAO();

        DataTable dataTable = productDao.getSelectedProductData(pID);

        quanity = Convert.ToInt32(dataTable.Rows[0][6].ToString());

        rptrProductDetails.DataSource = dataTable;

        rptrProductDetails.DataBind();
    }

    protected string GetActiveClass(int ItemIndex) // img move er jonno akbar active korte hoy repImages a call korte hoy
    {
        if (ItemIndex == 0)
        {
            return "active";
        }
        else
        {
            return "";
        }
    }


    protected void Button3_Click(object sender, EventArgs e)
    {

    }

    protected void btnAddToCart_Click(object sender, EventArgs e)
    {

        // add to cart

        int PID =Convert.ToInt32( Request.QueryString["PID"]);

        ArrayList cart1 = (ArrayList)Session["CARTP"];

        int num = 0;

        foreach (var item in cart1)
        {
            System.Diagnostics.Debug.WriteLine(item);

            int id = Convert.ToInt32(item);

            if (id == PID) num++;

        }



        if(quanity>num)
        {
            cart1.Add(PID);
           
        }
        else
        {
            Label1.Text = "Not Enough";
        }

        Session["CARTP"] = cart1;

        
        


    }
}