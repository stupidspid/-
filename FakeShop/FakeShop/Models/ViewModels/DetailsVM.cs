namespace FakeShop.Models.ViewModels;

public class DetailsVM
{
    public DetailsVM()
    {
        Product = new Products();
    }
    
    public Products Product { get; set; }
    public bool IsAddToCart { get; set; }
}