using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["D"] != null)
        {
            int d = Convert.ToInt32(Request.QueryString["D"]);

            if (d == 0)
            {
                lblSuccess.Text = "Order List";
                getAllSolds("0");
            }
            else
            {
                lblSuccess.Text = "Delevered List";
                getAllSolds("1");
            }
        }

    }

    public void getAllSolds(String k)
    {
        SoldDAO sold = new SoldDAO();

        DataTable dataTable = sold.getSold(k);

        rptrsold.DataSource = dataTable;

        rptrsold.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminHome.aspx?D=1");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminHome.aspx?D=0");
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

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("HERE");

        LinkButton btn = (LinkButton)(sender);

        System.Diagnostics.Debug.WriteLine(btn.CommandArgument);

        int sid = Convert.ToInt32(btn.CommandArgument.ToString());

        SoldDAO sold = new SoldDAO();

        sold.updateSold(sid);

        Response.Redirect("~/AdminHome.aspx?D=0");

    }

    



}