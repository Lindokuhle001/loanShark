using System;
using System.Data.SqlClient;
namespace loanShark;

class program
{
    static void Main()
    {
        SqlCommand command;
        string connectionString = "Data Source=localhost;Initial Catalog=constructionDB;User ID=user;Password=pass";
        string sql = "SELECT TeamID,TeamName FROM AvalableTeams";
        var connection = new SqlConnection(connectionString);
        try
        {
            connection.Open();
            Console.Write("connected");
            command = new SqlCommand(sql, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}, {1}",
                        reader[0], reader[1]));
                }
            }
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.Write(ex);
        }

    }

    public static Dictionary<string,string> getTransactions()
    {
        SqlCommand command;
        string connectionString = "Data Source=localhost;Initial Catalog=constructionDB;User ID=user;Password=pass";
        string sql = "SELECT TeamID,TeamName FROM AvalableTeams";
        var connection = new SqlConnection(connectionString);

        // string result = "";
        Dictionary<string,string> result = new Dictionary<string,string>();
        // di
        connection.Open();
        Console.Write("connected");
        command = new SqlCommand(sql, connection);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add($"{reader["TeamID"]}",$"{reader["TeamName"]}");
            // += $"{reader["TeamID"]}, {reader["TeamName"]}";
        }

        return result;

    }
    public static string getT()
    {
        // SqlCommand command;
        // string connectionString = "Data Source=localhost;Initial Catalog=constructionDB;User ID=user;Password=pass";
        // string sql = "SELECT TeamID,TeamName FROM AvalableTeams";
        // var connection = new SqlConnection(connectionString);

        // string result = "";
        // connection.Open();
        // Console.Write("connected");
        // command = new SqlCommand(sql, connection);
        // var reader = command.ExecuteReader();
        // while (reader.Read())
        // {
        //     result += $"{reader["TeamID"]}, {reader["TeamName"]}";
        // }

        return "result";

    }


}

