﻿namespace Appointment;

class Program
{
    private static Users users;
    private static List<Appt> appointments;
    private static List<UserAppt> userAppointments;
    private static User authenticatedUser;

    static void Main(string[] args)
    {
        Console.WriteLine("Initializing...");
        Initialize();
        Menu();
    }

    static void Initialize()
    {
        var c1 = new User
        {
            FirstName = "Kambiz",
            LastName = "Saffari",
            Username = "kambiz",
            Password = "1234"
        };

        var c2 = new User
        {
            FirstName = "Jeremy",
            LastName = "Lee",
            Username = "jlee",
            Password = "9876"
        };

        var a1 = new Appt();
        var a2 = new Appt();
        var a3 = new Appt();

        var ca1 = new UserAppt(c1, a1);
        var ca2 = new UserAppt(c1, a2);
        var ca3 = new UserAppt(c2, a3);

        users = new Users();
        users.userList.Add(c1);
        users.userList.Add(c2);

        userAppointments = new List<UserAppt>();
        userAppointments.Add(ca1);
        userAppointments.Add(ca2);
        userAppointments.Add(ca3);

        appointments = new List<Appt>();
        appointments.Add(a1);
        appointments.Add(a2);
        appointments.Add(a3);

    }

    static void Menu()
    {
        bool done = false;

        while (!done)
        {
            Console.WriteLine("Options: Login: 1, Logout: 2, Sign Up: 3, Appointments: 4, Quit: q");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    LoginMenu();
                    break;
                case "2":
                    LogOutMenu();
                    break;
                case "3":
                    SignUpMenu();
                    break;
                case "4":
                    AppointmentsMenu();
                    break;
                case "q":
                    done = true;
                    break;
                default:
                    Console.WriteLine("Invalid command!");
                    break;
            }

        }


    }

    static void LoginMenu()
    {
        if(authenticatedUser == null)
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            authenticatedUser= users.Authenticate(username, password);
            if (authenticatedUser != null)
            {
                Console.WriteLine($"Welcome {authenticatedUser.FirstName}");
            }
            else
            {
                Console.WriteLine("Invalid username or password");
            }
        }


    }

    static void LogOutMenu()
    {
        authenticatedUser = null;
        Console.WriteLine("Logged out!");
    }

    static void SignUpMenu()
    {
        Console.Write("First Name: ");
        string firstname = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastname = Console.ReadLine();
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        var newCustomer = new User
        {
            FirstName = firstname,
            LastName = lastname,
            Username = username,
            Password = password
        };
        users.userList.Add(newCustomer);
        Console.WriteLine("Profile created!");
        
    }

    static void AppointmentsMenu()
    {
        if (authenticatedUser == null)
        {
            Console.WriteLine("Please log in first!");
            return;
        }

         var colleges = new List<string>
        {
            "Helen Way Klingler College of Arts and Sciences",
            "College of Business Administration",
            "J. William and Mary Diederich College of Communication",
            "College of Education",
            "College of Engineering",
            "College of Health Sciences",
            "College of Nursing"
        };

        Console.WriteLine("Colleges:");
        for (int i = 0; i < colleges.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {colleges[i]}");

        }

        // Get user selection of college
        Console.Write("Enter college number (1-7): ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int selection) && selection >= 1 && selection <= 7)
        {
            string selectedCollege = colleges[selection - 1];
            Console.WriteLine($"You selected: {selectedCollege}");

            // Display advisors associated with the selected college
            DisplayAdvisors(selectedCollege);

            // Prompt user to select an advisor
        Console.Write("Enter advisor's name: ");
        string advisorName = Console.ReadLine();

        // Check if the entered advisor exists for the selected college
        var advisorsByCollege = GetAdvisorsByCollege();
        if (advisorsByCollege.ContainsKey(selectedCollege) && advisorsByCollege[selectedCollege].Contains(advisorName))
        {
            // Display availability for the selected advisor
            DisplayAvailability(selectedCollege, advisorName);
        }
        else
        {
            Console.WriteLine("Invalid advisor name!");
        }
    }
    else
    {
        Console.WriteLine("Invalid selection!");
    }

    var appointmentList = userAppointments.Where(o => o.u.Username == authenticatedUser.Username);
    if (appointmentList.Count() == 0)
    {
        Console.WriteLine("0 appointments found.");
    }
    else
    {
        Console.WriteLine("Your Appointment:");
        foreach (var appointment in appointmentList)
        {
            Console.WriteLine(appointment.a.dateTime);
        }
    }
}

    
    static Dictionary<string, List<string>> GetAdvisorsByCollege()
    {
            return new Dictionary<string, List<string>>
            {
            ["Helen Way Klingler College of Arts and Sciences"] = new List<string> { "Mr. Michael O'Brien", "Mr. John Fenelon", "Ms. Emily Smith" },
            ["College of Business Administration"] = new List<string> { "Ms. Sarah Johnson", "Mr. Robert Davis", "Ms. Lisa Anderson" },
            ["J. William and Mary Diederich College of Communication"] = new List<string> { "Ms. Laura Taylor", "Mr. David Wilson", "Ms. Samantha Brown" },
            ["College of Education"] = new List<string> { "Ms. Jennifer Lee", "Mr. Matthew Clark", "Ms. Elizabeth Martinez" },
            ["College of Engineering"] = new List<string> { "Mr. Kevin White", "Ms. Amanda Taylor", "Mr. Brian Adams" },
            ["College of Health Sciences"] = new List<string> { "Dr. Rachel Smith", "Ms. Jessica Wilson", "Dr. Andrew Johnson" },
            ["College of Nursing"] = new List<string> { "Dr. Lisa Garcia", "Ms. Megan Anderson", "Dr. James Thompson" }
            };

            }

    static void DisplayAdvisors(string college)
    {
        var advisorsByCollege = GetAdvisorsByCollege();

        if (advisorsByCollege.ContainsKey(college))
        {
            var advisors = advisorsByCollege[college];
            Console.WriteLine("Advisors:");
            foreach (var advisor in advisors)
            {
                Console.WriteLine(advisor);
            }
        }
        else
        {
            Console.WriteLine("No advisors found for the selected college.");
        }
    }

    static void DisplayAvailability(string college, string advisorName)
    {
        // Placeholder availability schedule
        Console.WriteLine($"Availability for {advisorName} in {college}:");
        Console.WriteLine("Availability for the week:");
        Console.WriteLine("Monday: 9:00 AM - 5:00 PM");
        Console.WriteLine("Tuesday: 9:00 AM - 5:00 PM");
        Console.WriteLine("Wednesday: 9:00 AM - 5:00 PM");
        Console.WriteLine("Thursday: 9:00 AM - 5:00 PM");
        Console.WriteLine("Friday: 9:00 AM - 5:00 PM");
        Console.WriteLine("Saturday: Not available");
        Console.WriteLine("Sunday: Not available");
    }
}
        