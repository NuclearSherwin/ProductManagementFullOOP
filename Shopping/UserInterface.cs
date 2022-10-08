namespace Shopping;

public class UserInterface
{
    // for user info
    public static int EnterUserName()
    {
        Console.WriteLine("Enter user name: ");
        return Convert.ToInt32(Console.ReadLine());
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
    
    
    
    // for login
    public static void LoginMenu()
    {
        Console.WriteLine();
        Console.WriteLine("1. Login as user");
        Console.WriteLine("2. Login as store owner");
        Console.WriteLine("Enter your number: ");
        Console.WriteLine();
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
        Console.WriteLine("| Enter 7: Logout");
        Console.WriteLine();
        Console.WriteLine("Enter your options here: ");
    }

    public static void MenuForUser()
    {
        Console.WriteLine();
        Console.WriteLine("| Enter 1: Add client account ");
        Console.WriteLine("| Enter 2: Show all products");
        Console.WriteLine("| Enter 3: Purchase a product");
        Console.WriteLine("| Enter 4: Logout");
        Console.WriteLine();
        Console.WriteLine("Enter your options here: ");
    }
    
    
    // UI for product
    public static int EnterProductId()
    {
        Console.WriteLine("Enter new product ID: ");
        return int.Parse(Console.ReadLine());
    }

    public static double EnterProductPrice()
    {
        Console.WriteLine("Enter price: ");
        return Double.Parse(Console.ReadLine());
    }

    public static string EnterProductName()
    {
        Console.WriteLine("Enter productName");
        return Console.ReadLine();
    }

    public static string EnterProductCategory()
    {
        Console.WriteLine("Enter category of product: ");
        return Console.ReadLine();
    }
    
    
    // show error
    public static string DialogIdExisted()
    {
        return "Can not create! Id already exist!, try another!";
    }
    
    // modify message successfully!
    public static string ModifySuccessfully()
    {
        return "Modify data successfully!";
    }
    
    // modify message fail!
    public static string ModifyFailed()
    {
        return "Modify data failed!";
    }
}