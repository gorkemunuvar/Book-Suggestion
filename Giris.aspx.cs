using System;

public partial class Giris : System.Web.UI.Page
{
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        Database db = new Database();

        //Bilgiler YoneticiTanim tablosundaki verilerle eşleşirse kullanıcı yönetici paneline yönlendirilir.
        if (db.LoginControl(txtKullaniciAdi.Text, txtParola.Text, "YoneticiTanim", "KullaniciAdi", "Sifre"))
        {
            Session["adminGirisi"] = true;
            Response.Redirect("YoneticiPaneli.aspx");
        }
        //Bilgiler Kullanicilar tablosundaki verilerle eşleşirse kullanıcı kullanıcı paneline yönlendirilir.
        else if (db.LoginControl(txtKullaniciAdi.Text, txtParola.Text, "Kullanicilar", "KullaniciAdi", "Sifre"))
        {
            Session["kullaniciGirisi"] = true;
            Session["girenKullaniciAdi"] = txtKullaniciAdi.Text;

            Response.Redirect("Tavsiyeler.aspx");
        }
        //Bilgiler hatalı girilmişse
        else
        {
            lblSonuc.Text = "Hatalı kullanıcı adı veya parola.";
            Session["kullaniciGirisi"] = false;
            Session["adminGirisi"] = false;
        }
    }

    protected void btnKayitOl_Click(object sender, EventArgs e)
    {
        Response.Redirect("KayitOl.aspx");
    }
}