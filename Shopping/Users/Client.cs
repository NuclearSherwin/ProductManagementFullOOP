using System.Threading.Channels;
using Shopping.Products;

namespace Shopping.Users;

public class Client : Person, ILogin
{
    public int ClientId { get; set; }
    private List<Purchase> _purchases = new List<Purchase>();
    
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

    public Client()
    {
        
    }

    public Client(string name, int age, string address, string phone, int clientId) 
        : base(name, age, address, phone)
    {
        ClientId = clientId;
    }



 
    // create user account
    public override void InputInformation()
    {
        this.ClientId = UserInterface.EnterUserName();
        this.Name = UserInterface.EnterUserEmail();
        this.Phone = UserInterface.EnterUserPhoneNum();
    }

    public bool Login(string inputUsername, string inputPassword)
    {
        string correctUsername = "User";
        string correctPassword = "User";
        
        // check weather username and password is correct
        if (inputUsername != correctUsername &&
            inputPassword != correctPassword)
        {
            return false;
        }
        
        return true;
    }

    // add a purchase
    public void AddPurchase(Purchase purchase)
    {
        Purchases.Add(purchase);
    }
    
    // remove purchase
    public bool RemovePurchase(Purchase purchase)
    {
        var purchaseInList = Purchases.FirstOrDefault(p =>
            p.Id == purchase.Id);
        if (purchaseInList == null)
        {
            Console.WriteLine("Purchase not found!");
            return false;
        }

        Purchases.Remove(purchase);
        return true;
    }

    // show all products
    public string ShowAllPurchases()
    {
        string stringToChain = "";
        foreach (var purchase in Purchases)
        {
            stringToChain += purchase.ToString();
        }
        return stringToChain;
    }

    public override string ToString()
    {
        return "User ID: " + ClientId + "Name: "
               + Name + "Address " + "Phone number: " +  Phone;
    }
    
}