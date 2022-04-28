using System;
using System.Data.SqlClient;
namespace loanShark;

class Query
{   
    public static string ConnectToDB(string sql)
        {
            string sqlResult = "";
            var connection = new SqlConnection("Data Source=localhost;Initial Catalog=loanShark;User ID=shark;Password=pass;");
            connection.Open();
            Console.WriteLine($"*\n{connection.Database} Successfully Opened\n***");
            var reader = new SqlCommand(sql, connection).ExecuteReader();
            while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        sqlResult += $"{reader[i]} ";
                    }
                    sqlResult += "\n";
                }
            return sqlResult;
        }
    public static string getTransactions()
    {   
        // SqlCommand command;
        // string connectionString = "Data Source=localhost;Initial Catalog=loanShark;User ID=shark;Password=pass";
        string sql = "SELECT * FROM Transactions";
        var result = ConnectToDB(sql);
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

        return result;

    }
    public static int GetCount()
    {
 
        string sql = "SELECT COUNT(*) FROM Transactions";
        return int.Parse(ConnectToDB(sql));
    }


}

