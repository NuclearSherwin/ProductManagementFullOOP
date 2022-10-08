using Shopping.Products;
using Shopping.Users;

public class Program
{
    // for answer at the end of app
    private static char anwser;
    // check isLogin
    public static bool isLogin = false;
    
    public static void Main(string[] args)
    {
        
        // Create Login object
        Login loginServices = new Login();
        
        
        do
        {
            // area for cookie already login
            // if you already login, then don't need to login again
            if (isLogin == true)
            {
                Console.Clear();
                loginServices.LoginUiForStoreOwner();
            }
            else
            {
                Console.Clear();
            
                // Login UI
                LoginUserInterface();

                Console.Write("Enter your choice: ");
                string chosenNum = Console.ReadLine();

                switch (chosenNum)
                {
                    case "1":
                        Console.WriteLine("Enter username:");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter password:");
                        string password = Console.ReadLine();
                        loginServices.LoginAsUser(username, password);
                        

                        break;
                    case "2":
                        Console.WriteLine("Enter username:");
                        string storeName = Console.ReadLine();
                        Console.WriteLine("Enter password:");
                        string storePassword = Console.ReadLine();
                        loginServices.LoginAsStoreOwner(storeName, storePassword);
                        
                        break;
            
              
                    default:
                        Console.WriteLine("Invalid choice!  please enter again!");
                        break;
                }
            }
            
        
            // verify continue or not
            Console.WriteLine();
        Console.Write("Would you like to continue(Y/N): ");
        anwser = Convert.ToChar(Console.ReadLine());
        } while (anwser == 'y' || anwser == 'Y');

        Console.WriteLine("Bye bye!");
    }


    // login user interface
    public static void LoginUserInterface()
    {
        Console.WriteLine();
        Console.WriteLine("| Enter 1: Login as a client (user)");
        Console.WriteLine("| Enter 2: Login as a store owner");
        Console.WriteLine();
        Console.Write("Please enter your choice: ");
    }

}

