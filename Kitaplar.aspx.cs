using System;
using System.Collections;
using System.Collections.Generic;
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
            string query = string.Format("SELECT KitapID,Adi,Yazari,YayinEvi,TanitimBilgisi FROM " +
                                "Kitaplar WHERE Adi LIKE '%{0}%';", txtKitapAra.Text);
            VerileriCek(query);

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
        VerileriCek("SELECT KitapID,Adi,Yazari,YayinEvi,TanitimBilgisi FROM Kitaplar");
    }

    public void VerileriCek(string query)
    {
        gVKitaplar.DataSource = db.GetDataSet(query).Tables[0];
        gVKitaplar.DataBind();
    }

    protected void btnTumKitaplar_Click(object sender, EventArgs e)
    {
        VerileriCek("SELECT KitapID,Adi,Yazari,YayinEvi,TanitimBilgisi FROM Kitaplar");
    }

}