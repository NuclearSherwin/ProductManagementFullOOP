using System.ComponentModel.Design;
using Shopping;
using Shopping.Order;
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
                                                    while (store.checkProductId(productId))
                                                    {
                                                        UserInterface.DialogIdExisted();
                                                        productId = UserInterface.EnterProductId();
                                                    }

                                                    // rest of fields
                                                    string productName = UserInterface.EnterProductName();
                                                    double productPrice = UserInterface.EnterProductPrice();
                                                    string productCategory = UserInterface.EnterProductCategory();

                                                    // add to productList as store owner
                                                    store.AddProduct(new Product(productId, productName, productPrice,
                                                        productCategory));

                                                    // add successfully
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    UserInterface.ModifySuccessfully();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    

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
                                                // store.ShowProducts();
                                                // UserInterface.MenuForStoreOwner();
                                                foreach (var product in store.Products)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine(product.ToString());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                                UserInterface.MenuForStoreOwner();
                                                break;
                                            case 3:
                                                try
                                                {
                                                    Console.WriteLine("Enter product ID: ");
                                                    int idProductToUpdate = int.Parse(Console.ReadLine());
                                                    while (!store.checkProductId(idProductToUpdate))
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        UserInterface.ModifyFailed();
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        store.UpdateProductById(idProductToUpdate);
                                                    }

                                                    // string nameToUpdate = UserInterface.EnterProductName();
                                                    // double priceToUpdate = UserInterface.EnterProductPrice();
                                                    // string categoryUpdate = UserInterface.EnterProductCategory();

                                                    store.UpdateProductById(idProductToUpdate);
                                                    
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    UserInterface.ModifySuccessfully();
                                                    Console.ForegroundColor = ConsoleColor.White;

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
                                                    int idToDelete = UserInterface.EnterProductIdToDelete();
                                                    while (!store.checkProductId(idToDelete))
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
                                                int idToUpdate = UserInterface.EnterExistProductId();
                                                store.searchProductById(idToUpdate);
                                                UserInterface.MenuForStoreOwner();
                                                break;
                                            case 6:
                                                string nameToSearch = UserInterface.EnterProductName();
                                                store.searchProductByName(nameToSearch);
                                                UserInterface.MenuForStoreOwner();
                                                break;
                                            case 7:
                                                // show order details
                                                Console.WriteLine("Order details: ");
                                                foreach (var orderDetail in store.OrderDetails)
                                                {
                                                    
                                                    Console.WriteLine();
                                                    Console.WriteLine($"{orderDetail.Product.ProductId}");
                                                    Console.WriteLine($"{orderDetail.Purchase.Client.ClientId}");
                                                    Console.WriteLine($"{orderDetail.Quantity}");
                                                }
                                                UserInterface.MenuForStoreOwner();
                                                break;
                                            case 8:
                                                int idToSearchPurchase = UserInterface.EnterClientId();
                                                var userInListPurchase =
                                                    store.GetUserPurchaseProductById(idToSearchPurchase);
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine(userInListPurchase.ToString());
                                                Console.ForegroundColor = ConsoleColor.White;
                                                UserInterface.MenuForStoreOwner();
                                                break;
                                            case 9:
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
                                Console.ForegroundColor = ConsoleColor.White;
                                
                                string username = UserInterface.EnterUserName();
                                string password = UserInterface.EnterUserPassword();
                                
                                // call login function
                                client.Login(username, password);

                                if (client.Login(username, password))
                                {
                                    Console.WriteLine("-----------------------------");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Login successfully");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    UserInterface.MenuForUser();
                                    do
                                    {
                                        int inputNum = int.Parse(Console.ReadLine());
                                        switch (inputNum)
                                        {
                                            case 1:
                                                store.AddUser();
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Add account successfully!");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                UserInterface.MenuForUser();
                                                break;
                                            case 2:
                                                store.ShowProducts();
                                                UserInterface.MenuForUser();
                                                break;
                                            case 3:
                                                // try - catch
                                                try
                                                {
                                                // first enter user id and check that id must be exist so that ID can purchase product
                                                int purchaseId = UserInterface.EnterPurchaseId();
                                                
                                                Client newClient = new Client();
                                                newClient.ClientId = UserInterface.EnterClientId();
                                                
                                                while (!store.SearchUserById(newClient.ClientId))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("User id is not exits! Add a new one");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    newClient.ClientId = UserInterface.EnterClientId();
                                                }
                                                
                                                // then create to purchase
                                                Client userInList = store.searchUserWithObjType(newClient.ClientId);
                                                DateTime purchaseDate = DateTime.Now;
                                                Purchase productPurchase =
                                                    new Purchase(purchaseId, userInList, purchaseDate);
                                               
                                                
                                                // then add to list
                                                userInList.AddPurchase(productPurchase);
                                                
                                                Console.WriteLine("Quantity of product: ");
                                                int productQuantity = int.Parse(Console.ReadLine());
                                                for (int i = 0; i < productQuantity; i++)
                                                {
                                                    Product product = new Product();
                                                    product.ProductId = UserInterface.EnterProductId();
                                                    while (!store.checkProductId(product.ProductId))
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("ID of purchase does not exist!");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        product.ProductId = UserInterface.EnterProductId();
                                                    }

                                                    Product productInList =
                                                        store.searchProductWithObjType(product.ProductId);
                                                    Console.WriteLine(productInList.ToString());
                                                    
                                                    // Finally add to order detail
                                                    OrderDetail orderDetail =
                                                        new OrderDetail(productInList, 
                                                            productPurchase, UserInterface.EnterQuantity());
                                                    productPurchase.AddOrderDetail(orderDetail);
                                                    productInList.AddOrderDetail(orderDetail);
                                                    
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    UserInterface.ModifySuccessfully();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                                UserInterface.MenuForUser();
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
                                                int userId = UserInterface.EnterClientId();
                                                var userInListPurchase = store.GetUserPurchaseProductById(userId);
                                                Console.WriteLine(userInListPurchase.ToString());
                                                int purchasedId = UserInterface.EnterPurchaseId();
                                                var foundPurchase = userInListPurchase.searchPurchaseById(purchasedId);

                                                foreach (var removeProductPurchase in foundPurchase.OrderDetailsList)
                                                {
                                                    removeProductPurchase.Product.RemoveOrderDetail(foundPurchase);
                                                }

                                                userInListPurchase.RemovePurchase(foundPurchase);
                                                Console.WriteLine("Remove successfully");
                                                UserInterface.MenuForUser();
                                                break;
                                            case 5:
                                                goto MenuCommand;
                                        }
                                    } while (true);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Username or password incorrect!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    UserInterface.LoginMenu();
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

