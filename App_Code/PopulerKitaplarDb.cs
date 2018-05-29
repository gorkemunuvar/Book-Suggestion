using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class PopulerKitaplarDb
{
    static Database db = new Database();

    static public List<int> KitapIDleriniCek()
    {
        List<int> kitapIDleri = new List<int>();

        string query = "SELECT DISTINCT(KitapID) FROM KitapOkunma;";
        SqlDataReader reader = db.GetDataReader(query);

        while (reader.Read())
        {
            int kitapID = int.Parse(reader["KitapID"].ToString());
            kitapIDleri.Add(kitapID);
        }

        db.Close();
        return kitapIDleri;
    }

    static public Hashtable KitapBilgileriniCek()
    {
        Hashtable kitapBilgileri = new Hashtable();

        List<int> kitapIDleri = KitapIDleriniCek();
        for (int i = 0; i < kitapIDleri.Count; i++)
        {
            string sorgu = string.Format("SELECT COUNT(*) FROM KitapOkunma WHERE KitapID={0}", kitapIDleri[i]);
            int okunmaSayisi = db.RowCount(sorgu);
            kitapBilgileri[kitapIDleri[i]] = okunmaSayisi;
        }

        db.Close();
        return kitapBilgileri;
    }
    public static DataTable PopulerKitaplariCek(string sart)
    {
        Hashtable h = KitapBilgileriniCek();

        db.Open();

        string query = string.Format("SELECT KitapID,Adi,Yazari,YayinEvi,TanitimBilgisi FROM Kitaplar " + sart);

        SqlDataReader reader = db.GetDataReader(query);
        DataTable table = new DataTable();

        table.Columns.Add("KitapID", typeof(string));
        table.Columns.Add("Adi", typeof(string));
        table.Columns.Add("Yazari", typeof(string));
        table.Columns.Add("YayinEvi", typeof(string));
        table.Columns.Add("TanitimBilgisi", typeof(string));
        table.Columns.Add("Okunma Sayısı", typeof(int));

        int i = 0;
        while (reader.Read())
        {
            string kitapID = reader["KitapID"].ToString();
            string adi = reader["Adi"].ToString();
            string yazari = reader["Yazari"].ToString();
            string yayinEvi = reader["YayinEvi"].ToString();
            string tanitimi = reader["TanitimBilgisi"].ToString();
            string okunmaSayisi = h[int.Parse(kitapID)].ToString();

            table.Rows.Add(kitapID, adi, yazari, yayinEvi, tanitimi, int.Parse(okunmaSayisi));
            i++;
        }

        //DataTable sıralanır.
        table.DefaultView.Sort = "Okunma Sayısı DESC";

        //GridView1.DataSource = table;
        //GridView1.DataBind();

        reader.Close();

        return table;
    }

   
}