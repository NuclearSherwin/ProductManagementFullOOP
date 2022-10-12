using System.Security.Cryptography;
using Shopping.Order;
using Shopping.Users;

namespace Shopping.Products;

public class Store : ILogin
{
    // fields
    private int id;
    private List<Product> products = new List<Product>();
    private List<Client> clients = new List<Client>();
    private List<OrderDetail> orderDetails = new List<OrderDetail>();

    // get and set methods
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    
    public List<Product> Products
    {
        get { return products; }
        set { products = value; }
    }
    
    public List<Client> Clients
    {
        get => clients;
        set => clients = value;
    }

    public List<OrderDetail> OrderDetails
    {
        get { return orderDetails; }
        set { orderDetails = value; }
    }
    

    // constructors
    public Store(int id)
    {
        Id = id;
    }

    public Store()
    {
        
    }
    
    // add product to list
    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    // show all product
    public void ShowProducts()
    {
        Console.WriteLine("List of products: ");
        foreach (var product in Products)
        {
            Console.WriteLine($"Id of product: {product.ProductId}");
            Console.WriteLine($"Name of product: {product.Name}");
            Console.WriteLine($"Price of product: {product.Price}");
            Console.WriteLine($"Category of product: {product.Category}");
            Console.WriteLine("-------------------------------------");
        }
    }

    // check product ID
    public bool checkProductId(int id)
    {
        var productId = Products.FirstOrDefault(p => p.ProductId == id);
        if (productId == null)
        {
            return false;
        }

        return true;
    }

    // search product by ID
    public void searchProductById(int id)
    {
        var products = from p in
                Products
            where p.ProductId == id
            select p;
        
        if (products == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Not found");
            Console.ForegroundColor = ConsoleColor.White;
        }

        foreach (var product in products)
        { 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Id of product: {product.ProductId}");
            Console.WriteLine($"Id of product: {product.Name}");
            Console.WriteLine($"Id of product: {product.Price}");
            Console.WriteLine($"Id of product: {product.Category}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.ForegroundColor = ConsoleColor.White;

    }
    
    // search product by name
    public void searchProductByName(string name)
    {
        var products = from p in
                Products
            where p.Name.Trim().ToLower() == name.Trim().ToLower()
            select p;

        foreach (var product in products)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Id of product: {product.ProductId}");
            Console.WriteLine($"Id of product: {product.Name}");
            Console.WriteLine($"Id of product: {product.Price}");
            Console.WriteLine($"Id of product: {product.Category}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    // update product by ID
    public void UpdateProductById(int id)
    {
        var isExistID = Products.FirstOrDefault
            (p => p.ProductId == id);
        

        if (isExistID == null)
        {
            Console.WriteLine("Not found!");
        }
        else
        {
            Console.WriteLine("Enter product name");
            products.FirstOrDefault(p => p.ProductId
                                          == id).Name = Console.ReadLine();
            Console.WriteLine("Enter product price price");
            products.FirstOrDefault(p => p.ProductId
                                          == id).Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter product category");
            products.FirstOrDefault(p => p.ProductId
                                          == id).Category = Console.ReadLine();
            Console.WriteLine("Update successfully!");
        }
        
        
    }

    // delete product
    public void DeleteProduct(int id)
    {
        var isExistID = products.FirstOrDefault(p =>p.ProductId == id);
        if (isExistID == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Not Found");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            products.Remove(products.Where(
                p => p.ProductId == id).First());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Delete product successfully!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    
    // to find user have been purchased a product
    public Client GetUserPurchaseProductById(int idToSearch)
    {
        var userInList = Clients.FirstOrDefault(u => u.ClientId
            .Equals(idToSearch));
        return userInList;
    }
    
    
    // login
    public bool Login(string inputUsername, string inputPassword)
    {
        string correctUsername = "storeowner";
        string correctPassword = "storeowner";

        if (inputPassword != correctUsername &&
            inputPassword != correctPassword)
        {
            return false;
        }

        return true;
    }

    // add a new user
    public void AddUser()
    {
        Client client = new Client();
        client.ClientId = UserInterface.EnterClientId();
        // input the rest of info of user
        client.InputInformation();
        // add new user to list
        Clients.Add(client);
        UserInterface.MenuForUser();
    }
    
    // search user by ID
    public bool SearchUserById(int idUserToSearch)
    {
        var userInList = Clients.FirstOrDefault(c => c.ClientId.Equals(idUserToSearch));
        if (userInList == null)
        {
            return false;
        }

        return true;
    }
    
    // search user object
    public Client searchUserWithObjType(int idUserToSearch)
    {
        var userInList = Clients.FirstOrDefault(u => u.ClientId == idUserToSearch);
        if (userInList == null)
        {
            Console.WriteLine("Not found");
        }

        return userInList;

    }
    
    // search product object
    public Product searchProductWithObjType(int idProductToSearch)
    {
        var productInList = Products.FirstOrDefault(p => p.ProductId == idProductToSearch);
        if (productInList == null)
        {
            Console.WriteLine("Not found!");
        }

        return productInList;
    }
    
    // show all order detail
    public void ShowAllOrderDetails()
    {
        Console.WriteLine("List of order details: ");
        foreach (var orderDetail in OrderDetails)
        {
            Console.WriteLine($"Product id: {orderDetail.Product.ProductId}");
            Console.WriteLine($"User purchased: {orderDetail.Purchase.Client.clientId}");
            Console.WriteLine($"Quantity: {orderDetail.Quantity}");
        }
    }
    
    // get user bought products by ID
    public Client GetUserPurchaseById(int idUserToSearch)
    {
        var studentInList = Clients.FirstOrDefault(u => u.clientId == idUserToSearch);
        return studentInList;
    }

} 