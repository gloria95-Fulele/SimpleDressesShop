using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Product : System.Web.UI.Page
{
   public string LinkStatus { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }
    private void FillPage()
    {
        //Get selected product data
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ProductModel productModel = new ProductModel();
            Product product = productModel.GetProduct(id);


            //Fill page with data
            lblTitle.Text = product.Name;
            lblDescription.Text = product.Description;
            lblPrice.Text = "Price per unit:<br/>R " + product.Price;
            imgProduct.ImageUrl = "~/Images/Products/" + product.Image;
            lblItemNumber.Text = product.ID.ToString();

            //Fill amount list with numbers 1-20
            int[] amount = Enumerable.Range(1, 20).ToArray();
            ddlAmount.DataSource = amount;
            ddlAmount.AppendDataBoundItems = true;
            ddlAmount.DataBind();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            string clientId = Context.User.Identity.GetUserId();
            if (clientId != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
            int amount = Convert.ToInt32(ddlAmount.SelectedValue);

            Chart cart = new Chart
            {
                Amount = amount,
                ClientID = "",
                DatePurchased = DateTime.Now.ToUniversalTime(),
                IsInChart = true,
                ProductID = id
            }
            ;
            Carts cartmodel = new Carts();
            lblResult.Text = cartmodel.InsertCart(cart);
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(LinkStatus);
            mail.From = new MailAddress("tsholofulela@gmail.com", "Email head", System.Text.Encoding.UTF8);
            mail.Subject = "Purchased";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = lblResult.Text;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("tsholofulela@gmail.com", "19920402");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
                try
                {
                    client.Send(mail);

                }
                catch (Exception ex)
                {
                    Exception ex2 = ex;
                    string errorMessage = string.Empty;
                    while (ex2 != null)
                    {
                        errorMessage += ex2.ToString();
                        ex2 = ex2.InnerException;
                    }
                }
            }
        }
    }
}