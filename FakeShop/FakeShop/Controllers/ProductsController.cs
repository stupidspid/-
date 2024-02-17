using System.Net;
using FakeShop.Data;
using FakeShop.Models;
using FakeShop.Models.ViewModels;
using FakeShop.Utility;
using Microsoft.AspNetCore.Mvc;

namespace FakeShop.Controllers;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly IWebHostEnvironment _webHostEnvironment;
    
    public ProductsController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
    {
        _db = db;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        HomeVM homeVM = new HomeVM()
        {
            Products = _db.Products
        };
        return View(homeVM);
    }
    
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ProductVM productVm)
    {
        if (ModelState.IsValid)
        {
            string fileName = UploadFile(productVm);
            var product = new Products()
            {
                Name = productVm.Name,
                Description = productVm.Description,
                ShortDescription = productVm.ShortDescription,
                Price = productVm.Price,
                Image = fileName
            };
        
            _db.Products.Add(product);
            _db.SaveChanges();
        
            return RedirectToAction("Index");
        }

        return View();
    }

    private string UploadFile(ProductVM productVm)
    {
        string uniqueFileName = null;
        if (productVm.Image != null)
        {
            string uploadsFolder = _webHostEnvironment.WebRootPath + WC.imagePath;
            uniqueFileName = Guid.NewGuid() + "_" + Path.GetFileName(productVm.Image.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                productVm.Image.CopyTo(stream);
            }
        }
        return uniqueFileName;
    }

    public IActionResult Details(int id)
    {
        var detailsVM = new DetailsVM()
        {
            Product = _db.Products.FirstOrDefault(x => x.Id == id),
            IsAddToCart = false
        };
        return View(detailsVM);
    }
    [HttpPost, ActionName("Details")]
    public IActionResult DetailsPost(int id)
    {
        List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();
        if(HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart)!=null)
        return View(detailsVM);
    }
}