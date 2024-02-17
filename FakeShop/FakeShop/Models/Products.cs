using System.ComponentModel.DataAnnotations;

namespace FakeShop.Models;

public class Products
{
    [Key] 
    public int Id { get; set; }
    
    [Required] 
    public string Name { get; set; }

    [Range(1, int.MaxValue)]
    public double Price { get; set; }

    public string Description { get; set; }
    public string ShortDescription { get; set; }

    public string Image { get; set; }
}