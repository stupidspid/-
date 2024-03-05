namespace FakeShop.Models;

public class ShoppingCart
{

    public ShoppingCart(int id)
    {
        ProductId = id;
    }
    public int ProductId { get; set; }
}