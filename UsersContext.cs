using Contacting_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacting_Backend;

public class UsersContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public UsersContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}