using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["UNAME"] != null && Request.Cookies["PWD"] != null)
            {
                getAllCatagory();
                UserName.Text = Request.Cookies["UNAME"].Value;
                Password.Attributes["value"] = Request.Cookies["PWD"].Value;
                CheckBox1.Checked = true;

            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        UserDAO userDao = new UserDAO();

        DataTable dataTable = new DataTable();

        dataTable = userDao.getUser(UserName.Text, Password.Text);

        if (dataTable.Rows.Count != 0)
        {
            

            if (CheckBox1.Checked)
            {
                Response.Cookies["UNAME"].Value = UserName.Text;
                Response.Cookies["PWD"].Value = Password.Text;

                Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(15);
                Response.Cookies["PWD"].Expires = DateTime.Now.AddDays(15);

            }
            else
            {
                Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["PWD"].Expires = DateTime.Now.AddDays(-1);
            }

            String userType = dataTable.Rows[0][5].ToString().Trim();

            if (userType == "U")
            {
                Session["USERNAME"] = UserName.Text;
                Session["CARTP"] = new ArrayList();
                Session["UID"] = dataTable.Rows[0][0].ToString();


                Response.Redirect("~/UserHome.aspx?D=0");
            }
            else if(userType == "A")
            {
                Session["USERNAME"] = UserName.Text;
                Response.Redirect("~/AdminHome.aspx?D=0");
            }

        }
        else
        {
            lblError.Text = "Invalid Username or Password !";
        }
    }


    public void getAllCatagory()
    {
        ProductDAO pdao = new ProductDAO();

        DataTable dataTable = pdao.getCatagory();

        RepCat.DataSource = dataTable;

        RepCat.DataBind();

    }

}