using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mesajlarim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["kullaniciGirisi"]))
        {
            Session["adminGirisi"] = false;
        }
        else
            Response.Redirect("Giris.aspx");
    }
}