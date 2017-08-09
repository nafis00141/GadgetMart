using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getAllCatagory();
        }
    }

    public void getAllCatagory()
    {
        ProductDAO productDao = new ProductDAO();

        DataTable dataTable = productDao.getCatagory();

        rptrCategory.DataSource = dataTable;

        rptrCategory.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        if (txtCatName.Text != "")
        {
            ProductDAO addCatagoryObj = new ProductDAO();

            addCatagoryObj.addCatagory(new ProductDTO(txtCatName.Text, 1, 2));

            txtCatName.Text = "";

            getAllCatagory();

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

        int cid = Convert.ToInt32(btn.CommandArgument.ToString());

        ProductDAO productDao = new ProductDAO();

        productDao.deleteCategory(cid);

        getAllCatagory();

    }
}