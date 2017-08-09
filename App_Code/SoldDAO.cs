using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for SoldDAO
/// </summary>
public class SoldDAO
{
    public SoldDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public void addSold(SoldDTO s)
    {

        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "INSERT INTO gmart.tblsold ( `uid`, `date`, `num`, `add`, `done`) VALUES ('" + s.UID + "',CURRENT_TIMESTAMP() ,'" + s.NUM + "','" + s.ADDRESS + "',0)";


        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlCommand.ExecuteNonQuery();

        db.sqlConnection.Close();
    }

    public DataTable getSold(String k)
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "SELECT * FROM  gmart.tblsold WHERE gmart.tblsold.done = '" + k + "'";

        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlAdapter = new MySqlDataAdapter();

        db.sqlAdapter.SelectCommand = db.sqlCommand;

        DataTable dataTable = new DataTable();

        db.sqlAdapter.Fill(dataTable);

        db.sqlConnection.Close();

        return dataTable;
    }

    public DataTable getAllBought(String uid,String k)
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "SELECT * FROM  gmart.tblsold WHERE gmart.tblsold.done = '" + k + "' AND gmart.tblsold.uid = '" + uid + "'";

        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlAdapter = new MySqlDataAdapter();

        db.sqlAdapter.SelectCommand = db.sqlCommand;

        DataTable dataTable = new DataTable();

        db.sqlAdapter.Fill(dataTable);

        db.sqlConnection.Close();

        return dataTable;
    }

    public void updateSold(int sid)
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "UPDATE gmart.tblsold SET gmart.tblsold.done = 1 WHERE sid = '" + sid + "'";


        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlCommand.ExecuteNonQuery();

        db.sqlConnection.Close();
    }

    public DataTable getSoldItem(int sid)
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "SELECT gmart.tblproducts.PID, gmart.tblproducts.PName FROM gmart.tblproducts, gmart.tblsolditem WHERE gmart.tblsolditem.pid = gmart.tblproducts.PID AND gmart.tblsolditem.sid = '" + sid + "'";

        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlAdapter = new MySqlDataAdapter();

        db.sqlAdapter.SelectCommand = db.sqlCommand;

        DataTable dataTable = new DataTable();

        db.sqlAdapter.Fill(dataTable);

        db.sqlConnection.Close();

        return dataTable;
    }

    public String getlastSID()
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "SELECT * FROM gmart.tblsold ORDER BY `sid` DESC LIMIT 1;";

        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlAdapter = new MySqlDataAdapter();

        db.sqlAdapter.SelectCommand = db.sqlCommand;

        DataTable dataTable = new DataTable();

        db.sqlAdapter.Fill(dataTable);

        db.sqlConnection.Close();

        return dataTable.Rows[0][0].ToString();
    }

    public void addSoldItems(SoldDTO s)
    {

        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "INSERT INTO gmart.tblsolditem VALUES ('" + s.SID + "','" + s.PID + "')";


        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlCommand.ExecuteNonQuery();

        db.sqlConnection.Close();
    }





}