using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Carts
/// </summary>
public class Carts
{
    public string InsertCart(Chart cart)
    {
        try
        {
            SimpleDressesEntities SDE = new SimpleDressesEntities();
            SDE.Charts.Add(cart);
            SDE.SaveChanges();
            return cart.DatePurchased + "Successfully Inserted";
        }
        catch (Exception e)
        {
            return "Error" + e;
        }

    }
    public string UpdateCart(int ID, Chart cart)
    {
        try
        {
            SimpleDressesEntities SDE = new SimpleDressesEntities();

            //Fetch object from db
            Chart p = SDE.Charts.Find(ID);
            p.DatePurchased = cart.DatePurchased;
            p.ClientID = cart.ClientID;
            p.Amount = cart.Amount;
            p.IsInChart = cart.IsInChart;
            p.ProductID = cart.ProductID;

            SDE.SaveChanges();
            return cart.DatePurchased + "Successfully Updated";
        }
        catch (Exception e)
        {
            return "Error" + e;
        }

    }
    public string DeleteCart(int ID)
    {
        try
        {
            SimpleDressesEntities SDE = new SimpleDressesEntities();
            Chart p = SDE.Charts.Find(ID);
            SDE.Charts.Attach(p);
            SDE.SaveChanges();

            return p.DatePurchased + "Successfully Deleted";
        }
        catch (Exception e)
        {
            return "Error" + e;
        }

    }
}