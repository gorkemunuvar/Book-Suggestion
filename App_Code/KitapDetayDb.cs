using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class KitapDetayDb
{
    static Database db = new Database();
    public static float GetAverageScore(int bookID)
    {
        int counter = 0;
        float score = 0.0f, average = 0.0f;

        string query = string.Format("SELECT Puan,KitapID FROM KitapPuan WHERE KitapID={0}", bookID);
        SqlDataReader reader = db.GetDataReader(query);

        while (reader.Read())
        {
            if (bookID.ToString() == reader["KitapID"].ToString())
            {
                score += float.Parse(reader["Puan"].ToString());
                counter++;
            }
        }

        db.Close();
        average = score / counter;

        return average;
    }

    //İnceleme ekleme
    public static void AddBookReview(string bookID, string userName, string review)
    {
        string query = string.Format("INSERT INTO KitapInceleme(KitapID, KullaniciAdi, Inceleme)" +
                                     "VALUES({0},'{1}','{2}')", bookID, userName, review);

        db.ExecuteNonQuery(query);
    }

    //Alıntı ekleme
    public static void AddQuote(string bookID, string userName, string page, string quote)
    {
        string query = string.Format("INSERT INTO KitapAlinti(KitapID, KullaniciAdi, SayfaNo, Cumle)" +
                                     "VALUES({0},'{1}',{2},'{3}')", bookID, userName, page, quote);

        db.ExecuteNonQuery(query);
    }
}