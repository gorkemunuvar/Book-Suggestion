using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class Oneri1
{
    static Database db = new Database();

    private static string IDleriBirlestir(List<int> liste)
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

    public static List<int> Okuduklari(string girenKullanici)
    {
        List<int> okuduklari = new List<int>();

        string query = string.Format("SELECT KitapID FROM KitapOkunma WHERE KullaniciAdi='{0}'",
                                     girenKullanici);

        SqlDataReader reader = db.GetDataReader(query);

        while (reader.Read())
        {
            int kitapID = int.Parse(reader["KitapID"].ToString());
            okuduklari.Add(kitapID);
        }

        reader.Close();
        db.Close();

        return okuduklari;
    }

    public static DataSet OrtakOkunmaSayilariniCek(string girenKullaniciAdi)
    {
        DataSet ds = new DataSet();

        List<int> idListesi = Okuduklari(girenKullaniciAdi);

        string idler = IDleriBirlestir(idListesi);

        string query = string.Format("SELECT KullaniciAdi, COUNT(KullaniciAdi) AS OrtakKitapSayisi FROM KitapOkunma" +
                                     " WHERE NOT KullaniciAdi = '{0}' AND KitapID IN({1})" +
                                     " GROUP BY KullaniciAdi ORDER BY OrtakKitapSayisi DESC",
                                     girenKullaniciAdi,
                                     idler);

        

        return db.GetDataSet(query);
    }

}