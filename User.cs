namespace Appointment;

public class User
{
    private static int autoIncrement;
    public int ID{get;} //This will be the properties representing the attributes of the user

    public string FirstName {get; set;} // This is the first name of the user, the get and set will allow this to be written
    public string LastName {get; set;} // This will be the last name of the user 
    public string Username {get; set;} // Username is used to identify the user
    public string Password {get; set;} // Password is used to identify the user 

    public User()
    {
        autoIncrement++;
        ID = autoIncrement; 
        
    }

}
