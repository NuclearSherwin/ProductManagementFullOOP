using Shopping.Products;
using Shopping.Users;

namespace Shopping.Order;

public class OrderDetail
{
    private Product product;
    private Purchase purchase;
    private int quanity;

    // get and set methods
    public Product Product
    {
        get { return product;}
        set { product = value; }
    }
    public Purchase Purchase
    {
        get { return purchase; }
        set { purchase = value; }
    }

    public int Quantity
    {
        get { return quanity; }
        set { quanity = value; }
    }
    
     
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

