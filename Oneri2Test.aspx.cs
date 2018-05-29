using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class a : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string girenKullanici = Session["girenKullaniciAdi"].ToString();

        DataSet ds = Oneri2.KullanicilariCek(girenKullanici);

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

        //for (int i = 0; i < test.Count; i++)
          //  Response.Write(test[i] + "</br>");
    }
}