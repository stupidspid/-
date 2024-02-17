using System.ComponentModel.DataAnnotations;

namespace FakeShop.Models.ViewModels;

public class ProductVM
{
    [Microsoft.Build.Framework.Required] 
    public string Name { get; set; }

    [Range(1, int.MaxValue)] 
    public double Price { get; set; }

    public string Description { get; set; }
    public string ShortDescription { get; set; }

    public IFormFile Image { get; set; }
}