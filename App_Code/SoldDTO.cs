using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SoldDTO
/// </summary>
public class SoldDTO
{

    private String user_id, num, address, product_id,sold_id;
    public SoldDTO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public SoldDTO(String sold_id, String product_id)
    {
        this.sold_id = sold_id;
       
        this.product_id = product_id;

    }

    

    public SoldDTO(String user_id, String num, String address)
    {
        this.user_id = user_id;
        this.address = address;
        this.num = num;
       
    }

    public String SID
    {
        get { return sold_id; }

        set { sold_id = value; }
    }

    public String PID
    {
        get { return product_id; }

        set { product_id = value; }
    }


    public String UID
    {
        get { return user_id; }

        set { user_id = value; }
    }


    public String NUM
    {
        get { return num; }

        set { num = value; }
    }


    public String ADDRESS
    {
        get { return address; }

        set { address = value; }
    }
}