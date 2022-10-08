using Shopping.Order;
using Shopping.Products;

namespace Shopping.Users;

public class Purchase
{
    // fields
    private int id { get; set; }
    private Client _client;
    private DateTime purchaseDate;

    private List<OrderDetail> _orderDetails = new List<OrderDetail>();
    
    // get and set method
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

    public Purchase(int id, Client client, DateTime purchaseDate)
    {
        Id = id;
        Client = client;
        PurchaseDate = purchaseDate;
    }



    // public void addOrderDetail(int input)
    // {
    //     int id;
    //     Console.WriteLine("enter orderDetail");
    //     id = int.Parse(Console.ReadLine());
    //     OrderDetail orderDetails = new OrderDetail(id);
    //     _orderDetails.Add(orderDetails);
    // }
    
    
    // add orderDetail
    internal void AddOrderDetail(OrderDetail orderDetail)
    {
        OrderDetailsList.Add(orderDetail);
    }
    
    // show order details
    public string showOrderDetails()
    {
        string stringToChain = " ";
        foreach (var orderDetail in OrderDetailsList)
        {
            stringToChain += orderDetail.ToString();
        }

        return stringToChain;

    }

    public override string ToString()
    {
        return "Order ID: " + Id + "Client " + _client.Name + 
               "PurchaseDate " + purchaseDate;
    }
}