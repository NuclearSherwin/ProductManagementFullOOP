using System.Runtime.InteropServices;
using Shopping.Order;
using Shopping.Users;

namespace Shopping.Products;

public class Product
{
    // fields
    private int productId;
    private string name;
    private double price;
    private string category;
    private List<OrderDetail> _orderDetails = new List<OrderDetail>();
    
    
    // constructor
    public Product(int productId, string name, double price, string category)
    {
        ProductId = productId;
        Name = name;
        Price = price;
        Category = category;
    }

    public Product()
    {
        
    }
    
    // get and set
    public int ProductId
    {
        get
        {
            return productId;
        }
        set
        {
            productId = value;
        }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    public string Category
    {
        get { return category; }
        set
        {
            category = value;
        }
    }

    public List<OrderDetail> OrderDetail
    {
        get
        {
            return _orderDetails;
        }
        set
        {
            _orderDetails = value;
        }
    }
    
    internal void AddOrderDetail(OrderDetail orderDetail)
    {
        OrderDetail.Add(orderDetail);
    }

    public bool RemoveOrderDetail(Purchase purchase)
    {
        var orderDetail = OrderDetail.FirstOrDefault(o => o.Purchase.Equals(purchase));
        if (orderDetail == null)
        {
            return false;
        }

        OrderDetail.Remove(orderDetail);

        return true;
    }
    

    public override string ToString()
    {
        return "Product ID: " + ProductId + " Product name: " + name + " Price: " + price + " Category: " + category;
    }
}