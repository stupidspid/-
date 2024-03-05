using Microsoft.AspNetCore.Identity;

namespace FakeShop.Models;

public class User : IdentityUser
{
    public string FullName { get; set; }
}