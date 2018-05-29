using System;
using System.Data;

public partial class a : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string giren = Session["girenKullaniciAdi"].ToString();

        DataSet ds = Oneri3.Oneri1DenGelenleriCek(giren);

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }
}