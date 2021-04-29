using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Startup1))]

public class Startup1
{
    public void Configuration(IAppBuilder app)
    {
        app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
        {
            AuthenticationType= DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath= new PathString("/Pages/Account/Login.aspx")
        });
    }
}
