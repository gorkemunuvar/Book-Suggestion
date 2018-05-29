using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class PopulerYazarlarDb
{
    static Database db = new Database();

    static public List<int> YazarIDleriniCek()
    {
        List<int> yazarIDleri = new List<int>();

        string query = "SELECT YazarID FROM Yazarlar;";
        SqlDataReader reader = db.GetDataReader(query);

        while (reader.Read())
        {
            int kitapID = int.Parse(reader["YazarID"].ToString());
            yazarIDleri.Add(kitapID);
        }

        db.Close();
        return yazarIDleri;
    }

    static public Hashtable YazarBilgileriniCek()
    {
        Hashtable okunmaBilgileri = new Hashtable();

        List<int> yazarIDleri = YazarIDleriniCek();
        for (int i = 0; i < yazarIDleri.Count; i++)
        {
            string sorgu = string.Format("SELECT COUNT(*) FROM Kitaplar INNER JOIN KitapOkunma ON " +
                                       "Kitaplar.KitapID = KitapOkunma.KitapID WHERE Kitaplar.YazarID = {0};",
                                       yazarIDleri[i]);
            int okunmaSayisi = db.RowCount(sorgu);
            okunmaBilgileri[yazarIDleri[i]] = okunmaSayisi;

            string a = okunmaBilgileri[yazarIDleri[i]].ToString();

        }

        db.Close();
        return okunmaBilgileri;
    }

    public static DataTable PopulerYazarlariCek(string sart)
    {
        Hashtable h = YazarBilgileriniCek();

        db.Open();

        string query = string.Format("SELECT * FROM Yazarlar " + sart);

        SqlDataReader reader = db.GetDataReader(query);
        DataTable table = new DataTable();

        table.Columns.Add("YazarID", typeof(string));
        table.Columns.Add("AdSoyad", typeof(string));
        table.Columns.Add("DogumTarihi", typeof(string));
        table.Columns.Add("DogumYeri", typeof(string));
        table.Columns.Add("Okunma Sayısı", typeof(int));

        int i = 0;
        while (reader.Read())
        {
            string yazarID = reader["YazarID"].ToString();
            string adi = reader["AdSoyad"].ToString(); ;
            string dogumTarihi = reader["DogumTarihi"].ToString();
            string dogumYeri = reader["DogumYeri"].ToString();
            string okunmaSayisi = h[int.Parse(yazarID)].ToString();

            table.Rows.Add(yazarID, adi, dogumTarihi, dogumYeri, int.Parse(okunmaSayisi));
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