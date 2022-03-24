using Microsoft.AspNetCore.Identity;

namespace Run4Cause.Models;

public class UserRole : IdentityUserRole<int>
{
    public int Id { get; set; }
}