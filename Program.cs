using TLAC;

Trainer[] trainers = new Trainer[50];
List[] listing = new List[50];
Booking[] bookings = new Booking[50];
Report[] reports = new Report[50];

ListUtility listUtility = new ListUtility(listing);
TrainerUtility trainerUtility = new TrainerUtility(trainers);
BookingUtility bookingUtility = new BookingUtility(bookings, listing);
ReportUtility reportUtility = new ReportUtility(bookings);







string userInput = GetMenuChoice();
while (userInput != "5")
{
    Route(userInput, trainerUtility, listUtility, bookingUtility, reportUtility);
}   





//Main menu
static string GetMenuChoice(){
    DisplayMenu();
    string userInput = Console.ReadLine();

    while (!ValidMenuChoice(userInput))
    {
        Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
        Console.WriteLine("Press any key to continue....");
        Console.ReadKey();

        DisplayMenu();
        userInput = Console.ReadLine();
    }

    return userInput;
}

static void DisplayMenu(){
    Console.Clear();
    Console.WriteLine("1:   Trainer Functions");
    Console.WriteLine("2:   Listing Functions");
    Console.WriteLine("3:   Booking Functions");
    Console.WriteLine("4:   Reports");
}

static bool ValidMenuChoice(string userInput){
    /*Step 1 update ValidMenuChoice to return true if the user 
    entered 1, 2 or 3 and return false if they entered anything else.
    */

    if(userInput == "1" ||userInput == "2" || userInput == "3" || userInput == "4"){
       return true;
    }
    else return false;


}

static void Route(string userInput, TrainerUtility trainerUtility, ListUtility listUtility, BookingUtility bookingUtility, ReportUtility reportUtility){
   
        if(userInput == "1"){
            TrainerFunctions(ref userInput, trainerUtility);
        }
        else if (userInput == "2")
{
    ListingFunctions(ref userInput, listUtility);
}
        else if(userInput == "3"){
            BookingFunctions(ref userInput, bookingUtility, listUtility);
        }

        else if(userInput == "4"){
            ReportFunctions(ref userInput, bookingUtility, listUtility, reportUtility);
        }

}
//end main menu





//trainer functions


static void TrainerFunctions(ref string userInput, TrainerUtility trainerUtility){
    trainerUtility.GetAllTrainersFromFile();
    GetTrainerMenuChoice(ref userInput);
    ValidTrainerMenuChoice(userInput);
    TrainerRoute(userInput, trainerUtility);
}

static string GetTrainerMenuChoice(ref string userInput){
            DisplayTrainerMenu();
            userInput = Console.ReadLine();

            while (!ValidTrainerMenuChoice(userInput))
            {
                Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();

                DisplayTrainerMenu();
                userInput = Console.ReadLine();
            }

            return userInput;
        }


static void DisplayTrainerMenu(){
            Console.Clear();
            System.Console.WriteLine("Trainer Functions");
            Console.WriteLine("1:   Add");
            Console.WriteLine("2:   Edit");
            Console.WriteLine("3:   Delete");
        }

        static bool ValidTrainerMenuChoice(string userInput){
            /*Step 1 update ValidMenuChoice to return true if the user 
            entered 1, 2 or 3 and return false if they entered anything else.
            */

            if(userInput == "1" ||userInput == "2" || userInput == "3"){
            return true;
            }
            else return false;
}

        static void TrainerRoute(string userInput, TrainerUtility trainerUtility){
            /*Step 2: Update to call Snowman if the user entered 1 and 
                * ScoreBoard if they entered 2
                */
                if(userInput == "1"){
                    trainerUtility.AddTrainer();
                }
                if(userInput == "2"){
                    System.Console.WriteLine("What would you like to edit?\n1. Trainer ID\n2. Trainer Name\n3. Mailing Address\n4: Trainer Email Address\n5. Delete trainer");
                    string trainerUserInput = Console.ReadLine();

                    if(trainerUserInput == "1"){
                        trainerUtility.UpdateTrainerID();
                        Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
                    }
                    else if(trainerUserInput == "2"){
                        trainerUtility.UpdateTrainerName();
                        Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
                    }
                    else if(trainerUserInput == "3"){
                        trainerUtility.UpdateTrainerAddress();
                        Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
                    }
                    else if(trainerUserInput == "4"){
                        trainerUtility.UpdateTrainerEmail();
                        Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
                    }
                }
                else if(userInput == "5"){
                    trainerUtility.DeleteTrainer();
                    Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
                }
        }


