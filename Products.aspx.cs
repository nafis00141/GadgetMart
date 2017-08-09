using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["CAT"] == null && Request.QueryString["NAME"] == null)
        {
            if (!IsPostBack)
            {
                getAllProducts();
            }
        }
        else if(Request.QueryString["CAT"] != null)
        {
            if (!IsPostBack)
            {
                getAllProductsUnderCat(Request.QueryString["CAT"]);
            }
        }
        else if (Request.QueryString["NAME"] != null)
        {
            
                getAllProductsUnderName(Request.QueryString["NAME"]);
            
        }



    }

    private void getAllProductsUnderName(string v)
    {
        ProductDAO productDao = new ProductDAO();

        DataTable dataTable = productDao.getProductUnderName(v);

        rptrProducts.DataSource = dataTable;

        rptrProducts.DataBind();
    }

    private void getAllProductsUnderCat(string v)
    {
        ProductDAO productDao = new ProductDAO();

        DataTable dataTable = productDao.getProductUnderCat(v);

        rptrProducts.DataSource = dataTable;

        rptrProducts.DataBind();
    }

    public void getAllProducts()
    {
        ProductDAO productDao = new ProductDAO();

        DataTable dataTable = productDao.getProduct();

        rptrProducts.DataSource = dataTable;

        rptrProducts.DataBind();
    }


    protected void Button10_Click(object sender, EventArgs e)
    {

        String k = "~/Products.aspx?NAME=" + name_search.Text;

        Response.Redirect(k);
    }
}