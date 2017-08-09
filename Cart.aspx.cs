using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{

    public int total;
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (!IsPostBack)
        {
            total = 0;
            getproductOfcart();
        }
    }




    public void getproductOfcart()
    {
        ArrayList cart1 = (ArrayList)Session["CARTP"];

        ProductDAO productDao = new ProductDAO();

        DataTable dataTable = new DataTable();

        foreach (var item in cart1)
        {
            int i = Convert.ToInt32(item);

            DataTable data = productDao.getSelectedProductData(i);

            total = total + Convert.ToInt32(data.Rows[0][3].ToString());

            dataTable.Merge(data);

        }

        rptrProductDetails.DataSource = dataTable;

        rptrProductDetails.DataBind();

    }

   


    public void updateQuantity()
    {
        ArrayList cart1 = (ArrayList)Session["CARTP"];

        ProductDAO productDao = new ProductDAO();

        foreach (var item in cart1)
        {
            int i = Convert.ToInt32(item);

            productDao.updateProductQuantity(i);

        }

        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        System.Diagnostics.Debug.WriteLine("HERE");

        //add to sold table

        SoldDAO soldDao = new SoldDAO();

        String uid = Session["UID"].ToString();

        soldDao.addSold(new SoldDTO(uid,num.Text,add.Text));

        String sid = soldDao.getlastSID();

        ArrayList cart1 = (ArrayList)Session["CARTP"];

        ProductDAO productDao = new ProductDAO();


        foreach (var item in cart1)
        {
            int i = Convert.ToInt32(item);

            soldDao.addSoldItems(new SoldDTO(sid, i.ToString()));

        }

        //updated quantity
        updateQuantity();


        Response.Redirect("~/Success.aspx");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("HERE");
    }
}