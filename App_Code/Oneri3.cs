using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class Oneri3
{
    static Database db = new Database();

    private static string VerileriBirlestir(List<string> liste)
    {
        string sonuc = "";

        for (int i = 0; i < liste.Count; i++)
        {
            if (i != liste.Count - 1)
                sonuc += "'" + liste[i] + "',";
            else
                sonuc += "'" + liste[i] + "'";
        }

        return sonuc;
    }

    private static string VerileriBirlestir(List<int> liste)
    {
        string sonuc = "";

        for (int i = 0; i < liste.Count; i++)
        {
            if (i != liste.Count - 1)
                sonuc += liste[i] + ",";
            else
                sonuc += liste[i];
        }

        return sonuc;
    }

    /*Kullanıcı1'den gelen veriler.*/
    public static List<int> KitapIDleriniCek(string girenKullaniciAdi)
    {
        List<int> kitapIDleri = new List<int>();

        string query = string.Format("SELECT KitapID FROM KitapOkunma WHERE KullaniciAdi='{0}'",
                                     girenKullaniciAdi);

        SqlDataReader reader = db.GetDataReader(query);

        while (reader.Read())
        {
            int kitapID = int.Parse(reader["KitapID"].ToString());
            kitapIDleri.Add(kitapID);
        }

        reader.Close();
        db.Close();

        return kitapIDleri;
    }

    private static List<string> KullaniciAdlariniCek(string girenKullaniciAdi, List<int> kitapIDleri)
    {
        List<string> kullaniciAdlari = new List<string>();

        string idler = VerileriBirlestir(kitapIDleri);

        string query = string.Format("SELECT KullaniciAdi FROM KitapOkunma WHERE" +
                                     " NOT KullaniciAdi = '{0}' AND KitapID IN({1})" +
                                     " GROUP BY KullaniciAdi", girenKullaniciAdi, idler);

        SqlDataReader reader = db.GetDataReader(query);

        while (reader.Read())
        {
            string kullaniciAdi = reader["KullaniciAdi"].ToString();
            kullaniciAdlari.Add(kullaniciAdi);
        }

        reader.Close();
        db.Close();

        return kullaniciAdlari;
    }

    public static DataSet Oneri1DenGelenleriCek(string girenKullaniciAdi)
                                                
    {
        List<int> kitapIDleri = KitapIDleriniCek(girenKullaniciAdi);
        List<string> kullaniciAdlari = KullaniciAdlariniCek(girenKullaniciAdi, kitapIDleri);

        string _kitapIDleri = VerileriBirlestir(kitapIDleri);
        string _kullaniciAdlari = VerileriBirlestir(kullaniciAdlari);

        DataSet ds = new DataSet();

        /*string query = string.Format("SELECT KitapID,KullaniciAdi FROM KitapOkunma WHERE" +
                                     " NOT KitapID IN ({0}) AND KullaniciAdi IN ({1})",
                                     _kitapIDleri, _kullaniciAdlari);*/

        string query = string.Format("SELECT KitapOkunma.KitapID, KitapOkunma.KullaniciAdi, Kitaplar.Adi" +
                                     " FROM KitapOkunma INNER JOIN Kitaplar ON Kitaplar.KitapID = KitapOkunma.KitapID WHERE" +
                                     " NOT KitapOkunma.KitapID IN ({0}) AND KitapOkunma.KullaniciAdi IN ({1})",
                                     _kitapIDleri, _kullaniciAdlari);

        ds = db.GetDataSet(query);
        db.Close();

        return ds;
    }

    public static DataSet Onerilenler(string girenKullaniciAdi)

    {
        List<int> kitapIDleri = KitapIDleriniCek(girenKullaniciAdi);
        List<string> kullaniciAdlari = KullaniciAdlariniCek(girenKullaniciAdi, kitapIDleri);

        string _kitapIDleri = VerileriBirlestir(kitapIDleri);
        string _kullaniciAdlari = VerileriBirlestir(kullaniciAdlari);

        DataSet ds = new DataSet();

            string query = string.Format("SELECT TOP 10 Kitaplar.Adi" +
                                     " FROM KitapOkunma INNER JOIN Kitaplar ON Kitaplar.KitapID = KitapOkunma.KitapID WHERE" +
                                     " NOT KitapOkunma.KitapID IN ({0}) AND KitapOkunma.KullaniciAdi IN ({1}) GROUP BY Kitaplar.Adi ORDER BY NEWID();",
                                     _kitapIDleri, _kullaniciAdlari);

            ds = db.GetDataSet(query);
        
        db.Close();

        return ds;
    }
}