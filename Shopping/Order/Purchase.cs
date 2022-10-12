using Shopping.Order;
using Shopping.Products;

namespace Shopping.Users;

public class Purchase
{
    // fields
    private int id { get; set; }
    private Client client;
    private DateTime purchaseDate;
    private List<OrderDetail> orderDetails = new List<OrderDetail>();
    
    // get and set methods
    public int Id
    {
        get
        {
            return id;
        }
        set { id = value; }
    }
    
    public List<OrderDetail> OrderDetailsList
    {
        get
        {
            return orderDetails;
        }
        set
        {
            orderDetails = value;
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
            return client;
        }
        set
        {
            client = value;
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
    
    

    // add orderDetail
    public void AddOrderDetail(OrderDetail orderDetail)
    {
        OrderDetailsList.Add(orderDetail);
    }
    
    // show all order details
    public void showOrderDetails()
    {
        Console.WriteLine("Order detail list: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (var orderDetail in OrderDetailsList)
        {
            Console.WriteLine($"Quantity {orderDetail.Purchase.Client.clientId}");
            Console.WriteLine($"Username: {orderDetail.Purchase.Client.Name}");
            Console.WriteLine($"Product Id: {orderDetail.Product.ProductId}");
            Console.WriteLine($"Quantity {orderDetail.Quantity}");
        }

        Console.WriteLine("-----------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;

    }

    // to string
    public override string ToString()
    {
        return "Order ID: " + Id + "Client " + client.Name + 
               "PurchaseDate " + purchaseDate;
    }
}