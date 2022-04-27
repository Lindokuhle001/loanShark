using Microsoft.AspNetCore.Mvc;

namespace loanShark.Controllers;
[ApiController]
[Route("/transactions")]


public class loanSharkController : ControllerBase
{

    [HttpGet]
    public string Get()
    {
        string hello = "hello world";
        return hello;
    }
}