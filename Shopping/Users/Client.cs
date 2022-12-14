using System.Threading.Channels;
using Shopping.Products;

namespace Shopping.Users;

public class Client : Person, ILogin
{
    private int clientId;
    private List<Purchase> purchases = new List<Purchase>();
    
    // get and set method
    public List<Purchase> Purchases
    {
        get { return purchases;  }
        set { purchases = value; }
    }

    public int ClientId
    {
        get { return clientId; }
        set { clientId = value; }
    }
    
    // constructors
    public Client(int clientId)
    {
        ClientId = clientId;
    }

    public Client()
    {
        
    }

    public Client(string name, int age, 
        string address, string phone, int clientId) 
        : base(name, age, address, phone)
    {
        ClientId = clientId;
    }



 
    // create user account
    public override void InputInformation()
    {
        try
        {
            // this.ClientId = UserInterface.EnterClientId();
            this.Name = UserInterface.EnterUserEmail();
            this.Phone = UserInterface.EnterUserPhoneNum();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool Login(string inputUsername, string inputPassword)
    {
        string correctUsername = "user";
        string correctPassword = "user";
        
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

    
    // search id of purchase
    public Purchase searchPurchaseById(int id)
    {
        var purchasedInList = Purchases
            .FirstOrDefault(p => p.Id == id);
        return purchasedInList;
    }
    
    public override string ToString()
    {
        return "User ID: " + ClientId + " Name: "
               + Name + " Address " + " Phone number: " +  Phone;
    }
    
}
