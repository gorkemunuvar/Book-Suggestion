using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Database db = new Database();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["kullaniciGirisi"]))
        {
            Session["adminGirisi"] = false;

            VerileriCek();
        }
        else
            Response.Redirect("Giris.aspx");
    }

    protected void btnMesajlarim_Click(object sender, EventArgs e)
    {
        Response.Redirect("Mesajlarim.aspx");
    }

    void VerileriCek()
    {
        KullaniciBilgileriniCek();
        MesajlariCek();
    }

    void KullaniciBilgileriniCek()
    {
        this.Title = Session["girenKullaniciAdi"].ToString();

        string query = string.Format("SELECT Isim,Soyisim,Cinsiyet,DogumTarihi,Mail,KullaniciAdi FROM Kullanicilar");
        SqlDataReader reader = db.GetDataReader(query);

        while (reader.Read())
        {
            if (Session["girenKullaniciAdi"].ToString() == reader["KullaniciAdi"].ToString())
            {
                labelAdi.Text = "<b>Adı</b>: " + reader["Isim"].ToString();
                labelSoyadi.Text = "<b>Soyadi</b>: " + reader["Soyisim"].ToString();
                labelKullaniciAdi.Text = "<b>Kullanıcı Adı</b>: " + reader["KullaniciAdi"].ToString();
                labellDogumTarihi.Text = "<b>Doğum Tarihi</b>: " + reader["DogumTarihi"].ToString();
                labelCinsiyet.Text = "<b>Cinsiyet</b>: " + reader["Cinsiyet"].ToString();
                labelMail.Text = "<b>Mail</b>: " + reader["Mail"].ToString();

                break;
            }
        }

        //Kullanıcı Adı: a.gorkem gibi bir durumda a.gorkem'i ayıklamak için.
        string[] s = labelKullaniciAdi.Text.Split(' ');

        string resimUrl = @"\Resimler\Kullanicilar\" + s[2] + ".png";
        imgKullanici.ImageUrl = resimUrl;

        reader.Close();
        db.Close();
    }

    void MesajlariCek()
    {
        string query = string.Format("SELECT GonderenKullaniciAdi,Mesaj,Tarih FROM Mesajlar WHERE GidenKullaniciAdi='{0}'",
                                     Session["girenKullaniciAdi"].ToString());
        DataSet ds = db.GetDataSet(query);

        gVGelenMesajlar.DataSource = ds.Tables[0];
        gVGelenMesajlar.DataBind();
    }

    protected void gVGelenMesajlar_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gVGelenMesajlar.SelectedRow;
        Session["secilenKullaniciAdi"] = row.Cells[1].Text;

        Response.Redirect("KullaniciProfili.aspx");
    }
}