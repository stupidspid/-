using FakeShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace FakeShop.Controllers;

public class CartController : Controller
{
    private readonly ApplicationDbContext _db;

    public CartController()
    {
        
    }
}