using System.Text.Json;
using Contacting_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacting_Backend.Clients;

public class DBClient
{
    private UsersContext db { get; set; }
    public DBClient(UsersContext db)
    {
        this.db = db;
    }
    
    public async void AddUser(User user)
    {
        if (db.Users.FirstOrDefault(userdb => userdb.TGID == user.TGID) == null)
        {
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
        }
    } 
    
    public async void DeleteUser(User user)
    {
        db.Users.Remove(user);
        await db.SaveChangesAsync();
    }
    
    

    public List<User> GetAll()
    {
        return db.Users.ToList();
    }

    public async void FillData(long tgid, string name, int age, string male, string city, string description, string photopath)
    {
        var user = db.Users.FirstOrDefault(user => user.TGID == tgid);
        user.Name = name;
        user.age = age;
        user.Male = male == "M" ? Males.Male : Males.Female;
        
        user.city = city;
        user.description = description;
        user.photo_path = photopath;
        
        await db.SaveChangesAsync();
    }

    public string GetUser(long id)
    {
        return JsonSerializer.Serialize(db.Users.FirstOrDefault(user=>user.TGID == id));
    }

    public string GetMales()
    {
        return JsonSerializer.Serialize(db.Users.Where(user => user.Male == Males.Male));
    }

    public string GetFemales()
    {
        return JsonSerializer.Serialize(db.Users.Where(user => user.Male == Males.Female));
    }
}