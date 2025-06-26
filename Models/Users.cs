namespace blazorapp;


public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } // e.g., "admin", "user"
    public string Avatar { get; set; } // URL to the user's profile image
}

