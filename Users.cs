namespace Appointment;

public class Users

{
    //Definition of a public property names UserList, representing a list of User objects.
    public List<Users> userList { get; set; }

    //Constrctor method for the Users class.
    public Users()
    {
        //Initialization of the UserList property with a new instance of List<User>.
        userList = new List<User>();
    }

    //Method for authenticating a user based on their username and password.
    public User Authenticate(string username, string password)
    {
        var u = userList.Where(o => o.Username == username && o.Password == password);

        if (u.Count() > 0)
        {
            return u.First();
        }
        else
        {
            return null;
        }
    }
}
