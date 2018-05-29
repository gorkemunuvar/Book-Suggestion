using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

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

    protected void gVYazaraAitKitaplar_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gVYazaraAitKitaplar.SelectedRow;
        Session["secilenKitapID"] = row.Cells[1].Text;
        Session["secilenKitapAdi"] = row.Cells[2].Text;

        Response.Redirect("KitapDetay.aspx");
    }

    public void VerileriCek()
    {
        YazarBilgileriniCek();
        YazarKitaplariniCek();
    }

    public void YazarBilgileriniCek()
    {
        string query = string.Format("SELECT * FROM Yazarlar");
        SqlDataReader reader = db.GetDataReader(query);

        while (reader.Read())
        {
            if (Session["secilenYazarID"].ToString() == reader["YazarID"].ToString())
            {
                lableAdSoyad.Text = "<b>Adı</b>: " + reader["AdSoyad"].ToString();
                labelDogumYeri.Text = "<b>Doğum Yeri</b>: " + reader["DogumYeri"].ToString();
                labelDogumTarihi.Text = "<b>Doğum Tarihi</b>: " + reader["DogumTarihi"].ToString();
                labelOlumTarihi.Text = "<b>Ölüm Tarihi</b> " + reader["OlumTarihi"].ToString();

                break;
            }
        }

        reader.Close();
        db.Close();
    }

    void YazarKitaplariniCek()
    {
        string query = "SELECT KitapID,Adi,YayinEvi,TanitimBilgisi FROM Kitaplar WHERE YazarID = " + Session["secilenYazarID"];

        gVYazaraAitKitaplar.DataSource = db.GetDataSet(query).Tables[0];
        gVYazaraAitKitaplar.DataBind();
    }

    
}