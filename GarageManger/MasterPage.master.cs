using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        var user = Context.User.Identity;
        if (user.IsAuthenticated)
        {
            lnkStatus.Text = Context.User.Identity.Name;

            lnkLogin.Visible = false;
            lnkRegister.Visible = false;
            lnkLogout.Visible = true;
            lnkStatus.Visible = true;

        }
        else
        {
            lnkLogin.Visible = true;
            lnkRegister.Visible = true;
            lnkLogout.Visible = false;
            lnkStatus.Visible = false;
        }
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        authenticationManager.SignOut();
        Response.Redirect("~/Index.aspx");
    }
}
