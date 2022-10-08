using Shopping.Products;
using Shopping.Users;

namespace Shopping.Order;

public class OrderDetail
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public Purchase Purchase { get; set; }
    
    private List<Product> _products = new List<Product>();
    
    public OrderDetail(int id, Product product, Purchase purchase)
    {
        Id = id;
        Product = product;
        Purchase = purchase;
    }
    
    
    
    public override string ToString()
    {
        return $"Product ID {Product.ProductId}, Product name {Product.Name} " +
               $"Price {Product.Price}, Product category {Product.Category}";
    }
}

