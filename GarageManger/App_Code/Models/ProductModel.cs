using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductModel
/// </summary>
public class ProductModel
{
    public string InsertProduct(Product product)
    {
        try
        {
            SimpleDressesEntities SDE = new SimpleDressesEntities();
            SDE.Products.Add(product);
            SDE.SaveChanges();
            return product.Name + "Successfully Inserted";
        }
        catch(Exception e)
        {
            return "Error" + e;
        }

    }
    public string UpdateProduct(int ID, Product product)
    {
        try
        {
            SimpleDressesEntities SDE = new SimpleDressesEntities();

            //Fetch object from db
            Product p = SDE.Products.Find(ID);
            p.Name = product.Name;
            p.Price = product.Price;
            p.TypeID = product.TypeID;
            p.Description = product.Description;
            p.Image = product.Image;

            SDE.SaveChanges();
            return product.Name + "Successfully Updated";
        }
        catch (Exception e)
        {
            return "Error" + e;
        }

    }
    public string DeleteProduct(int ID)
    {
        try
        {
            SimpleDressesEntities SDE = new SimpleDressesEntities();
            Product p = SDE.Products.Find(ID);
            SDE.Products.Attach(p);
            SDE.SaveChanges();

            return p.Name + "Successfully Deleted";
        }
        catch (Exception e)
        {
            return "Error" + e;
        }

    }
    public Product GetProduct(int id)

    {
        try
        {
            using (SimpleDressesEntities sd = new SimpleDressesEntities())
            {
                Product product = sd.Products.Find(id);
                return product;
            }
        }
        catch(Exception)
        {
            return null;
        }
    }
    public List<Product> GetAllProducts()
    {
        try
        {
           using (SimpleDressesEntities sd = new SimpleDressesEntities())
                {
                List<Product> products = (from x in sd.Products select x).ToList();
                return products;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
    private List<Product> GetProductsByType(int Typeid)
    {
        try
        {
            using (SimpleDressesEntities sd = new SimpleDressesEntities())
            {
                List<Product> products = (from x in sd.Products where x.TypeID==Typeid  select x).ToList();
                return products;
             }
        }
        catch (Exception)
        {
            return null;
        }
    }
}