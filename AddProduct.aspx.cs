using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getAllBrandForDropDown();
            getAllCatagoryForDropDown();
        }
    }


    public void getAllBrandForDropDown()
    {
        ProductDAO productDao = new ProductDAO();

        DataTable dataTable = productDao.getBrand();

        if (dataTable.Rows.Count != 0)
        {
            ddlBrands.DataSource = dataTable;
            ddlBrands.DataTextField = "Name";
            ddlBrands.DataValueField = "BrandID";
            ddlBrands.DataBind();
        }

    }

    public void getAllCatagoryForDropDown()
    {
        ProductDAO productDao = new ProductDAO();

        DataTable dataTable = productDao.getCatagory();

        if (dataTable.Rows.Count != 0)
        {
            ddlCategory.DataSource = dataTable;
            ddlCategory.DataTextField = "CatName";
            ddlCategory.DataValueField = "CatID";
            ddlCategory.DataBind();
        }

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ProductDAO productDao = new ProductDAO();

        //insert Data

        String free_dev = "0";
        String day_ret = "0";
        String cash_on_dev = "0";

        if(cbFD.Checked == true)
        {
            free_dev = "1";
        }

        if(cb30Ret.Checked == true)
        {
            day_ret = "1";
        }

        if (cbCOD.Checked == true)
        {
            cash_on_dev = "1";
        }

        productDao.addProduct(new ProductDTO(txtPName.Text,txtPrice.Text,txtSelPrice.Text,ddlBrands.SelectedItem.Value,ddlCategory.SelectedItem.Value,txtQuantity.Text,txtPDetails.Text,free_dev,day_ret,cash_on_dev));

        


        DataTable dataTable = productDao.getLastProductID();

        int pid = Convert.ToInt32(dataTable.Rows[0][0].ToString());

        //insert & upload image

        
        if (fuImg01.HasFile)
        {

            String SavePath = Server.MapPath("~/Images/ProductImages/") + pid;

            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }

            String Extention = Path.GetExtension(fuImg01.PostedFile.FileName);

            String image_name = txtPName.Text.ToString().Trim() + "01";

            fuImg01.SaveAs(SavePath + "\\" + image_name + Extention);

            productDao.addProductImage(new ProductDTO(pid.ToString(),image_name,Extention));

            
        }

        if (fuImg02.HasFile)
        {

            String SavePath = Server.MapPath("~/Images/ProductImages/") + pid;

            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }

            String Extention = Path.GetExtension(fuImg02.PostedFile.FileName);

            String image_name = txtPName.Text.ToString().Trim() + "02";

            fuImg02.SaveAs(SavePath + "\\" + image_name + Extention);

            productDao.addProductImage(new ProductDTO(pid.ToString(), image_name, Extention));

        }


        if (fuImg03.HasFile)
        {

            String SavePath = Server.MapPath("~/Images/ProductImages/") + pid;

            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }

            String Extention = Path.GetExtension(fuImg03.PostedFile.FileName);

            String image_name = txtPName.Text.ToString().Trim() + "03";

            fuImg03.SaveAs(SavePath + "\\" + image_name + Extention);

            productDao.addProductImage(new ProductDTO(pid.ToString(), image_name, Extention));

        }

        txtPName.Text = "";
        txtPrice.Text = "";
        txtSelPrice.Text = "";
        txtQuantity.Text = "";
        txtPDetails.Text = "";

    }
}