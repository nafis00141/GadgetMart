using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USERNAME"] != null)
        {
            btnSignOut.Visible = true;
            lblSuccess.Text = "Order List";
            if (Request.QueryString["D"] != null)
            {
                int d = Convert.ToInt32(Request.QueryString["D"]);

                if (d == 0)
                {
                    lblSuccess.Text = "Order List";
                    getAllBoughtNotDelevered();
                    getAllCatagory();
                }
                else
                {
                    lblSuccess.Text = "Delevered List";
                    getAllBoughtDelevered();
                    getAllCatagory();
                }
            }

        }
        else
        {
            btnSignOut.Visible = false;
            Response.Redirect("~/SignIn.aspx");
        }
    }

    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        Session["USERNAME"] = null;
        Session["CARTP"] = new ArrayList();
        Response.Redirect("~/Default.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserHome.aspx?D=1");


    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("HERE");

        LinkButton btn = (LinkButton)(sender);

        System.Diagnostics.Debug.WriteLine(btn.CommandArgument);

        int sid = Convert.ToInt32(btn.CommandArgument.ToString());

        SoldDAO sold = new SoldDAO();

        DataTable dataTable = sold.getSoldItem(sid);

        var innerRepeater = rptrsold.Items[0].FindControl("rptrSoldItems") as Repeater;

        innerRepeater.DataSource = dataTable;

        innerRepeater.DataBind();

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserHome.aspx?D=0");
    }



    public void getAllCatagory()
    {
        ProductDAO pdao = new ProductDAO();

        DataTable dataTable = pdao.getCatagory();

        RepCat.DataSource = dataTable;

        RepCat.DataBind();

    }

    public void getAllBoughtNotDelevered()
    {
        SoldDAO sold = new SoldDAO();

        String uid = Session["UID"].ToString();

        DataTable dataTable = sold.getAllBought(uid, "0");

        rptrsold.DataSource = dataTable;

        rptrsold.DataBind();
    }

    public void getAllBoughtDelevered()
    {
        SoldDAO sold = new SoldDAO();

        String uid = Session["UID"].ToString();

        DataTable dataTable = sold.getAllBought(uid, "1");

        rptrsold.DataSource = dataTable;

        rptrsold.DataBind();
    }

    protected void btnCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Cart.aspx");
    }
}