using System.Threading.Channels;
using Shopping.Order;
using Shopping.Products;

namespace Shopping.Users;

public class Client : Person
{
    public int ClientId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    private List<Purchase> _purchases = new List<Purchase>();
    
    // list order detail
    private List<OrderDetail> _orderDetails = new List<OrderDetail>();
    
    
    // get and set method
    public List<Purchase> Purchases
    {
        get { return _purchases;  }
        set { _purchases = value; }
    }

    // constructors
    public Client(int clientId)
    {
        ClientId = clientId;
    }

    public Client(string name, int age, string address, string phone, int clientId) 
        : base(name, age, address, phone)
    {
        ClientId = clientId;
    }

    public Client(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }


    public override void InputInformation()
    {
        
    }

    public bool Login(string username, string password)
    {
        string correctUsername = "Phong";
        string correctPassword = "Phong";
        
        // check weather username and password is correct
        if (username != correctUsername &&
            password != correctPassword)
        {
            return false;
        }
        
        return true;
    }

    public void AddPurchase(int input)
    {
        int purchaseId;
        Purchase purchase = null;
        
        int year;
        int month;
        int day;

        Client clientBought = null;
        
        // DateTime
        DateTime purchaseDate;

        Console.WriteLine("Enter purchase id");
        purchaseId = int.Parse(Console.ReadLine());
        // take current user
        clientBought.ClientId = ClientId;
        Console.WriteLine("Enter purchase date");
        day = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter purchase month");
        month = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter purchase year");
        year = int.Parse(Console.ReadLine());

        purchaseDate = new DateTime(year, month, day);

        Purchase newPurchase = new Purchase(purchaseId, clientBought, purchaseDate);

        // add to purchase list
        _purchases.Add(newPurchase);

    }

    public string ShowAllPurchases()
    {
        return $"{_purchases}";
    }

    public bool RemovePurchase()
    {
        return true;
    }
}