using System;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Database db = new Database();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["kullaniciGirisi"]))
        {
            Session["adminGirisi"] = false;
        }
        else
            Response.Redirect("Giris.aspx");
    }

    protected void gVKullanicilar_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gVKullanicilar.SelectedRow;
        Session["secilenKullaniciAdi"] = row.Cells[1].Text;

        string query = string.Format("SELECT KullaniciAdi,Isim,Soyisim,Cinsiyet,Mail FROM " +
                                "Kullanicilar WHERE KullaniciAdi LIKE '%{0}%';", txtKullaniciAra.Text);
        VerileriCek(query);
        Response.Redirect("KullaniciProfili.aspx");
    }

    protected void txtKullaniciAra_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //Textbox içerisindeki veri, veritabanında herhangi bir kullanıcı adı
            //içerisinde bulunursa o kullanıcılar listelenir.
            string query = string.Format("SELECT KullaniciAdi,Isim,Soyisim,Cinsiyet,Mail FROM " +
                                 "Kullanicilar WHERE KullaniciAdi LIKE '%{0}%';", txtKullaniciAra.Text);
            VerileriCek(query);

            GridViewRow row = gVKullanicilar.SelectedRow;
            
            Session["secilenKullaniciAdi"] = row.Cells[1].Text;
        }
        catch
        {
        }
    }

    protected void gVKullanicilar_Init(object sender, EventArgs e)
    {
        VerileriCek("SELECT KullaniciAdi,Isim,Soyisim,Cinsiyet,Mail FROM Kullanicilar");
    }
    public void VerileriCek(string query)
    {
        gVKullanicilar.DataSource = db.GetDataSet(query).Tables[0];
        gVKullanicilar.DataBind();
    }
}