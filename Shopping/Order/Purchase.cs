using Shopping.Order;
using Shopping.Products;

namespace Shopping.Users;

public class Purchase
{
    // fields
    private int Id { get; set; }
    private Client _client;
    private DateTime purchaseDate;

    private List<OrderDetail> _orderDetails = new List<OrderDetail>();
    
    // get and set method
    public List<OrderDetail> OrderDetailsList
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

    public DateTime PurchaseDate
    {
        get
        {
            return purchaseDate;
        }
        set
        {
            purchaseDate = value;
        }
    }

    public Client Client
    {
        get
        {
            return _client;
        }
        set
        {
            _client = value;
        }
    }

    // constructors
    public Purchase(int id, Client client, DateTime purchaseDate)
    {
        Id = id;
        Client = client;
        PurchaseDate = purchaseDate;
    }

    public Purchase()
    {
        
    }



    // public void addOrderDetail(int input)
    // {
    //     int id;
    //     Console.WriteLine("enter orderDetail");
    //     id = int.Parse(Console.ReadLine());
    //     OrderDetail orderDetails = new OrderDetail(id);
    //     _orderDetails.Add(orderDetails);
    // }

    public string showOrderDetails()
    {
        return "Order ID: " + Id + "Client " + _client.Name + 
               "PurchaseDate " + purchaseDate;
    }
    
    
    // show all records (user bought)
    public void ShowAllPurchased()
    {
        Console.WriteLine("List of record products: ");
        foreach (var orderDetail in _orderDetails)
        {
            Console.WriteLine($"Id of orderDetails: {orderDetail.Id}");
            Console.WriteLine($"Id of orderDetails: {orderDetail.Product.Name}");
            Console.WriteLine($"Id of orderDetails: {orderDetail.Product.Price}");
            Console.WriteLine($"Id of orderDetails: {orderDetail.Purchase.Client.UserName}");
        }
    }

    public override string ToString()
    {
        return base.ToString();
    }
}