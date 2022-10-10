using Shopping.Products;
using Shopping.Users;

namespace Shopping.Order;

public class OrderDetail
{
    public Product Product { get; set; }
    public Purchase Purchase { get; set; }
    
    public int Quantity { get; set; }
    
    private List<Product> _products = new List<Product>();
    
    // constructors
    public OrderDetail(Product product, Purchase purchase, int quantity)
    {
        Product = product;
        Purchase = purchase;
        Quantity = quantity;
    }

    public OrderDetail()
    {
        
    }
    
    
    
    public override string ToString()
    {
        return $"Product ID {Product.ProductId}, Product name {Product.Name} " +
               $"Price {Product.Price}, Product category {Product.Category}";
    }
}

