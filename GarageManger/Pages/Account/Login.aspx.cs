using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
        //var connectionString = "source = DESKTOP - DSQM29D\\SQLEXPRESS; initial catalog = SimpleDresses; integrated security = True";
            userStore.Context.Database.Connection.ConnectionString =
            System.Configuration.ConfigurationManager.
            ConnectionStrings["SimpleDressesEntities3"].ConnectionString;

        UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

        var user = manager.Find(txtUserName.Text, txtPassword.Text);

        if (user != null)
        {
            //Call OWIN functionality
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            //Sign in user
            authenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = false
            }, userIdentity);

            //Redirect user to homepage
            Response.Redirect("~/Index.aspx");
        }
        else
        {
            litStatus.Text = "Invalid username or password";
        }
    }
}