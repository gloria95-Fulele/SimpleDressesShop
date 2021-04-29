using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductTypeTypeModel
/// </summary>
public class ProductTypeTypeModel
{
    public string InsertProductType(ProductType productType)
    {
        try
        {
            SimpleDressesEntities SDE = new SimpleDressesEntities();
            SDE.ProductTypes.Add(productType);
            SDE.SaveChanges();
            return productType.Name + "Successfully Inserted";
        }
        catch (Exception e)
        {
            return "Error" + e;
        }

    }
    public string UpdateProductType(int ID, ProductType productType)
    {
        try
        {
            SimpleDressesEntities SDE = new SimpleDressesEntities();

            //Fetch object from db
            ProductType p = SDE.ProductTypes.Find(ID);
            p.Name = productType.Name;

            SDE.SaveChanges();
            return productType.Name + "Successfully Updated";
        }
        catch (Exception e)
        {
            return "Error" + e;
        }

    }
    public string DeleteProductType(int ID)
    {
        try
        {
            SimpleDressesEntities SDE = new SimpleDressesEntities();
            ProductType p = SDE.ProductTypes.Find(ID);
            SDE.ProductTypes.Attach(p);
            SDE.SaveChanges();

            return p.Name + "Successfully Deleted";
        }
        catch (Exception e)
        {
            return "Error" + e;
        }

    }
}