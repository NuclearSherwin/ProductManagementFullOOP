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

        try
        {
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
        catch (Exception e)
        {
            Console.WriteLine("Error at " + e.Message);
        }


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
        var isExistID = _products.FirstOrDefault(p =>p.ProductId == id);
        

        if (isExistID == null)
        {
            Console.WriteLine("Not found!");
        }
        else
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
            Console.WriteLine("Update successfully!");
        }
        
        
    }

    public void DeleteProduct(int id)
    {
        var isExistID = _products.FirstOrDefault(p =>p.ProductId == id);
        if (isExistID == null)
        {
            Console.WriteLine("Not Found");
        }
        else
        {
            _products.Remove(_products.Where(p => p.ProductId
                                                  == id).First());

            Console.WriteLine("Delete product successfully!");
        }
    }

    // public Client GetAllClientsPurchased()
    // {
    //     
    // }
} 