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
            this.Title = Session["girenKullaniciAdi"].ToString();
            VerileriCek();

            //Kitap önceden herhangi biri tarafından puanlanmışsa 'ortalama puan' çekilir.
            if (KitapPuanlamaKontrol())
                OrtalamayiCek();
            else
                labelOrtalamaPuan.Text = "Kitap henüz puanlanmadı.";

            //Kitap giren kullanıcı tarafından okunmuşsa
            if (KitapOkunmaKontrol())
            {
                btnOkudum.Text = "Kitabı Okudunuz";

                //Kitap önceden giriş yapan kullanıcı tarafından puanlanmışsa.
                if (KullaniciPuanlamaKontrol())
                {
                    btnPuanVer.Enabled = true;
                    btnPuanVer.Text = "Puanı Değiştir";
                    txtPuan.Enabled = true;
                }
            }
            //Kitap giren kullanıcı tarafından okunmamışsa
            else
            {
                btnOkudum.Text = "Okudum";
                btnPuanVer.Enabled = false;
                txtPuan.Enabled = false;
            }
        }
        else
            Response.Redirect("Giris.aspx");
    }
   
    protected void btnOkudum_Click(object sender, EventArgs e)
    {
        string query = "";

        //Okunma işlemi geri alınırsa
        if (btnOkudum.Text == "Kitabı Okudunuz")
        {
            btnOkudum.Text = "Okudum";
            labelSonuc.Text = "";
            btnPuanVer.Text = "Puan Ver";
            txtPuan.Text = "";

            btnPuanVer.Enabled = false;
            txtPuan.Enabled = false;

            //KitapOkunma tablosundan kitap verileri silinir.
            query = string.Format("DELETE KitapOkunma WHERE KitapID={0} AND KullaniciAdi='{1}'",
                                         Session["secilenKitapID"].ToString(), Session["girenKullaniciAdi"].ToString());
            db.ExecuteNonQuery(query);

            //Önceden kitap puanlanmışsa, okunma işlemi geri
            //alınacağından puanlama bilgiside veritabanından silinmeli.
            if (KitapPuanlamaKontrol())
            {
                query = string.Format("DELETE KitapPuan WHERE KitapID = {0} AND KullaniciAdi='{1}'",
                                             Session["secilenKitapID"].ToString(), Session["girenKullaniciAdi"].ToString());
                db.ExecuteNonQuery(query);
            }

            KitapOkunmaSayisiniCek();
            OrtalamayiCek();
        }
        //Kitap okundu olarak işaretlenirse
        else
        {
            //Kitabın puanlanabileceğine dair bilgi verilir.
            btnOkudum.Text = "Kitabı Okudunuz";
            labelSonuc.Text = "1-10 arasnıda kitabı puanlayabilirsiniz.";
            btnPuanVer.Enabled = true;
            txtPuan.Enabled = true;

            //KitapOkunma tablosuna kitap verisi eklenir.
            query = string.Format("INSERT INTO KitapOkunma(KitapID,KullaniciAdi) VALUES({0},'{1}')",
                                             Session["secilenKitapID"].ToString(), Session["girenKullaniciAdi"]);
            db.ExecuteNonQuery(query);

            KitapOkunmaSayisiniCek();
        }
    }

    protected void btnPuanVer_Click(object sender, EventArgs e)
    {
        string query = "";

        //Kullanıcı kitaba hiç puan vermemişse.
        if (btnPuanVer.Text == "Puan Ver")
        {
            //KitapPuan tablosuna girilen puan verisi eklenir.
            query = string.Format("INSERT INTO KitapPuan(KullaniciAdi,KitapID,Puan) VALUES('{0}',{1},{2})",
                                     Session["girenKullaniciAdi"].ToString(),
                                     Session["secilenKitapID"].ToString(),
                                     txtPuan.Text);
            db.ExecuteNonQuery(query);

            //Kitabın puanlandığına dair bilgi verilir.
            labelSonuc.Text = "Kitap puanlandı.";
            btnPuanVer.Text = "Puan Değiştir";
        }
        //Kullanıcı önceden kitabı puanlamışsa
        else
        {
            //Veritabanındaki puan güncellenir.
            query = string.Format("UPDATE KitapPuan SET Puan={0} WHERE KitapID={1} AND KullaniciAdi='{2}'",
                                         txtPuan.Text, Session["secilenKitapID"].ToString(), Session["girenKullaniciAdi"]);
            db.ExecuteNonQuery(query);
            labelSonuc.Text = "Puan değiştirildi.";
        }

        OrtalamayiCek();
    }

    protected void btnInceleme_Click(object sender, EventArgs e)
    {
        KitapDetayDb.AddBookReview(Session["secilenKitapID"].ToString(),
                                   Session["girenKullaniciAdi"].ToString(),
                                   txtInceleme.Text);

        KitapIncelemeleriniCek();
        txtInceleme.Text = "";
    }

    protected void btnAlintiEkle_Click(object sender, EventArgs e)
    {
        KitapDetayDb.AddQuote(Session["secilenKitapID"].ToString(),
                                  Session["girenKullaniciAdi"].ToString(),
                                  txtSayfa.Text,
                                  txtAlinti.Text);

        KitapAlintilariniCek();
        txtAlinti.Text = "";
    }





    void VerileriCek()
    {
        this.Title = Session["secilenKitapAdi"].ToString();

        KitapBilgileriniCek();
        KitapIncelemeleriniCek();
        KitapAlintilariniCek();
    }

    void KitapBilgileriniCek()
    {
        string url = "";
        string query = string.Format("SELECT * FROM Kitaplar");
        SqlDataReader reader = db.GetDataReader(query);

        while (reader.Read())
        {
            if (Session["secilenKitapID"].ToString() == reader["KitapID"].ToString())
            {
                labelKitapAdi.Text = "<b>Kitap Adı</b>: " + reader["Adi"].ToString();
                labelYazar.Text = "<b>Yazarı</b>: " + reader["Yazari"].ToString();
                labelYayinEvi.Text = "<b>Yayın Evi</b>: " + reader["Yayinevi"].ToString();
                labelTanitim.Text = "<b>Tanıtımı</b>: " + reader["TanitimBilgisi"].ToString();
                Session["secilenKitapID"] = reader["KitapID"].ToString();
                url = reader["resimUrl"].ToString();

                break;
            }
        }

        reader.Close();
        db.Close();

        KitapOkunmaSayisiniCek();

        //Resimler proje klasöründe 'Kitapadi.png' şeklinde saklanır.
        string resimUrl = @"\Resimler\Kitaplar\" + url;
        imgKitap.ImageUrl = resimUrl;
    }

    void KitapOkunmaSayisiniCek()
    {
        //Not: ExecuteScalar() fonk. nun çalışması için öncelikle açılan reader kapatılmalı.
        string query = string.Format("SELECT COUNT(*) FROM KitapOkunma WHERE KitapID={0}", Session["secilenKitapID"].ToString());
        labelOkunmaSayisi.Text = "<b>Okunma Sayısı: </b>" + db.RowCount(query).ToString();
    }

    void OrtalamayiCek()
    {
        int kitapID = int.Parse(Session["secilenKitapID"].ToString());
        float ortalama = KitapDetayDb.GetAverageScore(kitapID);

        labelOrtalamaPuan.Text = "<b>Ortlama Puan: </b>" + Math.Round(ortalama, 1);
    }

    bool KitapOkunmaKontrol()
    {
        string query = "SELECT * FROM KitapOkunma";
        SqlDataReader reader = db.GetDataReader(query);

        bool sonuc = false;
        while (reader.Read())
            if (Session["secilenKitapID"].ToString() == reader["KitapID"].ToString() &&
                Session["girenKullaniciAdi"].ToString() == reader["KullaniciAdi"].ToString())
                sonuc = true;

        reader.Close();
        db.Close();

        return sonuc;
    }

    bool KitapPuanlamaKontrol()
    {
        string query = "SELECT * FROM KitapPuan";
        SqlDataReader reader = db.GetDataReader(query);

        bool sonuc = false;
        while (reader.Read())
            if (Session["secilenKitapID"].ToString() == reader["KitapID"].ToString())
                sonuc = true;

        reader.Close();
        db.Close();

        return sonuc;
    }

    bool KullaniciPuanlamaKontrol()
    {
        string query = "SELECT * FROM KitapPuan";
        SqlDataReader reader = db.GetDataReader(query);

        bool sonuc = false;
        while (reader.Read())
            if (Session["secilenKitapID"].ToString() == reader["KitapID"].ToString() &&
                Session["girenKullaniciAdi"].ToString() == reader["KullaniciAdi"].ToString())
                sonuc = true;

        reader.Close();
        db.Close();

        return sonuc;
    }

    void KitapAlintilariniCek()
    {
        string query = string.Format("SELECT KullaniciAdi,SayfaNo,Cumle FROM KitapAlinti WHERE KitapID={0}",
                                     Session["secilenKitapID"].ToString());
        gVAlintilar.DataSource = db.GetDataSet(query).Tables[0];
        gVAlintilar.DataBind();
    }

    void KitapIncelemeleriniCek()
    {
        string query = string.Format("SELECT KullaniciAdi,Inceleme FROM KitapInceleme WHERE KitapID={0}",
                                     Session["secilenKitapID"].ToString());
        gVIncelemeler.DataSource = db.GetDataSet(query).Tables[0];
        gVIncelemeler.DataBind();
    }
}