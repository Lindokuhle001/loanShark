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
        return loanShark.Query.UpdateTransaction(transactionData, transactionID);
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

[ApiController]
[Route("/createFile")]
public class FileController : ControllerBase
{

    [HttpGet]
    // public  SaveToFile(){
    public void Get()
    {

        loanShark.File.FileIO.SaveToFile(loanShark.Query.getTransactions());
        // Console.WriteLine(loanShark.Query.getTransactions());
    }
    // }


}

// app.MapGet("/WriteToFile", async(InternContext db) =>
// {
//         try
//         {
//             List<Intern> interns = await db.Interns.ToListAsync();
//             using StreamWriter file = new("Interns.pdf");
//             foreach (Intern person in interns)
//             {
//                 await file.WriteLineAsync(person.FirstName + " " + person.LastName + " " + person.YearOfInternship);
//             }
//         }
//         catch (Exception err)
//         {
//             Console.WriteLine("Error Message is " + err.Message);
//         }

// });
// public DbSet<Intern> Interns => Set<Intern>()