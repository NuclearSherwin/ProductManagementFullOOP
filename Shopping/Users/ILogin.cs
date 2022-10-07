namespace Shopping.Users;

public interface ILogin
{
    // bool Login(string username, string password);
    public bool LoginAsUser(string username, string password);
    public bool LoginAsStoreOwner(string username, string password);
}