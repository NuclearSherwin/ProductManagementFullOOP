using System.Threading.Channels;
using Shopping.Products;

namespace Shopping.Users;

public class Login : ILogin
{
    // list user and roles
    private List<Person> _accountList = new List<Person>();
    
    
    
    // create store object
    private static Store storeServices = new Store();



    public bool LoginAsUser(string inputUserName, string inputPassword)
    {

        string usernameUser = "user";
        string passwordUser = "user";
        
        if (inputUserName == usernameUser && inputPassword == passwordUser)
        {
            LoginUiForClient();
                return true;

        }
        else
        {
            return false;
        }
    }

    public bool LoginAsStoreOwner(string inputUserName, string inputPassword)
    {
        string usernameUser = "storeowner";
        string passwordUser = "storeowner";
        
        if (inputUserName == usernameUser && inputPassword == passwordUser)
        {
            LoginUiForStoreOwner();
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public static void LoginUiForClient()
    {
        Console.WriteLine();
        Console.WriteLine("| Enter 1: Add client account ");
        Console.WriteLine("| Enter 2: Show all products");
        Console.WriteLine("| Enter 3: Purchase a product");
        Console.WriteLine("| Enter 4: Logout");
        Console.WriteLine();
        Console.WriteLine("Enter your options here: ");
    }
    
    public void LoginUiForStoreOwner()
    {
        Console.WriteLine();
        Console.WriteLine("| Enter 1: Add product ");
        Console.WriteLine("| Enter 2: Show all products");
        Console.WriteLine("| Enter 3: Update product");
        Console.WriteLine("| Enter 4: Delete product");
        Console.WriteLine("| Enter 6: Search recorded product");
        Console.WriteLine("| Enter 7: Logout");
        Console.WriteLine();
        Console.WriteLine("Enter your options here: ");
        
        string chosenNum = Console.ReadLine();

        switch (chosenNum)
        {
            case "1":
                storeServices.AddProduct();
                break;
            case "2":
                storeServices.ShowProduct();
                break;
            case "3":
                Console.WriteLine("Enter product ID: ");
                var idUpdate = Convert.ToInt32(Console.ReadLine());
                storeServices.UpdateProductById(idUpdate);
                break;
            case "4":
                Console.WriteLine("Enter product ID to delete: ");
                var idDelete = Convert.ToInt32(Console.ReadLine());
                storeServices.DeleteProduct(idDelete);
                break;
            default:
                break;
        }
    }
    
}