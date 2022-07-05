using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacting_Backend.Models;

[Table("Users")]
public class User
{
     public User(long tgid, string tgNickname)
     {
          TGID = tgid;
          tg_nickname = tgNickname;
     }

     public User()
     {
          
     }
     
     [Key]
     public long TGID { get; set; }
     public string tg_nickname { get; set; }
     
     public string? Name { get; set; }
     
     public Males? Male { get; set; }
     
     
     public int? age { get; set; }
     
     public string? description { get; set; }
     public string? city { get; set; }

     
     
}

public enum Males
{
     Male = 0,
     Female
}