using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_management_managementOfProductTypes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ProductTypeTypeModel model = new ProductTypeTypeModel();
        ProductType PT = CreateProductType();
        lblResults.Text = model.InsertProductType(PT);
    }
    private ProductType CreateProductType()
    {
        ProductType pT = new ProductType();
        pT.Name = txtboxName.Text;

        return pT;
    }
}