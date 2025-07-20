using System.Text.Json.Serialization;

namespace BookStore.Core.Models;

public class User
{
    public const int MAX_USERNAME_LENGTH = 50;
    public const int MAX_EMAIL_LENGTH = 100;

    [JsonConstructor]
    public User(Guid id, string username, string email,string passwordhash)
    
    {
        Id = id;
        Username = username;
        Email = email;
        PasswordHash = passwordhash;
        
        
    }
   

    public Guid Id { get;set; }
    public string Username { get; set;} = string.Empty;
    public string Email { get;set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Password { get;set;} = string.Empty;

    public static (User? User, string Error) Create(Guid id, string username, string email,string passwordhash)
    {
       

        var user = new User(id, username, email,passwordhash);
        return (user, string.Empty);
    }
}