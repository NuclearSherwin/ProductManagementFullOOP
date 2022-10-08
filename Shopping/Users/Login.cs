// using System.Threading.Channels;
// using Shopping.Products;
//
// namespace Shopping.Users;
//
// public class Login : ILogin
// {
//     // list user and roles
//     private List<Person> _accountList = new List<Person>();
//     
//     
//     
//     // create store object
//     private static Store storeServices = new Store();
//     
//     // create client object
//     private static Client _clientServices = new Client();
//     
//     
//     // get and set method
//     public static Store StoreServices
//     {
//         get { return storeServices; }
//         set { storeServices = value; }
//     }
//
//     public static Client ClientServies
//     {
//         get { return _clientServices; }
//         set { _clientServices = value; }
//     }
//
//
//     // Login as user
//     public bool LoginAsUser(string inputUserName, string inputPassword)
//     {
//
//         string usernameUser = "user";
//         string passwordUser = "user";
//         
//         if (inputUserName == usernameUser && inputPassword == passwordUser)
//         {
//             LoginUiForClient();
//             Program.isLogin = true;
//                 return true;
//
//         }
//         else
//         {
//             return false;
//         }
//     }
//
//     // checking user name and password for store owner as store owner
//     public bool LoginAsStoreOwner(string inputUserName, string inputPassword)
//     {
//         string usernameUser = "storeowner";
//         string passwordUser = "storeowner";
//         
//         if (inputUserName == usernameUser && inputPassword == passwordUser)
//         {
//             LoginUiForStoreOwner();
//             Program.isLogin = true;
//             return true;
//         }
//         else
//         {
//             return false;
//         }
//     }
//     
//     // login ui for user
//     public static void LoginUiForClient()
//     {
//         Console.WriteLine();
//         Console.WriteLine("| Enter 1: Add client account ");
//         Console.WriteLine("| Enter 2: Show all products");
//         Console.WriteLine("| Enter 3: Purchase a product");
//         Console.WriteLine("| Enter 4: Logout");
//         Console.WriteLine();
//         Console.WriteLine("Enter your options here: ");
//
//         string chosenNum = Console.ReadLine();
//         switch (chosenNum)
//         {
//             case "1":
//                 _clientServices.AddPurchase();
//                 break;
//             case "2":
//                 break;
//             case "3":
//                 break;
//             case "4":
//                 break;
//             default:
//                 break;
//         }
//     }
//     
//     
//     
//     // login ui for store owner
//     public void LoginUiForStoreOwner()
//     {
//         Console.WriteLine();
//         Console.WriteLine("| Enter 1: Add product ");
//         Console.WriteLine("| Enter 2: Show all products");
//         Console.WriteLine("| Enter 3: Update product");
//         Console.WriteLine("| Enter 4: Delete product");
//         Console.WriteLine("| Enter 5: Search id of product");
//         Console.WriteLine("| Enter 6: Search name of product");
//         Console.WriteLine("| Enter 7: Logout");
//         Console.WriteLine();
//         Console.WriteLine("Enter your options here: ");
//         
//         string chosenNum = Console.ReadLine();
//
//         switch (chosenNum)
//         {
//             case "1":
//                 StoreServices.AddProduct();
//                 break;
//             case "2":
//                 StoreServices.ShowProducts();
//                 break;
//             case "3":
//                 Console.WriteLine("Enter product ID: ");
//                 var idUpdate = Convert.ToInt32(Console.ReadLine());
//                 StoreServices.UpdateProductById(idUpdate);
//                 break;
//             case "4":
//                 Console.WriteLine("Enter product ID to delete: ");
//                 var idDelete = Convert.ToInt32(Console.ReadLine());
//                 StoreServices.DeleteProduct(idDelete);
//                 break;
//             case "5":
//                 Console.WriteLine("Enter product ID to search");
//                 var idToSearch = Convert.ToInt32(Console.ReadLine());
//                 StoreServices.searchProductById(idToSearch);
//                 break;
//             case "6":
//                 Console.WriteLine("Enter name of product to search");
//                 string nameToSearch = Console.ReadLine();
//                 StoreServices.searchProductByName(nameToSearch);
//                 break;
//             default:
//                 break;
//         }
//     }
//
//     public bool Login(string username, string password)
//     {
//         throw new NotImplementedException();
//     }
// }