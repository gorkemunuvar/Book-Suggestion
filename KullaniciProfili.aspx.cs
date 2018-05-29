using System;
using System.Data.SqlClient;

public partial class KitapDetay : System.Web.UI.Page
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

    void VerileriCek()
    {
        KullaniciBilgileriniCek();
        OkuduguKitaplariCek();
        VerdigiPuanlariCek();
        IncelemeleriCek();
        AlintilariCek();
    }

    void KullaniciBilgileriniCek()
    {
        this.Title = Session["secilenKullaniciAdi"].ToString();

        string query = string.Format("SELECT Isim,Soyisim,Cinsiyet,DogumTarihi,Mail,KullaniciAdi FROM Kullanicilar");
        SqlDataReader reader = db.GetDataReader(query);

        while (reader.Read())
        {
            if (Session["secilenKullaniciAdi"].ToString() == reader["KullaniciAdi"].ToString())
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

    void OkuduguKitaplariCek()
    {
        string query = string.Format("SELECT Kitaplar.KitapID, Kitaplar.Adi, Kitaplar.Yazari FROM Kitaplar INNER JOIN KitapOkunma ON " +
                                     "Kitaplar.KitapID = KitapOkunma.KitapID WHERE KitapOkunma.KullaniciAdi='{0}';",
                                     Session["secilenKullaniciAdi"].ToString());

        gVKitaplar.DataSource = db.GetDataSet(query).Tables[0];
        gVKitaplar.DataBind();
    }

    void VerdigiPuanlariCek()
    {
        string query = string.Format("SELECT KitapPuan.Puan, Kitaplar.Adi FROM Kitaplar INNER JOIN KitapPuan ON " +
                                     "Kitaplar.KitapID = KitapPuan.KitapID WHERE KitapPuan.KullaniciAdi='{0}'",
                                     Session["secilenKullaniciAdi"].ToString());
        gVVerdigiPuanlar.DataSource = db.GetDataSet(query).Tables[0];
        gVVerdigiPuanlar.DataBind();

    }

    void IncelemeleriCek()
    {
        string query = string.Format("SELECT Kitaplar.Adi, KitapInceleme.Inceleme FROM Kitaplar INNER JOIN KitapInceleme ON " +
                                     "Kitaplar.KitapID = KitapInceleme.KitapID WHERE KitapInceleme.KullaniciAdi='{0}'",
                                     Session["secilenKullaniciAdi"].ToString());
        gVIncelemeVeYorumlari.DataSource = db.GetDataSet(query).Tables[0];
        gVIncelemeVeYorumlari.DataBind();
    }

    void AlintilariCek()
    {
        string query = string.Format("SELECT Kitaplar.Adi, KitapAlinti.SayfaNo, KitapAlinti.Cumle FROM Kitaplar INNER JOIN KitapAlinti ON " +
                                     "Kitaplar.KitapID = KitapAlinti.KitapID WHERE KitapAlinti.KullaniciAdi='{0}'",
                                     Session["secilenKullaniciAdi"].ToString());
        gVYaptigiAlintilar.DataSource = db.GetDataSet(query).Tables[0];
        gVYaptigiAlintilar.DataBind();
    }

    protected void btnMesajGonder_Click(object sender, EventArgs e)
    {
        try
        {
            string gonderenKullanici = Session["girenKullaniciAdi"].ToString();
            string gidenKullanici = Session["secilenKullaniciAdi"].ToString();
            string baslik = txtBaslik.Text;
            string mesaj = txtAreaMesaj.Value;
            string tarih = DateTime.Now.Date.ToShortDateString();

            db.Open();

            string query = "INSERT INTO [Mesajlar](GonderenKullaniciAdi, GidenKullaniciAdi, Baslik, Mesaj, Tarih) " +
                           "VALUES(@gonderenK, @gidenK, @baslik, @mesaj, @tarih)";

            SqlCommand command = new SqlCommand(query, db.conn);

            command.Parameters.AddWithValue("@gonderenK", gonderenKullanici);
            command.Parameters.AddWithValue("@gidenK", gidenKullanici);
            command.Parameters.AddWithValue("@baslik", baslik);
            command.Parameters.AddWithValue("@mesaj", mesaj);
            command.Parameters.AddWithValue("@tarih", tarih.ToString());

            command.ExecuteNonQuery();

            db.Close();

            labelSonuc.Text = "Mesajınız gönderildi.";
        }
        catch
        {
            labelSonuc.Text = "Mesajınız gönderilemedi.";
        }
    }
}