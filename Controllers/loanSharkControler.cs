using Microsoft.AspNetCore.Mvc;
using loanShark;
using System.Data.SqlClient;
using loanShark.Table;
namespace loanShark.Controllers;
[ApiController]
[Route("/transactions")]
public class loanSharkController : ControllerBase
{

    [HttpGet]
    public string Get()
    {
        return loanShark.Query.getTransactions();
    }

    // [HttpGet]
    // public int GetCount()
    // {
    //     SqlCommand command;
    //     string connectionString = "Data Source=localhost;Initial Catalog=loanShark;User ID=shark;Password=pass";
    //     string sql = "SELECT COUNT(*) FROM Transactions";
    //     var connection = new SqlConnection(connectionString);

    //     Dictionary<string,string> result = new Dictionary<string,string>();
    //     connection.Open();
    //     Console.Write("connected");
    //     command = new SqlCommand(sql, connection);
    //     var reader = command.ExecuteReader();
    //     return int.Parse(reader[0].ToString());
    // }

    [Produces("application/json")]
    [HttpPost]
    public string Post([FromBody] loanShark.Table.Transactions transactionData)
    {
        var postedData = transactionData;
        return loanShark.Query.PostTransaction(postedData);
    }

    // [HttpPut]
    // public string UpdateTransaction([FromBody] Command updateTransaction)
    // {
    //     var com = updateTransaction;
    //     // Console.WriteLine(updateTransaction.name);
    //     SqlCommand command;
    //     string connectionString = "Data Source=localhost;Initial Catalog=constructionDB;User ID=user;Password=pass";
    //     string sql = "UPDATE transactions set FirstName=shabalala where transactionID";
    //     var connection = new SqlConnection(connectionString);


    //     connection.Open();
    //     Console.Write("connected");
    //     command = new SqlCommand(sql, connection);
    //     return "inserted";
    // }

    // [HttpDelete]
    // public string DeleteTransaction([FromBody] Command deleteTransaction)
    // {
    //     var com = deleteTransaction;
    //     // Console.WriteLine(deleteTransaction.name);
    //     SqlCommand command;
    //     string connectionString = "Data Source=localhost;Initial Catalog=constructionDB;User ID=user;Password=pass";
    //     string sql = $"INSERT INTO transactions(FirstName,LastName,PhysicalAddress,PhoneNumber,Amount) VALUES('lindokuhle','shabalala', '25 st street',0123456789,5000)";
    //     var connection = new SqlConnection(connectionString);


    //     connection.Open();
    //     Console.Write("connected");
    //     command = new SqlCommand(sql, connection);
    //     return "inserted";
    // }

    



}
[ApiController]
[Route("/count")]
public class CountController : ControllerBase
{

    [HttpGet]
    public int Get()
    {
        return loanShark.Query.GetCount();
    }


}