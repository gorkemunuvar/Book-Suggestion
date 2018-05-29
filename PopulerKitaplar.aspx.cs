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
            string sart = string.Format("WHERE Adi LIKE '%{0}%';", txtKitapAra.Text);
            DataTable table = PopulerKitaplarDb.PopulerKitaplariCek(sart);
            VerileriCek(table);

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
        DataTable table = PopulerKitaplarDb.PopulerKitaplariCek("");
        VerileriCek(table);
    }

    public void VerileriCek(DataTable table)
    {
        gVKitaplar.DataSource = table;
        gVKitaplar.DataBind();
    }
}