using System.Net;
using Contacting_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Contacting_Backend.Clients;
using System.Text.Json;
using Microsoft.AspNetCore.ResponseCaching;

namespace Contacting_Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UsersContext _db;
    private DBClient _dbClient;
    public UserController(UsersContext db)
    {
        _db = db;
        _dbClient = new DBClient(_db);
    }
    
    
    [HttpPost("CreateUser")]
    public void CreateUser(long id, string nickname)
    {
        _dbClient.AddUser(new User() {TGID = id, tg_nickname = nickname});
    }

    [HttpGet("GetUsers")]
    public List<User> GetUsers()
    {
        return _db.Users.ToList();
    }
    
    [HttpGet("DeleteUsers")]
    public void DeleteUsers()
    {
        _db.Users.RemoveRange(_db.Users);
        _db.SaveChanges();
    }
}