using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getAllCatagory();
        getAllProducts();
    }


    public void getAllCatagory()
    {
        ProductDAO pdao = new ProductDAO();

        DataTable dataTable = pdao.getCatagory();

        RepCat.DataSource = dataTable;

        RepCat.DataBind();

    }

    public void getAllProducts()
    {
        ProductDAO productDao = new ProductDAO();

        DataTable dataTable = productDao.getProduct();

        rptrProducts.DataSource = dataTable;

        rptrProducts.DataBind();
    }
}