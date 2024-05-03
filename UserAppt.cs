namespace Appointment;

// // Saffari, K.(2024). ClassProject003.GitHub.https://github.com/saffarizadeh/ClassProject003/blob/development/CustomerAppointment.cs

public class UserAppt
{
    // Definition of a public property named u, representing a User object.
    public User u { get; set; }

    // Definition of a public property named a, representing an App object.

    public Appt a { get; set; }

    // // Constructor method for the UserAppt class.

    public UserAppt(User u, Appt a)
    {
        // Assigning the provided User object to the u property
        this.u = u;
        // Assigning the provided Appt object to the a property
        this.a = a;
    }
}