// begin listing methods

        static void ListingFunctions(ref string userInput, ListUtility listUtility){
            listUtility.GetAllListingsFromFile();
            DisplayListingMenu();
            userInput = GetListingMenuChoice();
            ListingRoute(userInput, listUtility);
        }

        static bool ValidListingMenuChoice(string userInput)
        {
            if (userInput == "1" || userInput == "2" || userInput == "3")
            {
                return true;
            }
            else return false;
        }

        static void DisplayListingMenu()
        {
            Console.Clear();
            Console.WriteLine("Listing Functions");
            Console.WriteLine("1: Add");
            Console.WriteLine("2: Edit");
            Console.WriteLine("3: Delete");
        }


        static string GetListingMenuChoice()
        {
            DisplayListingMenu();
            string userInput = Console.ReadLine();

            while (!ValidListingMenuChoice(userInput))
            {
                Console.WriteLine("Invalid menu choice. Please enter a valid menu choice");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();

                DisplayListingMenu();
                userInput = Console.ReadLine();
            }

            return userInput;
        }




        static void ListingRoute(string userInput, ListUtility listUtility)
        {
            if (userInput == "1")
            {
                listUtility.AddList();
                Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
            }
            else if (userInput == "2")
            {
                System.Console.WriteLine("What would you like to edit?\n1: Listing ID\n2. Trainer Name\n3. Date of session\n4: Time of session\n5: Cost of session\n6: Session status");
                string listingUserInput = Console.ReadLine();

                listUtility.PrintAllLists();
                Console.WriteLine("Press any key to continue....");
        Console.ReadKey();

                if (listingUserInput == "1")
                {
                    listUtility.UpdateListID();
                    Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
                }
                else if (listingUserInput == "2")
                {
                    listUtility.UpdateListName();
                    Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
                }
                else if (listingUserInput == "3")
                {
                    listUtility.UpdateListDate();
                    Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
                }
                else if (listingUserInput == "4")
                {
                    listUtility.UpdateListTime();
                    Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
                }
                else if (listingUserInput == "5")
                {
                    listUtility.UpdateListCost();
                    Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
                }
                else if (listingUserInput == "6")
                {
                    // listUtility.UpdateListAvailability();
                }
            }
            else if (userInput == "3")
            {
                listUtility.DeleteList();
                Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
            }
        }

// end listing methods





//booking methods

static void BookingFunctions(ref string userInput, BookingUtility bookingUtility, ListUtility listUtility){
    
listUtility.GetAllListingsFromFile();
GetBookingMenuChoice(ref userInput);
ValidBookingMenuChoice(userInput);
BookingRoute(userInput, bookingUtility);

}

static string GetBookingMenuChoice(ref string userInput){
            DisplayBookingMenu();
            userInput = Console.ReadLine();

            while (!ValidBookingMenuChoice(userInput))
            {
                Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();

                DisplayBookingMenu();
                userInput = Console.ReadLine();
            }

            return userInput;
        }

static void DisplayBookingMenu()
{
    Console.Clear();
    Console.WriteLine("Booking Functions");
    Console.WriteLine("1: View available training sessions");
    Console.WriteLine("2: Book a session");
}

static bool ValidBookingMenuChoice(string userInput)
{
    if (userInput == "1" || userInput == "2")
    {
        return true;
    }
    else return false;
}

static void BookingRoute(string userInput, BookingUtility bookingUtility){

            if(userInput == "1"){
                bookingUtility.ShowAvailableSessions();
                Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
            }
            else if(userInput == "2"){
                bookingUtility.BookSession();
                Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
            }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.");
            
        }

        // Console.WriteLine();
    }


// report methods

static void ReportFunctions(ref string userInput,BookingUtility bookingUtility, ListUtility listUtility, ReportUtility reportUtility){
    reportUtility.GetAllTransactionsFromFile();
    GetRevenueMenuChoice(ref userInput);
    ValidRevenueMenuChoice(userInput);
    RevenueRoute(userInput,bookingUtility, reportUtility);
}



static void DisplayRevenueMenu()
{
    Console.Clear();
    Console.WriteLine("Report Functions");
    Console.WriteLine("1: Individual Customer Sessions");
    Console.WriteLine("2: Historical Customer Sessions");
    System.Console.WriteLine("3: Historical Revenue Report");
    System.Console.WriteLine("4: Average revenue by month");
    System.Console.WriteLine("5: Month with highest revenue");
    System.Console.WriteLine("6: Month with lowest revenue");
    System.Console.WriteLine("7. Trainer with most sessions");
    System.Console.WriteLine("8. Trainer with most expensive session");
}


static string GetRevenueMenuChoice(ref string userInput){
            DisplayRevenueMenu();
            userInput = Console.ReadLine();

            while (!ValidRevenueMenuChoice(userInput))
            {
                Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();

                DisplayRevenueMenu();
                userInput = Console.ReadLine();
            }

            return userInput;
        }

static bool ValidRevenueMenuChoice(string userInput)
{
    if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5" || userInput == "6" || userInput == "7" || userInput == "8")
    {
        return true;
    }
    else return false;
}

static void RevenueRoute(string userInput, BookingUtility bookingUtility, ReportUtility reportUtility){

            if(userInput == "1"){
                reportUtility.SessionsByEmail();
                Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
            }
            else if(userInput == "2"){
                reportUtility.SessionsByEmail();
                Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
            }
            else if(userInput == "3"){
                reportUtility.RevenueByMonthAndYear();
                Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
            }
            else if(userInput == "4"){
                reportUtility.AverageRevenuePerMonth();
                Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
            }
            else if(userInput == "5"){
                reportUtility.MonthWithHighestRevenue();
                Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
            }
            else if(userInput == "6"){
                reportUtility.MonthWithLowestRevenue();
                Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
            }
            else if(userInput == "7"){
                reportUtility.TrainerWithMostSessions();
                Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
            }
            else if(userInput == "8"){
                reportUtility.TrainerWithMostExpensiveSession();
                Console.WriteLine("Press any key to continue....");
        Console.ReadKey();
            }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.");
            
        }

        // Console.WriteLine();
    }