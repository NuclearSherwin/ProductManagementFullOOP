using System.Security.Cryptography;
using Shopping.Users;

namespace Shopping.Products;

public class Store
{
    // fields
    public int Id { get; set; }
    private List<Product> _products = new List<Product>();
    private List<Client> _clients = new List<Client>();
    
    // get and set methods
    public List<Product> Products
    {
        get { return _products; }
        set { _products = value; }
    }
    
    public List<Client> Clients
    {
        get => _clients;
        set => _clients = value;
    }

    // constructors

    public Store(int id)
    {
        Id = id;
    }

    public Store()
    {
        
    }
    

    public void AddProduct()
    {
        int id;
        string name;
        double price;
        string category;

        Console.WriteLine("Enter id");
        id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter name");
        name = Console.ReadLine();
        Console.WriteLine("Enter price");
        price = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter category");
        category = Console.ReadLine();

        Product product = new Product(id, name, price, category);
        _products.Add(product);
    }

    public void ShowProduct()
    {
        Console.WriteLine("List of products: ");
        foreach (var product in _products)
        {
            Console.WriteLine($"Id of product: {product.ProductId}");
            Console.WriteLine($"Name of product: {product.Name}");
            Console.WriteLine($"Price of product: {product.Price}");
            Console.WriteLine($"Category of product: {product.Category}");
        }
    }

    // public Product SearchObjectProduct()
    // {
    //     return;
    // }

    public bool SearchProductById(int productId)
    {
        var productInList = _products.FirstOrDefault(p =>
            p.ProductId.Equals(productId));
        _products.Remove(productInList);
        return true;
    }

    public void UpdateProductById(int id)
    {
        if (id != null)
        {
            Console.WriteLine("Enter product name");
            _products.FirstOrDefault(p => p.ProductId
                                          == id).Name = Console.ReadLine();
            Console.WriteLine("Enter product price price");
            _products.FirstOrDefault(p => p.ProductId
                                          == id).Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter product category");
            _products.FirstOrDefault(p => p.ProductId
                                          == id).Category = Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Product not found");
        }
        
    }

    public void DeleteProduct(int id)
    {
        if (id != null)
        {
            _products.Remove(_products.Where(p => p.ProductId
                                                  == id).First());
        }
        else
        {
            Console.WriteLine("Not Found");
        }
    }

    // public Client GetAllClientsPurchased()
    // {
    //     
    // }
} 