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

    [HttpPut]
    public string Put([FromBody] loanShark.Table.Transactions transactionData, int transactionID)
    {
        var postedData = transactionData;
        return loanShark.Query.UpdateTransaction(transactionData,transactionID);
    }

    [HttpDelete("/{transactionID}")]
    public string DeleteTransaction(int transactionID)
    {
        return loanShark.Query.deleteTransaction(transactionID);
    }

    



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