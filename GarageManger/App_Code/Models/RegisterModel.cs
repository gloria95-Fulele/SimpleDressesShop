using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Register
/// </summary>
public class RegisterModel
{
    public string RegisterUser(Register reg)
    {
        try
        {
            SimpleDressesEntities SDE = new SimpleDressesEntities();
            SDE.Registers.Add(reg);
            SDE.SaveChanges();
            return reg.UserName + "Successfully Inserted";
        }
        catch (Exception e)
        {
            return "Error" + e;
        }

    }
}