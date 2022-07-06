using Contacting_Backend.Clients;
using Microsoft.AspNetCore.Mvc;
namespace Contacting_Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class LookAnketesController : ControllerBase
{
    private UsersContext _db;
    private DBClient _dbClient;
    public LookAnketesController(UsersContext db)
    {
        _db = db;
        _dbClient = new DBClient(_db);
    }
    [HttpGet("GetMaleAnketes")]
    public string GetMaleAnketes()
    {
        return _dbClient.GetMales();
    }
    
    [HttpGet("GetFemaleAnketes")]
    public string GetFemaleAnketes()
    {
        return _dbClient.GetFemales();
    }
}