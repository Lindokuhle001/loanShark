using System;
using System.Data.SqlClient;
namespace loanShark
{
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
    }
}
