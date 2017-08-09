using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for UserDAO
/// </summary>
public class UserDAO
{
    

    public UserDAO()
    {
        
    }

    public void createUser(UserDTO userDto)
    {

        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "INSERT INTO gmart.userinfo ( `username`, `password`, `email`, `name`, `usertype`) VALUES ('" + userDto.USERNAME + "','"
                                                                + userDto.PASSWORD + "','"
                                                                + userDto.EMAIL + "','"
                                                                + userDto.NAME + "', 'U')";


        System.Diagnostics.Debug.WriteLine(query);

        db.sqlCommand = new MySqlCommand(query, db.sqlConnection);

        db.sqlCommand.ExecuteNonQuery();

        db.sqlConnection.Close();
    }

    public DataTable getUser(String name,String pass)
    {
        DbConnect db = new DbConnect();

        db.sqlConnection.Open();

        String query = "select * from gmart.userinfo where `username` = '" + name + "' and  `password` = '" + pass + "'";

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

