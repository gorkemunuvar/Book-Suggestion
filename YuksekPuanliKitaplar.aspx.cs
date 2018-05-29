using System;
using System.Data;
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

    protected void gVKitaplar_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gVKitaplar.SelectedRow;
        Session["secilenKitapID"] = row.Cells[1].Text;
        Session["secilenKitapAdi"] = row.Cells[2].Text;

        Response.Redirect("KitapDetay.aspx");
    }

    protected void txtKitapAra_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //Textbox içerisindeki veri veritabanında herhangi bir kitap adı
            //içerisinde bulunursa o kitaplar listelenir.
            string aranan = txtKitapAra.Text;
            VerileriCek(aranan);

            GridViewRow row = gVKitaplar.SelectedRow;
            Session["secilenKitapID"] = row.Cells[1].Text;
            Session["secilenKitapAdi"] = row.Cells[2].Text;
        }
        catch
        {
        }
    }

    protected void gVKitaplar_Init(object sender, EventArgs e)
    {
        VerileriCek("");
    }

    void VerileriCek(string aranan)
    {
        string query = string.Format("SELECT Kitaplar.KitapID, Kitaplar.Adi, Kitaplar.Yazari, Kitaplar.TanitimBilgisi," +
                                     " AVG(dbo.KitapPuan.Puan) FROM Kitaplar INNER JOIN KitapPuan ON Kitaplar.KitapID = KitapPuan.KitapID" +
                                     " WHERE Adi LIKE '%{0}%' GROUP BY dbo.Kitaplar.Adi, Kitaplar.Yazari, Kitaplar.TanitimBilgisi, Kitaplar.KitapID ",
                                     aranan);


        //table.DefaultView.Sort = "Ortalama DESC";
        DataSet ds = new DataSet();
        ds = db.GetDataSet(query);


        gVKitaplar.DataSource = ds.Tables[0];
        gVKitaplar.DataBind();

        db.Close();
    }

    protected void gVKitaplar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[5].Text = "Ortalama";
        }
    }

    protected void gVKitaplar_Sorting(object sender, GridViewSortEventArgs e)
    {
    }

    protected void gVKitaplar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }
}