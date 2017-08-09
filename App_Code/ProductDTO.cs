using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AddProductDTO
/// </summary>
public class ProductDTO
{
    private String brand, catagory , name , price, sell_price , quantity , product_details , free_delevery , day_return , cash_on_delevery, brand_id , catagory_id;

    private String product_id, image_name, extention;

    public ProductDTO(String brand,int a)
    {
        this.brand = brand;
    }

    public ProductDTO(String catagory,int a,int b)
    {
        this.catagory = catagory;
    }

    public ProductDTO(String name,String price,String sell_price,String brand_id, String catagory_id, String quantity,String product_details, String free_delevery,String day_return,String cash_on_delevery)
    {
        this.name = name;
        this.price = price;
        this.sell_price = sell_price;
        this.brand_id = brand_id;
        this.catagory_id = catagory_id;
        this.quantity = quantity;
        this.product_details = product_details;
        this.free_delevery = free_delevery;
        this.day_return = day_return;
        this.cash_on_delevery = cash_on_delevery;
    }

    public ProductDTO(String product_id, String image_name, String extention)
    {
        this.product_id = product_id;
        this.image_name = image_name;
        this.extention = extention;
    }


    public String PID
    {
        get { return product_id; }

        set { product_id = value; }
    }


    public String IMAGE_NAME
    {
        get { return image_name; }

        set { image_name = value; }
    }


    public String EXTENTION
    {
        get { return extention; }

        set { extention = value; }
    }

    public String BRAND
    {
        get { return brand; }

        set { brand = value; }
    }

    public String CATAGORY
    {
        get { return catagory; }

        set { catagory = value; }
    }

    public String NAME
    {
        get { return name; }

        set { name = value; }
    }

    public String PRICE
    {
        get { return price; }

        set { price = value; }
    }

    public String SELL_PRICE
    {
        get { return sell_price; }

        set { sell_price = value; }
    }

    public String BRAND_ID
    {
        get { return brand_id; }

        set { brand_id = value; }
    }

    public String CATAGORY_ID
    {
        get { return catagory_id; }

        set { catagory_id = value; }
    }

    public String QUANTITY
    {
        get { return quantity; }

        set { quantity = value; }
    }

    public String PRODUCT_DETAILES
    {
        get { return product_details; }

        set { product_details = value; }
    }

    public String FREE_DELEVERY
    {
        get { return free_delevery; }

        set { free_delevery = value; }
    }

    public String DAY_RETURN
    {
        get { return day_return; }

        set { day_return = value; }
    }

    public String CASH_ON_DELEVERY
    {
        get { return cash_on_delevery; }

        set { cash_on_delevery = value; }
    }

}