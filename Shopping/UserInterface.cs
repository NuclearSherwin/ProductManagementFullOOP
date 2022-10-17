using Shopping.Users;

namespace Shopping;

public class UserInterface
{
    // for user info
    public static string EnterUserName()
    {
        Console.WriteLine("Enter username: ");
        return Console.ReadLine();
    }

    public static string EnterUserEmail()
    {
        Console.WriteLine("Enter user email: ");
        return Console.ReadLine();
    }

    public static string EnterUserPhoneNum()
    {
        Console.WriteLine("Enter user phone number: ");
        return Console.ReadLine();  
    }

    public static int EnterClientId()
    {
        Console.WriteLine("Enter user ID: ");
        return int.Parse(Console.ReadLine());
    }

    public static string EnterUserPassword()
    {
        Console.WriteLine("Enter password: ");
        return Console.ReadLine();
    }
    
    
    // for login
    public static void LoginMenu()
    {
        Console.WriteLine();
        Console.WriteLine("1. Login as store owner");
        Console.WriteLine("2. Login as user");
        Console.WriteLine("3. Exit");
        Console.WriteLine("Enter your number: ");
    }

    public static void MenuForStoreOwner()
    {
        Console.WriteLine();
        Console.WriteLine("| Enter 1: Add product ");
        Console.WriteLine("| Enter 2: Show all products");
        Console.WriteLine("| Enter 3: Update product");
        Console.WriteLine("| Enter 4: Delete product");
        Console.WriteLine("| Enter 5: Search id of product");
        Console.WriteLine("| Enter 6: Search name of product");
        Console.WriteLine("| Enter 7: View all orders");
        Console.WriteLine("| Enter 8: Logout");
        Console.WriteLine();
        Console.WriteLine("Enter your options here: ");
    }

    public static void MenuForUser()
    {
        Console.WriteLine();
        Console.WriteLine("| Enter 1: Add a new user account");
        Console.WriteLine("| Enter 2: Show all products ");
        Console.WriteLine("| Enter 3: Purchase a product ");
        // Console.WriteLine("| Enter 4: delete account cart");
        Console.WriteLine("| Enter 4: Logout");
        Console.WriteLine();
        Console.WriteLine("Enter your options here: ");
    }
    
    
    // UI for product
    public static int EnterProductId()
    {
        Console.WriteLine("Enter product ID: ");
        return int.Parse(Console.ReadLine());
    }

    public static int EnterProductIdToDelete()
    {
        Console.WriteLine("Enter product ID: ");
        return int.Parse(Console.ReadLine());
    }

    public static double EnterProductPrice()
    {
        Console.WriteLine("Enter price: ");
        return Double.Parse(Console.ReadLine());
    }

    public static string EnterProductName()
    {
        Console.WriteLine("Enter name of product: ");
        return Console.ReadLine();
    }

    public static string EnterProductCategory()
    {
        Console.WriteLine("Enter category of product: ");
        return Console.ReadLine();
    }

    public static int EnterExistProductId()
    {
        Console.WriteLine("Enter the ID of product: ");
        return int.Parse(Console.ReadLine());
    } 


    // show error
    public static string DialogIdExisted()
    {
        return "Can not create! Id already exist!, try another!";
    }
    
    // modify message successfully!
    public static void ModifySuccessfully()
    {
        Console.WriteLine("Modify data successfully!");;
    }
    
    //  bought product successfully
    public static void BoughtSuccessfully()
    {
        Console.WriteLine("Bought product successfully!");
    }
    
    // modify message fail!
    public static string ModifyFailed()
    {
        return "Modify data failed!";
    }
    
    
    
    // for purchase product
    public static int EnterPurchaseId()
    {
        Console.WriteLine("Enter purchase Id: ");
        return int.Parse(Console.ReadLine());
    }

    public static int EnterQuantity()
    {
        Console.WriteLine("Enter quantity: ");
        return int.Parse(Console.ReadLine());
    }
    
}