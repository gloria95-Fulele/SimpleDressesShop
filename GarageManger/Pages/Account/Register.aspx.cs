using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class Pages_Account_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
        //var connectionString = "source = DESKTOP - DSQM29D\\SQLEXPRESS; initial catalog = SimplyDresses; integrated security = True;";
        userStore.Context.Database.Connection.ConnectionString =
             System.Configuration.ConfigurationManager.
             ConnectionStrings["SimpleDressesEntities3"].ConnectionString;
        var manager = new UserManager<IdentityUser>(userStore);
        string email = txtUserName.Text;
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        if (match.Success)
        { 
            // Create new user and try to store in DB.
            IdentityUser user = new IdentityUser { UserName = txtUserName.Text };

            if (txtPassword.Text == txtConfirmPass.Text)
            {
                try
                {
                    IdentityResult result = manager.Create(user, txtPassword.Text);
                    if (result.Succeeded)
                    {
                        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                        var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                        authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                        Response.Redirect("~/Index.aspx");

                    }
                    else
                    {
                        litStatus.Text = result.Errors.FirstOrDefault();
                    }
                }
                catch (Exception ex)
                {
                    litStatus.Text = ex.ToString();
                }
            }
            else
            {
                litStatus.Text = "Passwords must match!";
            }
        }
        else
        {
            litStatus.Text = "Invalid Email Address!";
        }
    }
}