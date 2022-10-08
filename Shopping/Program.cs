using System.ComponentModel.Design;
using Shopping;
using Shopping.Products;
using Shopping.Users;

public class Program
{
    // for answer at the end of app
    private static char anwser;
    // check isLogin
    public static bool isLogin = false;
    
    
    // store owner and client
    private static Store store = new Store();
    private static Client client = new Client();
    
    public static void Main(string[] args)
    {
        Console.WriteLine("======================Shopping======================");
        Console.WriteLine();
        
        MenuCommand:
            UserInterface.LoginMenu();
            try
            {
                int chosenNum = int.Parse(Console.ReadLine());
                do
                {
                    switch (chosenNum)
                    {
                        case 1:
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Login as store owner");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Enter username: ");
                                string username = Console.ReadLine();
                                Console.WriteLine("Enter password: ");
                                string password = Console.ReadLine();

                                if (store.Login(username, password))
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Login successfully");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    UserInterface.MenuForStoreOwner();
                                    do
                                    {
                                        int optionStoreOwner = int.Parse(Console.ReadLine());
                                        int productId;
                                        switch (optionStoreOwner)
                                        {
                                            case 1:
                                                try
                                                {
                                                    productId = UserInterface.EnterProductId();
                                                    // check if ID for if exist
                                                    while (store.searchProductById(productId))
                                                    {
                                                        UserInterface.DialogIdExisted();
                                                        productId = UserInterface.EnterProductId();
                                                    }

                                                    // rest of fields
                                                    string productName = Console.ReadLine();
                                                    double productPrice = double.Parse(Console.ReadLine());
                                                    string productCategory = Console.ReadLine();

                                                    // add to productList as store owner
                                                    store.AddProduct(new Product(productId, productName, productPrice,
                                                        productCategory));

                                                    // add successfully
                                                    UserInterface.ModifySuccessfully();
                                                    Console.ForegroundColor = ConsoleColor.Green;

                                                    // repeat menu of store owner
                                                    UserInterface.MenuForStoreOwner();
                                                }
                                                catch (FormatException e)
                                                {
                                                    Console.WriteLine("Please enter right format number: " + e.Message);
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine("Error at: " + e.Message);
                                                }

                                                break;
                                            case 2:
                                                store.ShowProducts();
                                                UserInterface.MenuForStoreOwner();
                                                break;
                                            case 3:
                                                try
                                                {
                                                    int idProductToUpdate = int.Parse(Console.ReadLine());
                                                    while (!store.searchProductById(idProductToUpdate))
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        UserInterface.ModifyFailed();
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        store.UpdateProductById(idProductToUpdate);
                                                    }

                                                    string nameToUpdate = Console.ReadLine();
                                                    string priceToUpdate = Console.ReadLine();
                                                    string categoryUpdate = Console.ReadLine();

                                                    store.UpdateProductById(idProductToUpdate);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    UserInterface.ModifySuccessfully();
                                                    UserInterface.MenuForStoreOwner();

                                                    // enter menu again
                                                    UserInterface.MenuForStoreOwner();
                                                }
                                                catch (FormatException e)
                                                {
                                                    Console.WriteLine("Please enter right format number: " + e.Message);
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine("Error at: " + e.Message);
                                                }

                                                break;
                                            case 4:
                                                try
                                                {
                                                    int idToDelete = UserInterface.EnterProductId();
                                                    while (!store.searchProductById(idToDelete))
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        UserInterface.ModifyFailed();
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        idToDelete = UserInterface.EnterProductId();
                                                    }

                                                    /// delete product
                                                    store.DeleteProduct(idToDelete);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    UserInterface.ModifySuccessfully();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    UserInterface.MenuForStoreOwner();
                                                }
                                                catch (FormatException e)
                                                {
                                                    Console.WriteLine("Please enter right format number: " + e.Message);
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine("Error at: " + e.Message);
                                                }

                                                break;
                                            case 5:
                                                foreach (var product in store.Products)
                                                {
                                                    Console.WriteLine(product.ToString());
                                                }

                                                UserInterface.MenuForStoreOwner();
                                                break;
                                            case 6:

                                                int idToSearchPurchase = UserInterface.EnterProductId();
                                                var userInListPurchaes =
                                                    store.GetUserPurchaseProductById(idToSearchPurchase);
                                                Console.WriteLine(userInListPurchaes.ToString());
                                                UserInterface.MenuForStoreOwner();
                                                break;
                                            case 7:
                                                goto MenuCommand;
                                                break;
                                        }
                                    } while (true);
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Login fail!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    UserInterface.LoginMenu();
                                }

                            } while (chosenNum != 3);

                            break;
                        case 2:
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Login as user");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Enter username");
                                string username = Console.ReadLine();
                                Console.WriteLine("Enter password");
                                string password = Console.ReadLine();
                                
                                // call login function
                                client.Login(username, password);

                                if (store.Login(username, password))
                                {
                                    Console.WriteLine("-----------------------------");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Login successfully");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    UserInterface.MenuForUser();
                                    do
                                    {
                                        int choseNum = int.Parse(Console.ReadLine());
                                        switch (chosenNum)
                                        {
                                            case 1:
                                                store.AddUser();
                                                UserInterface.MenuForUser();
                                                break;
                                            case 2:
                                                store.ShowProducts();
                                                UserInterface.MenuForUser();
                                                break;
                                            case 3:
                                                // purchase product
                                                
                                                break;
                                            case 4:
                                                break;
                                        }
                                    } while (true);
                                }

                            } while (chosenNum != 3);

                            break;
                        case 3:
                            Console.WriteLine("Bye bye");
                            break;
                    }
                } while (chosenNum < 3);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please enter right format number: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error at: " + e.Message);
            }
            
            
        
        
        
        
    //     // Create Login object
    //     Login loginServices = new Login();
    //     
    //     
    //     do
    //     {
    //         // area for cookie already login
    //         // if you already login, then don't need to login again
    //         if (isLogin == true)
    //         {
    //             Console.Clear();
    //             loginServices.LoginUiForStoreOwner();
    //         }
    //         else
    //         {
    //             Console.Clear();
    //         
    //             // Login UI
    //             LoginUserInterface();
    //
    //             Console.Write("Enter your choice: ");
    //             string chosenNum = Console.ReadLine();
    //
    //             switch (chosenNum)
    //             {
    //                 case "1":
    //                     Console.WriteLine("Enter username:");
    //                     string username = Console.ReadLine();
    //                     Console.WriteLine("Enter password:");
    //                     string password = Console.ReadLine();
    //                     loginServices.LoginAsUser(username, password);
    //                     
    //
    //                     break;
    //                 case "2":
    //                     Console.WriteLine("Enter username:");
    //                     string storeName = Console.ReadLine();
    //                     Console.WriteLine("Enter password:");
    //                     string storePassword = Console.ReadLine();
    //                     loginServices.LoginAsStoreOwner(storeName, storePassword);
    //                     
    //                     break;
    //         
    //           
    //                 default:
    //                     Console.WriteLine("Invalid choice!  please enter again!");
    //                     break;
    //             }
    //         }
    //         
    //     
    //         // verify continue or not
    //         Console.WriteLine();
    //     Console.Write("Would you like to continue(Y/N): ");
    //     anwser = Convert.ToChar(Console.ReadLine());
    //     } while (anwser == 'y' || anwser == 'Y');
    //
    //     Console.WriteLine("Bye bye!");
    // }
    //
    //
    // // login user interface
    // public static void LoginUserInterface()
    // {
    //     Console.WriteLine();
    //     Console.WriteLine("| Enter 1: Login as a client (user)");
    //     Console.WriteLine("| Enter 2: Login as a store owner");
    //     Console.WriteLine();
    //     Console.Write("Please enter your choice: ");
    }

}

