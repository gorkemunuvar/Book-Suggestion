using System;
using System.Data;

public partial class _Default : System.Web.UI.Page
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

    protected void gVOnerilenKitaplar_Init(object sender, EventArgs e)
    {
        string girenKullaniciAdi = Session["girenKullaniciAdi"].ToString();

        if (Oneri3.KitapIDleriniCek(girenKullaniciAdi).Count != 0)
        {
            DataSet ds = Oneri3.Onerilenler(girenKullaniciAdi);

            gVOnerilenKitaplar.DataSource = ds.Tables[0];
            gVOnerilenKitaplar.DataBind();
        }
        else
            lblSonuc.Text = "Sisteme hoş geldiniz. Öneri sistemi hesap hareketlerinize göre çalıcaktır. Bol şans :)";
    }
}