namespace Appointment;


//Saffari, K.(2024). ClassProject003.GitHub.https://github.com/saffarizadeh/ClassProject003/blob/development/Customers.cs
public class Users
{
    // Definition of a public property named userList, representing a list of User objects.
    public List<User> userList { get; set; }

    // Constructor method for the Users class.
    public Users()
    {
        // Initialization of the userList property with a new instance of List<User>.
        userList = new List<User>();
    }

    // Method for authenticating a user based on their username and password.
    public User Authenticate(string username, string password)
    {
    // to filter users in the userList based on the provided username and password.
        var u = userList.Where(o => o.Username == username && o.Password == password);

        // Check if any user matches the provided credentials.

        if (u.Count() > 0)
        {
         // If a matching user is found, return the first matching user.

            return u.First();
        }
        else
        {
         // If no matching user is found, return null.

            return null;
        }
    }
}
