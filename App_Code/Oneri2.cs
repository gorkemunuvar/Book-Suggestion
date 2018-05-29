using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class Oneri2
{
    static Database db = new Database();

    private static Hashtable GirenBilgileriCek(string girenKullaniciAdi)
    {
        Hashtable girenBilgileri = new Hashtable();

        string query = string.Format("SELECT KitapID, Puan FROM KitapPuan WHERE KullaniciAdi = '{0}'",
                                     girenKullaniciAdi);
        SqlDataReader reader = db.GetDataReader(query);

        while (reader.Read())
        {
            string kitapID = reader["KitapID"].ToString();
            string puan = reader["Puan"].ToString();

            girenBilgileri[kitapID] = puan;
        }

        reader.Close();
        db.Close();

        return girenBilgileri;
    }

    public static DataSet KullanicilariCek(string girenKullanici)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter();

        List<string> kullanicilar = new List<string>();
        Hashtable girenBilgileri = GirenBilgileriCek(girenKullanici);
        db.Open();

        foreach (DictionaryEntry giren in girenBilgileri)
        {
            string kitapID = giren.Key.ToString();
            string puan = giren.Value.ToString();

            string query = string.Format("SELECT KitapPuan.KitapID, KitapPuan.KullaniciAdi, Kitaplar.Adi,KitapPuan.Puan FROM KitapPuan  INNER JOIN Kitaplar ON KitapPuan.KitapID = Kitaplar.KitapID " +
                                         "WHERE NOT KitapPuan.KullaniciAdi = '{0}' AND KitapPuan.KitapID = {1} AND KitapPuan.Puan = {2}",
                                          girenKullanici, kitapID, puan);

            SqlCommand command = new SqlCommand(query, db.conn);
            adaptor.SelectCommand = command;
            adaptor.Fill(ds);
        }

        db.Close();

        return ds;
    }
}