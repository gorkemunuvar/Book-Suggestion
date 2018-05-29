using System;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

public partial class KayitOl : System.Web.UI.Page
{
    string SeciliKitapID = "";
    Database db = new Database();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["adminGirisi"]))
        {
            Session["kullaniciGirisi"] = false;

            //Sayfa DropDown'da ki seçili indexi bu şekilde çekebiliyor.
            if (!IsPostBack)
                VerileriCek();
        }
        else
            Response.Redirect("Giris.aspx");
    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        //Kitap resimleri proje klasöründe isimleri arasında boşluk olmadan saklanır.
        //Resimlerin adını elde etmek için kitap adındaki boşluklar yok edilir.
        string resimAdi = BosluklariSil(txtKitapAdi.Text) + ".png";
        fileUploadFotoYukle.SaveAs(Server.MapPath("Resimler/Kitaplar/" + resimAdi));

        //Kitap bilgileri veritabanına eklenir.
        string query = string.Format("INSERT INTO Kitaplar(Adi,Yazari,YayinEvi,ResimURL,TanitimBilgisi,YazarID) " +
                                     "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', {5})",
                                     txtKitapAdi.Text, dropDownYazarlar.Text, txtYayinEvi.Text, resimAdi,
                                     txtTanitimBilgisi.Value, dropDownYazarlar.SelectedIndex + 1);

        db.ExecuteNonQuery(query);

        lblDurum.Text = "";
        lblSonuc.Text = "Kitap veritabanına eklendi.";

        txtKitapAdi.Text = "";
        txtYayinEvi.Text = "";
        txtTanitimBilgisi.Value = "";

        VerileriCek();
    }

    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        //Seçilen kitap id'sine göre kitap bilgileri güncellenir.
        string query = string.Format("UPDATE Kitaplar SET Adi='{0}',Yazari='{1}',TanitimBilgisi='{2}'," +
                                     "YayinEvi='{3}' WHERE KitapID={4};",
                                     txtKitapAdi.Text, dropDownYazarlar.Text, txtTanitimBilgisi.Value, txtYayinEvi.Text, lblSonuc.Text);

        db.ExecuteNonQuery(query);

        VerileriCek();
        lblDurum.Text = "";
        lblSonuc.Text = "Seçili kitap kaydı güncellendi.";
    }

    protected void btnSil_Click(object sender, EventArgs e)
    {
        //Seçilen kitap bilgileri kitap id'sine göre veritabanından silinir.
        string query = string.Format("DELETE FROM Kitaplar WHERE KitapID={0};", lblSonuc.Text);
        db.ExecuteNonQuery(query);

        VerileriCek();

        //Kitap bilgileriyle birlikte proje klasöründen kitap resmi de silinir.
        string resimUrl = HttpRuntime.AppDomainAppPath + @"\Resimler\Kitaplar\" + BosluklariSil(txtKitapAdi.Text) + ".png";
        FileInfo f = new FileInfo(resimUrl);
        f.Delete();

        lblDurum.Text = "";
        lblSonuc.Text = "Seçili kitap veritabanından silindi.";
    }

    protected void gVKayitliKitaplar_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Gride tıklandığında seçili satırı silmek ya da
        //güncellemek için kitap id'si gridden çekilir.
        GridViewRow row = gVKayitliKitaplar.SelectedRow;
        SeciliKitapID = row.Cells[1].Text;
        lblDurum.Text = "KitapID = ";
        lblSonuc.Text = SeciliKitapID;
    }

    public string BosluklariSil(string metin)
    {
        return string.Join("", metin.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
    }

    public void VerileriCek()
    {
        //Gridde listelenmesi için kayıtlı kitap bilgileri veritabanından çekilir.
        string query = "SELECT KitapID,Adi,Yazari,YayinEvi,TanitimBilgisi FROM Kitaplar";
        gVKayitliKitaplar.DataSource = db.GetDataSet(query).Tables[0];

        gVKayitliKitaplar.DataBind();

        query = "SELECT AdSoyad FROM Yazarlar";

        dropDownYazarlar.DataValueField = "AdSoyad";
        dropDownYazarlar.DataSource = db.GetDataSet(query).Tables[0];
        dropDownYazarlar.DataBind();
    }
}