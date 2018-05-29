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

    protected void gVYazarlar_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gVYazarlar.SelectedRow;
        Session["secilenYazarID"] = row.Cells[1].Text;

        string query = string.Format("SELECT YazarID,AdSoyad,DogumTarihi,DogumYeri FROM " +
                                 "Yazarlar WHERE AdSoyad LIKE '%{0}%';", txtYazarAra.Text);
        VerileriCek(query);
        Response.Redirect("YazarDetay.aspx");
    }

    protected void txtYazarAra_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //Textbox içerisindeki veri, veritabanında herhangi bir yazar adı
            //içerisinde bulunursa o yazarlar listelenir.
            string query = string.Format("SELECT YazarID,AdSoyad,DogumTarihi,DogumYeri FROM " +
                                 "Yazarlar WHERE AdSoyad LIKE '%{0}%';", txtYazarAra.Text);
            VerileriCek(query);

            GridViewRow row = gVYazarlar.SelectedRow;
            Session["secilenYazarID"] = row.Cells[1].Text;
        }
        catch
        {
        }
    }

    protected void gVYazarlar_Init(object sender, EventArgs e)
    {
        VerileriCek("SELECT YazarID,AdSoyad,DogumTarihi,DogumYeri FROM Yazarlar");
    }

    public void VerileriCek(string query)
    {
        gVYazarlar.DataSource = db.GetDataSet(query).Tables[0];
        gVYazarlar.DataBind();
    }
}