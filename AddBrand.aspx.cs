using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddBrand : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getAllBrand();
        }
    }

    public void getAllBrand()
    {
        ProductDAO productDao = new ProductDAO();

        DataTable dataTable = productDao.getBrand();

        rptrBrands.DataSource = dataTable;

        rptrBrands.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        if (txtBrandName.Text != "")
        {
            ProductDAO addBrandObj = new ProductDAO();

            addBrandObj.addBrand(new ProductDTO(txtBrandName.Text, 1));

            txtBrandName.Text = "";

            getAllBrand();

            Label2.Text = "";
        }
        else
        {
            Label2.Text = "Please Enter First!";
        }
        

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        System.Diagnostics.Debug.WriteLine("HERE");

        LinkButton btn = (LinkButton)(sender);

        int bid = Convert.ToInt32(btn.CommandArgument.ToString());

        ProductDAO productDao = new ProductDAO();

        productDao.deleteBrand(bid);

        getAllBrand();

    }
}