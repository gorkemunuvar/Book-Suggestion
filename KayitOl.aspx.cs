using System;

public partial class KayitOl : System.Web.UI.Page
{
    protected void btnKayitOl_Click(object sender, EventArgs e)
    {
        char cinsiyet;
        if (radioErkek.Checked) cinsiyet = 'E';
        else cinsiyet = 'K';

        Database db = new Database();

        //Girilen kullanıcı bilgileri Kullanicilar tablosuna eklenir.
        string query = string.Format("INSERT INTO Kullanicilar(Isim, Soyisim, Cinsiyet, DogumTarihi, KullaniciAdi, Sifre, Mail) VALUES('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
            txtAd.Text, txtSoyad.Text, cinsiyet, txtDogumTarihi.Text, txtKullaniciAdi.Text, txtParolaTekrar.Text, txtMail.Text);
        db.ExecuteNonQuery(query);

        //Kullanıcıların profil fotoğrafı proje klasöründe 'Kullaniciadi.png' formatında saklanır.
        string filename = txtKullaniciAdi.Text + ".png";
        FileUploadFoto.SaveAs(Server.MapPath("Resimler/Kullanicilar/" + filename));

        lblSonuc.Text = txtKullaniciAdi.Text + " sisteme hoşgeldiniz.";
    }
}