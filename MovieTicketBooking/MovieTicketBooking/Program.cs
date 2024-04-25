using System;
using System.Collections.Generic;
namespace MovieTicketBooking;

class Program
{
    
    //creating list for storing instances
    public static CustomList<UserDetails> userDetailsList = new CustomList<UserDetails>();
    public static CustomList<BookingDetails> bookingDetailsList = new CustomList<BookingDetails>();
    public static CustomList<TheatreDetails> theatreDetailsList = new CustomList<TheatreDetails>();
    public static CustomList<MovieDetails> movieDetailsList = new CustomList<MovieDetails>();
    public static CustomList<ScreeningDetails> screeningDetailsList = new CustomList<ScreeningDetails>();

    //static variable to store current login user
    static UserDetails currentUser;
    public static void Main(string[] args)
    {
        //calling method to add default data
        FileHadling.Create();
        AddDefaultData();

        //asking option for main menu and validating
        int option;
        do
        {
            bool tempOption;
            do
            {
                Console.WriteLine("-------------Main-Menu------------\n1.User Registration\n2.Login\n3.Exit");
                tempOption = int.TryParse(Console.ReadLine(), out option);
                if (!tempOption)
                    Console.WriteLine("Invalid option");
            }
            while (!tempOption);

            switch (option)
            {
                //Registration method called
                case 1:
                    Registration();
                    break;
                //Login method called
                case 2:
                    Login();
                    break;
                //Exit option
                case 3:
                    Console.WriteLine("Thank You... See you again :-)");
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
        while (option != 3);
        FileHadling.WriteToCSV();
    }
    public static void AddDefaultData()
    {
        //adding default data to userList
        userDetailsList.Add(new UserDetails(1000, "Ravichandran", 30, 8599488003));
        userDetailsList.Add(new UserDetails(2000, "Baskaran", 30, 9857747327));

        //adding default data to booking list
        bookingDetailsList.Add(new BookingDetails("UID1001", "MID501", "TID301", 1, 200, BookingStatus.Booked));
        bookingDetailsList.Add(new BookingDetails("UID1001", "MID504", "TID302", 1, 400, BookingStatus.Booked));
        bookingDetailsList.Add(new BookingDetails("UID1002", "MID505", "TID302", 1, 300, BookingStatus.Booked));

        //adding default data to theatre list
        theatreDetailsList.Add(new TheatreDetails("Inox", "Anna Nagar"));
        theatreDetailsList.Add(new TheatreDetails("Ega Theatre", "Chetpet"));
        theatreDetailsList.Add(new TheatreDetails("Kamala", "Vadapalani"));

        //adding default data to movie list
        movieDetailsList.Add(new MovieDetails("Bahubali2", "Telugu"));
        movieDetailsList.Add(new MovieDetails("Ponniyin Selvan", "Tamil"));
        movieDetailsList.Add(new MovieDetails("Cobra", "Tamil"));
        movieDetailsList.Add(new MovieDetails("Vikram", "Hindi(Dubbed)"));
        movieDetailsList.Add(new MovieDetails("Vikram", "Tamil"));
        movieDetailsList.Add(new MovieDetails("Beast", "English"));

        //adding default data to screening list
        screeningDetailsList.Add(new ScreeningDetails("MID501", "TID301", 200, 5));
        screeningDetailsList.Add(new ScreeningDetails("MID502", "TID301", 300, 2));
        screeningDetailsList.Add(new ScreeningDetails("MID506", "TID301", 50, 1));
        screeningDetailsList.Add(new ScreeningDetails("MID501", "TID302", 400, 11));
        screeningDetailsList.Add(new ScreeningDetails("MID505", "TID302", 300, 20));
        screeningDetailsList.Add(new ScreeningDetails("MID504", "TID302", 500, 2));
        screeningDetailsList.Add(new ScreeningDetails("MID505", "TID303", 100, 11));
        screeningDetailsList.Add(new ScreeningDetails("MID502", "TID303", 200, 20));
        screeningDetailsList.Add(new ScreeningDetails("MID504", "TID303", 350, 2));
    }
    public static void Registration()
    {
        //Getting name from the user
        Console.WriteLine("Enter your name : ");
        string name = Console.ReadLine();

        //getting age
        bool tempAge;
        int age;
        do
        {
            Console.WriteLine("Enter your age");
            tempAge = int.TryParse(Console.ReadLine(), out age);
            if (!tempAge)
                Console.WriteLine("Invalid Input");
        }
        while (!tempAge);

        //getting phone number
        bool tempPhone;
        long phoneNumber;
        do
        {
            Console.WriteLine("Enter your Phone number");
            tempPhone = long.TryParse(Console.ReadLine(), out phoneNumber);
            if (!tempPhone)
                Console.WriteLine("Invalid Input");
        }
        while (!tempPhone);

        //creating object for user details and adding to list
        UserDetails user = new UserDetails(0, name, age, phoneNumber);
        userDetailsList.Add(user);

        //Displaying registered message
        Console.WriteLine("You are successfully registered... Your user ID is " + user.UserID);
        Console.WriteLine("Your initial wallet balance is 0. If you want to book ticket you have to recharge your wallet while logging in");
    }
    public static void Login()
    {
        //getting user ID from user and validating
        int count;
        do
        {
            count = 0;
            Console.WriteLine("Enter user ID : ");
            string uid = Console.ReadLine().ToUpper();
            foreach (UserDetails user in userDetailsList)
            {
                if (uid.Equals(user.UserID))
                {
                    count++;
                    //storing user in static current user
                    currentUser = user;
                    Console.WriteLine("Welcome " + user.Name);
                    //calling submenu method
                    SubMenu();
                }
            }
            if (count == 0)
                Console.WriteLine("Invalid user ID");
        }
        while (count == 0);
    }
    public static void SubMenu()
    {
        //getting submenu option and validating
        char process;
        do
        {
            bool tempProcess;
            do
            {
                Console.WriteLine("---------Sub-Menu----------\na.Ticket Booking\nb.Ticket Cancellation\nc.Booking History\nd.Wallet Recharge\ne.Show Wallet Balance\nf.Exit");
                tempProcess = char.TryParse(Console.ReadLine(), out process);
                if (!tempProcess)
                    Console.WriteLine("Invalid option");
            }
            while (!tempProcess);

            switch (process)
            {
                //ticket booking called
                case 'a':
                    TicketBooking();
                    break;
                //ticket cancellation called
                case 'b':
                    TicketCancellation();
                    break;
                //booking history called
                case 'c':
                    BookingHistory();
                    break;
                //wallet recharge called
                case 'd':
                    WalletRecharge();
                    break;
                //show wallet balance called
                case 'e':
                    ShowWalletBalance();
                    break;
                //Logout successfully
                case 'f':
                    Console.WriteLine("Logout Successfully");
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

        }
        while (process != 'f');
    }
    public static void TicketBooking()
    {
        //showing theatre details
        Console.WriteLine("Theatre ID\t|Theatre Name\t|Theatre Location");
        Console.WriteLine("------------------------------------------------------------------");
        foreach (TheatreDetails theatre in theatreDetailsList)
        {
            Console.WriteLine($"{theatre.TheatreID,-10}\t|{theatre.TheatreName,-10}\t|{theatre.TheatreLocation,-10}");
        }

        //getting theatre ID from user
        int count;
        string tid;
        do
        {
            count = 0;
            Console.WriteLine("Enter theatre ID : ");
            tid = Console.ReadLine().ToUpper();

            //showing movie list in this theatre
            foreach (ScreeningDetails screening in screeningDetailsList)
            {
                if (tid == screening.TheatreID)
                {
                    count++;
                    if (count == 1)
                    {
                        Console.WriteLine("Movie ID\t|Movie Name\t\t|Language");
                        Console.WriteLine("-------------------------------------------------------");
                    }
                    foreach (MovieDetails movie in movieDetailsList)
                    {
                        if (screening.MovieID == movie.MovieID)
                        {
                            Console.WriteLine($"{movie.MovieID,-10}\t|{movie.MovieName,-15}\t|{movie.Language,-10}");
                        }
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Invalid Theatre ID");
            }
        }
        while (count == 0);

        //getting movie ID and validating
        int count1;
        do
        {
            count1 = 0;
            Console.WriteLine("Enter movie ID : ");
            string mid = Console.ReadLine().ToUpper();

            //showing movie list in this theatre
            foreach (ScreeningDetails screening in screeningDetailsList)
            {
                if (tid == screening.TheatreID)
                {
                    foreach (MovieDetails movie in movieDetailsList)
                    {
                        if (mid == movie.MovieID && mid == screening.MovieID)
                        {
                            count1++;
                            //getting number of seats you want
                            Console.WriteLine("Enter number of seats you want");
                            bool tempSeat;
                            int seat;
                            do
                            {
                                tempSeat = int.TryParse(Console.ReadLine(), out seat);
                                if (!tempSeat)
                                    Console.WriteLine("Invalid Input enter again");
                            }
                            while (!tempSeat);

                            //checking availablility of seat
                            if (seat <= screening.NoOfSeats)
                            {
                                //calculating total amount
                                double totalAmount = (screening.TicketPrice * seat);
                                totalAmount += totalAmount * 0.18;

                                //checking user balance and comparing
                                if (currentUser.WalletBalance >= totalAmount)
                                {
                                    //deduct seat and amount
                                    screening.NoOfSeats -= seat;
                                    currentUser.DeductBalance(totalAmount);

                                    //creating booking object and adding to booking list
                                    BookingDetails details = new BookingDetails(currentUser.UserID, mid, tid, seat, totalAmount, BookingStatus.Booked);
                                    bookingDetailsList.Add(details);

                                    //displaying message to user
                                    Console.WriteLine("Tickets booked successfully");
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient Wallet Balance... Please recharge your wallet");
                                }

                            }
                            else
                            {
                                Console.WriteLine($"Your expected seat count not available... Current available seat count is {screening.NoOfSeats}");
                            }
                        }
                    }
                }
            }
            if (count1 == 0)
                Console.WriteLine("Invalid movie ID");
        }
        while (count1 == 0);

    }
    public static void TicketCancellation()
    {
        //Show the booking history of current logged in user
        int count = 0;
        Console.WriteLine("Booking ID\t|Movie ID\t|Theatre ID\t|Seat Count\t|Total Amount");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        foreach (BookingDetails booking in bookingDetailsList)
        {
            if (currentUser.UserID == booking.UserID && booking.BookingStatus == BookingStatus.Booked)
            {
                count++;
                Console.WriteLine($"{booking.BookingID,-10}\t|{booking.MovieID,-10}\t|{booking.TheatreID,-10}\t|{booking.SeatCount,-10}\t|{booking.TotalAmount,-10}\t");
            }
        }
        //if there are no bookings, display a message
        if (count == 0)
            Console.WriteLine("No Bookings Yet");
        else
        {
            //asking booking id he want to cancel and validating
            int count1;
            do
            {
                count1 = 0;
                Console.WriteLine("Enter booking ID to cancel");
                string bid = Console.ReadLine().ToUpper();
                foreach (BookingDetails booking in bookingDetailsList)
                {
                    if (booking.BookingID.Equals(bid) && booking.BookingStatus == BookingStatus.Booked)
                    {
                        count1++;

                        //Getting the count of seat booking from history and increase the seat availability value in the movie list
                        foreach (ScreeningDetails screening in screeningDetailsList)
                        {
                            if (screening.MovieID.Equals(booking.MovieID) && screening.TheatreID == booking.TheatreID)
                            {
                                screening.NoOfSeats += booking.SeatCount;
                            }
                        }

                        //Reducing Rs 20 from total amount and adding the remaining amount to user’s wallet 
                        currentUser.WalletRecharge(booking.TotalAmount - 20);

                        //changing booking status to cancelled and displaying message
                        booking.BookingStatus = BookingStatus.Cancelled;
                        Console.WriteLine($"Booking ID {booking.BookingID} is Cancelled");

                    }
                }
                if (count1 == 0)
                    Console.WriteLine("Invalid Booking ID");
            }
            while (count1 == 0);
        }

    }
    public static void BookingHistory()
    {
        //displaying history of booking of current user
        int count = 0;
        Console.WriteLine("Booking ID\t|Movie ID\t|Theatre ID\t|Seat Count\t|Total Amount\t|Booking Status");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        foreach (BookingDetails booking in bookingDetailsList)
        {
            if (currentUser.UserID == booking.UserID)
            {
                count++;
                Console.WriteLine($"{booking.BookingID,-10}\t|{booking.MovieID,-10}\t|{booking.TheatreID,-10}\t|{booking.SeatCount,-10}\t|{booking.TotalAmount,-10}\t|{booking.BookingStatus,-10}");
            }
        }
        //if there are no bookings, display a message
        if (count == 0)
            Console.WriteLine("No Bookings Yet");
    }
    public static void WalletRecharge()
    {
        //getting confirmation from the user
        string opinion;
        do
        {
            Console.WriteLine("Do you want to recharge : yes/no");
            opinion = Console.ReadLine().ToLower();
            if (opinion != "yes" && opinion != "no")
                Console.WriteLine("Invalid input");
        }
        while (opinion != "yes" && opinion != "no");

        if (opinion == "yes")
        {
            //getting amount from user
            bool tempAmount;
            double amount;
            do
            {
                Console.WriteLine("Enter the amount you have to recharge");
                tempAmount = double.TryParse(Console.ReadLine(), out amount);
                if (!tempAmount)
                    Console.WriteLine("Invalid Input");
            }
            while (!tempAmount);

            currentUser.WalletRecharge(amount);
            Console.WriteLine("Recharge successfull");
        }
        else
        {
            Console.WriteLine("Wallet recharge terminated");
        }
    }
    public static void ShowWalletBalance()
    {
        //displaying wallet balance of the user
        Console.WriteLine($"Your current wallet balance is {currentUser.WalletBalance}");
    }
}
