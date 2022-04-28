using System;
using System.Data.SqlClient;
using static loanShark.Table.Transactions;
namespace loanShark;

class Query
{
    public static string ConnectToDB(string sql)
    {
        try
        {
            string sqlResult = "";
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=loanShark;User ID=shark;Password=pass;");
            connection.Open();
            SqlDataReader reader = new SqlCommand(sql, connection).ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    sqlResult += $"{reader[i]} ";
                }
                sqlResult += "\n";
            }
            connection.Close();
            return sqlResult;
        }
        catch (System.Exception)
        {

            throw new Exception("there was an error please try again");
        }


    }
    public static string getTransactions()
    {

        string sql = "SELECT * FROM Transactions";
        var result = ConnectToDB(sql);

        return result;



        // var connection = new SqlConnection(connectionString);

        // connection.Open();
        // Console.Write("connected");
        // command = new SqlCommand(sql, connection);
        // var reader = command.ExecuteReader();
        // Dictionary<string,string> result = new Dictionary<string,string>();

        // while (reader.Read())
        // {
        //     result.Add("transactionID",$"{reader["transactionID"]}");
        //     result.Add("FirstName",$"{reader["FirstName"]}");
        //     result.Add("LastName",$"{reader["LastName"]}");
        //     result.Add("PhysicalAddress",$"{reader["PhysicalAddress"]}");
        //     result.Add("PhoneNumber",$"{reader["PhoneNumber"]}");
        //     result.Add("Amount",$"{reader["Amount"]}");
        // }



    }
    public static int GetCount()
    {
        string sql = "SELECT COUNT(*) FROM Transactions";
        return int.Parse(ConnectToDB(sql));
    }

    public static string PostTransaction(loanShark.Table.Transactions transact)
    {
        string sql = $"INSERT INTO transactions VALUES('{transact.FirstName}','{transact.LastName}','{transact.PhysicalAddress}','{transact.PhoneNumber}','{transact.Amount}')";

        return ConnectToDB(sql);
    }

    public static string UpdateTransaction(loanShark.Table.Transactions transact, int transactionID)
    {
        string sql = $"UPDATE transactions set Amount = '{transact.Amount}' where transactionID={transactionID}";
        return ConnectToDB(sql);

    }

    public static string deleteTransaction(int transactionID)
    {
        string sql = $"DELETE FROM transactions where transactionID={transactionID}";
        return ConnectToDB(sql);

    }
}

