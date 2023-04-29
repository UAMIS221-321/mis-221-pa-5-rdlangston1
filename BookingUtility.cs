namespace TLAC{


    public class BookingUtility{

        private Booking[] bookings;

        private List[] listing;

        ListUtility utility = new ListUtility(new List[100]); 

        List session = new List();


        public BookingUtility(Booking[] bookings, List[] listing){
            this.bookings = bookings;
            this.listing = listing;
            Booking.SetCount(0);

            this.bookings = new Booking[50];
            this.listing = new List[50];
        }






        public void GetAllBookingsFromFile(){
            //open
            StreamReader inFile = new StreamReader("transactions.txt");


            // process
            Booking.SetCount(0);
            string line = inFile.ReadLine();
            while(line!= null){
                string[] temp = line.Split('#');
                // wordCount+=temp.Length();
                bookings[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], temp[6]);
                Booking.IncCount();
                line = inFile.ReadLine();
            }

            //close
            inFile.Close();
        }




    public void ShowAvailableSessions()
{
    StreamReader inFile = new StreamReader("listings.txt");

    Console.WriteLine("Available Training Sessions:");

    string line = inFile.ReadLine();
    while (line != null)
    {
        string[] temp = line.Split('#');
        int listID = int.Parse(temp[0]);
        string trainerName = temp[1];
        string date = temp[2];
        string time = temp[3];
        double cost = double.Parse(temp[4]);
        string status = temp[5];

        if (status.ToUpper() == "OPEN")
        {
            Console.WriteLine($"Session ID: {listID}");
            Console.WriteLine($"Trainer Name: {trainerName}");
            Console.WriteLine($"Date: {date}");
            Console.WriteLine($"Time: {time}");
            Console.WriteLine($"Cost: {cost}");
            Console.WriteLine();
        }

        line = inFile.ReadLine();
    

    
}
inFile.Close();
}




public int Find(int sessionId)
{
    for (int i = 0; i < List.GetCount(); i++)
    {
        if (listing[i] != null && listing[i].GetListID() == sessionId)
        {
            return i;
        }
    }
    return -1;
}





        private void SaveBookingsToFile()
        {
            StreamWriter outFile = new StreamWriter("listings.txt");

            for (int i = 0; i < List.GetCount(); i++)
            {
                listing[i].SetSessionStatus("Booked");
            }

            outFile.Close();
        }
    


public void UpdateSessionStatus() {
    int sessionId = int.Parse(Console.ReadLine());
    int foundIndex = Find(sessionId);
    if (foundIndex != -1) {
        listing[foundIndex].SetSessionStatus("booked");

        SaveBookingsToFile();
    }
    else {
        System.Console.WriteLine("Listing not found");
    }
}

 
public void BookSession()
{
    utility.GetAllListingsFromFile();
    Console.WriteLine("Session Booking");

    // Show available sessions
    ShowAvailableSessions();
    // Prompt user to enter the session ID to book
    Console.WriteLine("Enter the ID of the session you want to book:");
    // int sessionId = int.Parse(Console.ReadLine());

    // // Find the session in the available sessions
    // int foundIndex = Find(sessionId);
    // if (foundIndex != -1)
    // {
    //     // Check if the session is already booked
    //     if (listing[foundIndex].GetSessionStatus().ToUpper() == "BOOKED")
    //     {
    //         Console.WriteLine("This session is already booked.");
    //     }
    //     else
    //     {
    //         // Update the session status to "Booked"
    //         listing[foundIndex].SetSessionStatus("Booked");

            // Save the updated booking information to the file


    UpdateSessionStatus();
            // SaveBookingsToFile();

            Console.WriteLine("Session booked successfully!");
        }
    }



    
}
