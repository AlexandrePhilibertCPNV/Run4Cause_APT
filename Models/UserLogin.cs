using Microsoft.AspNetCore.Identity;

namespace Run4Cause.Models;

public class UserLogin : IdentityUserLogin<int>
{
    public int Id { get; set; }
}