using System.Runtime.InteropServices;
using Shopping.Order;

namespace Shopping.Products;

public class Product
{
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
    
    
    // add product
    // public void AddProduct(int input)
    // {
    //     
    // }


    public override string ToString()
    {
        return base.ToString();
    }
}