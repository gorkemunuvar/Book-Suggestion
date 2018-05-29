using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class Database
{
    public static string ConnectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();

    public SqlConnection conn = new SqlConnection(ConnectionString);

    public void Open()
    {
        if (conn.State == ConnectionState.Closed)
            conn.Open();
    }

    public void Close()
    {
        conn.Close();
    }

    public void ExecuteNonQuery(string query)
    {
        if (conn.State == ConnectionState.Closed)
            conn.Open();

        SqlCommand command = new SqlCommand(query, conn);
        command.ExecuteNonQuery();

        conn.Close();
    }

    public bool LoginControl(string userName, string password, string tableName,
                             string columnUserName, string columnPassword)
    {
        string query = string.Format("SELECT * FROM {0} WHERE {1}='{2}' AND {3}='{4}'",
                                     tableName, columnUserName, userName, columnPassword, password);
        SqlCommand command = new SqlCommand(query, conn);
        SqlDataAdapter adaptor = new SqlDataAdapter(command);
        DataSet result = new DataSet();
        if (ConnectionState.Closed == conn.State)
        {
            conn.Open();
            adaptor.Fill(result);
        }

        conn.Close();

        bool isThere = false;
        if (result.Tables[0].Rows.Count > 0)
            isThere = true;

        return isThere;
    }
    public int RowCount(string query)
    {
        Int32 rowCount;
        SqlCommand command = new SqlCommand(query, conn);

        if (ConnectionState.Closed == conn.State)
            conn.Open();

        rowCount = (Int32)command.ExecuteScalar();
        conn.Close();

        return rowCount;
    }

    public DataSet GetDataSet(string query)
    {
        if (conn.State == ConnectionState.Closed)
            conn.Open();

        SqlCommand command = new SqlCommand(query, conn);
        command.CommandType = CommandType.Text;

        SqlDataAdapter adaptor = new SqlDataAdapter(command);
        DataSet dataSet = new DataSet();
        adaptor.Fill(dataSet);

        return dataSet;
    }



    public SqlDataReader GetDataReader(string query)
    {
        SqlCommand command = new SqlCommand(query, conn);
        if (conn.State == ConnectionState.Closed)
            conn.Open();
        SqlDataReader dataReader = command.ExecuteReader();

        return dataReader;
    }

}