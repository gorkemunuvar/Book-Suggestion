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
        string giren = Session["girenKullaniciAdi"].ToString();
        /*List<int> test = Oneri1.Okuduklari(giren);

        for (int i = 0; i < test.Count; i++)
            Response.Write(test[i] + "</br>");

        string s = Oneri1.IDleriBirlestir(test);

        Response.Write("</br>" + s);*/

        DataSet ds = Oneri1.OrtakOkunmaSayilariniCek(giren);
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

    }
}