namespace Shopping;

public class UserInterface
{
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
}