using Contacting_Backend.Clients;
using Contacting_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contacting_Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class AnketeController : ControllerBase
{
    private UsersContext _db;
    private DBClient _dbClient;
    public AnketeController(UsersContext db)
    {
        _db = db;
        _dbClient = new DBClient(_db);
    }
    [HttpPost("FillData")]
    public void FillData(long tgid, string name, int age, string male, string city,  string description, string photopath)
    {
        _dbClient.FillData(tgid, name, age, male, city, description, photopath);
    }

    [HttpGet("GetMyAnketa")]
    public string GetMyAnketa(long id)
    {
        return _dbClient.GetUser(id);
    }
    
    
    
}