using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for AddProductDAO
/// </summary>
public class ProductDAO
{
    public ProductDAO()
    {
       
    }


    public DataTable getProduct()
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "SELECT gmart.tblproducts . * , gmart.tblproductimages . * , gmart.tblbrands.Name AS BrandName, gmart.tblproductimages.Name AS ImgName FROM gmart.tblproducts, gmart.tblproductimages, gmart.tblbrands WHERE gmart.tblbrands.BrandID = gmart.tblproducts.PBrandID AND gmart.tblproducts.PID = gmart.tblproductimages.PID AND gmart.tblproductimages.PIMGID %3 =1";

        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlAdapter = new MySqlDataAdapter();

        db.sqlAdapter.SelectCommand = db.sqlCommand;

        DataTable dataTable = new DataTable();

        db.sqlAdapter.Fill(dataTable);

        db.sqlConnection.Close();

        return dataTable;

    }

    public DataTable getProductUnderName(string v)
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "SELECT gmart.tblproducts . * , gmart.tblproductimages . * , gmart.tblbrands.Name AS BrandName, gmart.tblproductimages.Name AS ImgName FROM gmart.tblproducts, gmart.tblproductimages, gmart.tblbrands , gmart.tblcategories WHERE gmart.tblbrands.BrandID = gmart.tblproducts.PBrandID AND gmart.tblproducts.PID = gmart.tblproductimages.PID AND gmart.tblproductimages.PIMGID %3 =1 AND gmart.tblproducts.PCategoryID	= gmart.tblcategories.CatID AND gmart.tblproducts.PName LIKE '%" + v + "%'";

        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlAdapter = new MySqlDataAdapter();

        db.sqlAdapter.SelectCommand = db.sqlCommand;

        DataTable dataTable = new DataTable();

        db.sqlAdapter.Fill(dataTable);

        db.sqlConnection.Close();

        return dataTable;
    }

    public void deleteCategory(int cid)
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "DELETE FROM gmart.tblcategories where gmart.tblcategories.CatID ='" + cid + "'";

        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlCommand.ExecuteNonQuery();

        db.sqlConnection.Close();
    }

    public void deleteBrand(int bid)
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "DELETE FROM gmart.tblbrands where gmart.tblbrands.BrandID ='" + bid + "'";

        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlCommand.ExecuteNonQuery();

        db.sqlConnection.Close();
    }

    public void updateProductQuantity(int i)
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "UPDATE gmart.tblproducts SET gmart.tblproducts.PQuantity = gmart.tblproducts.PQuantity - 1 WHERE gmart.tblproducts.PID = '" + i + "' And gmart.tblproducts.PQuantity > 0";

        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlCommand.ExecuteNonQuery();

        db.sqlConnection.Close();
    }

    public DataTable getProductUnderCat(string v)
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "SELECT gmart.tblproducts . * , gmart.tblproductimages . * , gmart.tblbrands.Name AS BrandName, gmart.tblproductimages.Name AS ImgName FROM gmart.tblproducts, gmart.tblproductimages, gmart.tblbrands , gmart.tblcategories WHERE gmart.tblbrands.BrandID = gmart.tblproducts.PBrandID AND gmart.tblproducts.PID = gmart.tblproductimages.PID AND gmart.tblproductimages.PIMGID %3 =1 AND gmart.tblproducts.PCategoryID	= gmart.tblcategories.CatID AND gmart.tblcategories.CatName LIKE '%" + v + "%'";

        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlAdapter = new MySqlDataAdapter();

        db.sqlAdapter.SelectCommand = db.sqlCommand;

        DataTable dataTable = new DataTable();

        db.sqlAdapter.Fill(dataTable);

        db.sqlConnection.Close();

        return dataTable;
    }

    public DataTable getSelectedProductIMG(int pid)
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "SELECT gmart.tblproducts . * , gmart.tblproductimages . * , gmart.tblbrands.Name AS BrandName, gmart.tblproductimages.Name AS ImgName , gmart.tblcategories.CatName AS CatName FROM gmart.tblproducts, gmart.tblproductimages, gmart.tblbrands ,gmart.tblcategories WHERE gmart.tblbrands.BrandID = gmart.tblproducts.PBrandID AND gmart.tblproducts.PCategoryID = gmart.tblcategories.CatID AND gmart.tblproducts.PID = gmart.tblproductimages.PID AND gmart.tblproducts.PID  ='" + pid + "'";

        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlAdapter = new MySqlDataAdapter();

        db.sqlAdapter.SelectCommand = db.sqlCommand;

        DataTable dataTable = new DataTable();

        db.sqlAdapter.Fill(dataTable);

        db.sqlConnection.Close();

        return dataTable;

    }

    public DataTable getSelectedProductData(int pid)
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "SELECT gmart.tblproducts . * , gmart.tblproductimages . * , gmart.tblbrands.Name AS BrandName, gmart.tblproductimages.Name AS ImgName , gmart.tblcategories.CatName AS CatName FROM gmart.tblproducts, gmart.tblproductimages, gmart.tblbrands ,gmart.tblcategories WHERE gmart.tblbrands.BrandID = gmart.tblproducts.PBrandID AND gmart.tblproducts.PCategoryID = gmart.tblcategories.CatID AND gmart.tblproducts.PID = gmart.tblproductimages.PID AND gmart.tblproductimages.PIMGID %3 =1 AND gmart.tblproducts.PID  ='" + pid + "'";

        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlAdapter = new MySqlDataAdapter();

        db.sqlAdapter.SelectCommand = db.sqlCommand;

        DataTable dataTable = new DataTable();

        db.sqlAdapter.Fill(dataTable);

        db.sqlConnection.Close();

        return dataTable;

    }

    public void addBrand(ProductDTO brand)
    {

        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "INSERT INTO gmart.tblbrands (`Name`) VALUES ('" + brand.BRAND + "')";


        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlCommand.ExecuteNonQuery();

        db.sqlConnection.Close();
    }


    public DataTable getBrand()
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "select * from gmart.tblbrands";

        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlAdapter = new MySqlDataAdapter();

        db.sqlAdapter.SelectCommand = db.sqlCommand;

        DataTable dataTable = new DataTable();

        db.sqlAdapter.Fill(dataTable);

        db.sqlConnection.Close();

        return dataTable;

    }


    public void addCatagory(ProductDTO catagory)
    {

        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "INSERT INTO gmart.tblcategories (`CatName`) VALUES ('" + catagory.CATAGORY + "')";


        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlCommand.ExecuteNonQuery();

        db.sqlConnection.Close();
    }


    public DataTable getCatagory()
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "select * from gmart.tblcategories";

        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlAdapter = new MySqlDataAdapter();

        db.sqlAdapter.SelectCommand = db.sqlCommand;

        DataTable dataTable = new DataTable();

        db.sqlAdapter.Fill(dataTable);

        db.sqlConnection.Close();

        return dataTable;

    }


    public void addProduct(ProductDTO product)
    {

        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "INSERT INTO gmart.tblproducts (`PName`, `PPrice`, `PSellPrice`, `PBrandID`, `PCategoryID`, `PQuantity`, `PProductDetails`, `FreeDelivery`, `3DayReturn`, `COD`) VALUES ('" + product.NAME + "','" + product.PRICE + "','" + product.SELL_PRICE + "','" + product.BRAND_ID + "','" + product.CATAGORY_ID + "','" + product.QUANTITY + "','" + product.PRODUCT_DETAILES + "','" + product.FREE_DELEVERY + "','" + product.DAY_RETURN + "','" + product.CASH_ON_DELEVERY + "')";


        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlCommand.ExecuteNonQuery();

        db.sqlConnection.Close();
    }

    public void addProductImage(ProductDTO product)
    {

        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "INSERT INTO gmart.tblproductimages ( `PID`, `Name`, `Extention`) VALUES ('" + product.PID + "','" + product.IMAGE_NAME + "','" + product.EXTENTION + "')";


        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlCommand.ExecuteNonQuery();

        db.sqlConnection.Close();
    }


    public DataTable getLastProductID()
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "SELECT PID FROM gmart.tblproducts ORDER BY PID DESC LIMIT 1";

        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlAdapter = new MySqlDataAdapter();

        db.sqlAdapter.SelectCommand = db.sqlCommand;

        DataTable dataTable = new DataTable();

        db.sqlAdapter.Fill(dataTable);

        db.sqlConnection.Close();

        return dataTable;

    }

}