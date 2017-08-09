using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;

public partial class SignUp : System.Web.UI.Page
{
    UserDAO userDao = new UserDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        getAllCatagory();
    }

    protected void btSignup_Click(object sender, EventArgs e)
    {
        

        if (tbUname.Text != "" & tbPass.Text != "" && tbName.Text != "" && tbEmail.Text != "" && tbCPass.Text != "")
        {
            if (tbPass.Text == tbCPass.Text)
            {
                userDao.createUser(new UserDTO(tbUname.Text, tbPass.Text, tbName.Text, tbEmail.Text));
    
                Response.Redirect("~/Signin.aspx");
                
            }
            else
            {
                show.ForeColor = Color.Red;
                show.Text = "Passwords do not match";
            }

        }
        else
        {
            show.ForeColor = Color.Red;
            show.Text = "All Fields Are Mandatory";
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