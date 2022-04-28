using Microsoft.AspNetCore.Mvc;
using loanShark;
using System.Data.SqlClient;

using Commander;
namespace loanShark.Controllers;
[ApiController]
[Route("/transactions")]


public class loanSharkController : ControllerBase
{

    [HttpGet]
    public Dictionary<string, string> Get()
    {
        Console.WriteLine("transaction");

        //string hello = "hello world";
        return loanShark.program.getTransactions();
    }

    [Produces("application/json")]
    [HttpPost]
    public  string PostTransaction([FromBody] Command lindo)
    {
        var com = lindo;
        Console.WriteLine(lindo.name);
        SqlCommand command;
        string connectionString = "Data Source=localhost;Initial Catalog=constructionDB;User ID=user;Password=pass";
        string sql = "INSERT INTO transactions(FirstName,LastName,PhysicalAddress,PhoneNumber,Amount) VALUES('lindokuhle','shabalala', '25 st street',0123456789,5000)";
        var connection = new SqlConnection(connectionString);


        connection.Open();
        Console.Write("connected");
        command = new SqlCommand(sql, connection);
        return "inserted";
    }



}