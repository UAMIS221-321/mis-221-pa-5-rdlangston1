namespace TLAC{
    public class ListUtility{

        private List[] listing;


        public ListUtility(List[] listing){
            this.listing = listing;
        }

        public void GetAllListingsFromFile(){
            //open
            StreamReader inFile = new StreamReader("listings.txt");


            // process
            List.SetCount(0);
            string line = inFile.ReadLine();
            while(line!= null){
                string[] temp = line.Split('#');
                // wordCount+=temp.Length();
                listing[List.GetCount()] = new List(int.Parse(temp[0]), temp[1], temp[2], temp[3], double.Parse(temp[4]), temp[5]);
                List.IncCount();
                line = inFile.ReadLine();
            }

            //close
            inFile.Close();
        }

        public void AddList(){
        List myList = new List();
        System.Console.WriteLine("Please enter the listing ID");
        myList.SetListID(int.Parse(Console.ReadLine()));
        System.Console.WriteLine("Please enter the trainer's name");
        myList.SetTrainerName(Console.ReadLine());
        System.Console.WriteLine("Please enter the session date");
        myList.SetDate(Console.ReadLine());
        System.Console.WriteLine("Please enter the session time");
        myList.SetTime(Console.ReadLine());
        System.Console.WriteLine("Please enter the session cost");
        myList.SetCost(double.Parse(Console.ReadLine()));  
        myList.SetSessionStatus("open");

        listing[List.GetCount()] = myList;
        List.IncCount();

        Save();

    }

//     public void UpdateList() {
//     System.Console.WriteLine("Enter the name of the trainer you would like to edit");
//     string searchName = Console.ReadLine();
//     int foundIndex = Find(searchName);
//     if (foundIndex != -1) {
//         System.Console.WriteLine("Please enter the trainer ID");
//         listing[foundIndex].SetListID(int.Parse(Console.ReadLine()));
//         System.Console.WriteLine("Please enter the trainer name");
//         listing[foundIndex].SetListName(Console.ReadLine());
//         System.Console.WriteLine("Please enter the trainer's mailing address");
//         listing[foundIndex].SetListMailAdress(Console.ReadLine());
//         System.Console.WriteLine("Please enter the trainer's Email address");
//         listing[foundIndex].SetListEMailAdress(Console.ReadLine());

//         Save();
//     }
//     else {
//         System.Console.WriteLine("List not found");
//     }
// }


public void UpdateListID() {
    System.Console.WriteLine("Enter the ID of the listing you would like to edit");
    int searchList = int.Parse(Console.ReadLine());
    int foundIndex = Find(searchList);
    if (foundIndex != -1) {
        System.Console.WriteLine("Please enter the new ID of the listing");
        listing[foundIndex].SetListID(int.Parse(Console.ReadLine()));

        Save();
    }
    else {
        System.Console.WriteLine("Listing not found");
    }
}

public void UpdateListName() {
    System.Console.WriteLine("Enter the ID of the listing you would like to edit");
    int searchList = int.Parse(Console.ReadLine());
    int foundIndex = Find(searchList);
    if (foundIndex != -1) {
        System.Console.WriteLine("Please enter the trainer name name");
        listing[foundIndex].SetTrainerName(Console.ReadLine());

        Save();
    }
    else {
        System.Console.WriteLine("List not found");
    }
}

public void UpdateListDate() {
    System.Console.WriteLine("Enter the ID of the listing you would like to edit");
    int searchList = int.Parse(Console.ReadLine());
    int foundIndex = Find(searchList);
    if (foundIndex != -1) {
        System.Console.WriteLine("Please enter the new date of the session");
        listing[foundIndex].SetDate(Console.ReadLine());

        Save();
    }
    else {
        System.Console.WriteLine("Listing not found");
    }
}

public void UpdateListTime() {
    System.Console.WriteLine("Enter the ID of the listing you would like to edit");
    int searchList = int.Parse(Console.ReadLine());
    int foundIndex = Find(searchList);
    if (foundIndex != -1) {
        System.Console.WriteLine("Please enter the new time of the session");
        listing[foundIndex].SetTime(Console.ReadLine());

        Save();
    }
    else {
        System.Console.WriteLine("List not found");
    }
}

public void UpdateListCost() {
    System.Console.WriteLine("Enter the ID of the listing you would like to edit");
    int searchList = int.Parse(Console.ReadLine());
    int foundIndex = Find(searchList);
    if (foundIndex != -1) {
        System.Console.WriteLine("Please enter the new cost of the session");
        listing[foundIndex].SetCost(double.Parse(Console.ReadLine()));

        Save();
    }
    else {
        System.Console.WriteLine("List not found");
    }
}











    public void DeleteList(){
        System.Console.WriteLine("Enter the ID of the trainer you would like to delete");
         StreamReader inFile = new StreamReader("listings.txt");

        int searchID = int.Parse(Console.ReadLine());
        
            // process
            string line = inFile.ReadLine();
           while(line != null){
                string[] temp = line.Split('#');
                if(line!= searchID.ToString()){
                listing[List.GetCount()] = new List(int.Parse(temp[0]), temp[1], temp[2], temp[3], double.Parse(temp[4]), temp[6]);
                List.IncCount();
                line = inFile.ReadLine();
            }
            else line = inFile.ReadLine();
           }

            Save();
            //close
            inFile.Close();
        }

 public void PrintAllLists(){
            for(int i = 0; i < List.GetCount(); i++){
                System.Console.WriteLine(listing[i].ToString());
            }
        }

    public void Save(){
        StreamWriter outFile = new StreamWriter("listings.txt");

        for(int i = 0; i < List.GetCount(); i++){
            outFile.WriteLine(listing[i].ToFile());
        }


        outFile.Close();
    }

    public int Find(int searchList){
        for(int i = 0; i < List.GetCount(); i++){
            if(listing[i].GetListID() == searchList){
                return i;
            }
        }
        return -1;
    }



    public void ShowAvailableSessions()
{
    GetAllListingsFromFile();

    for (int i = 0; i < List.GetCount(); i++)
    {
        if (listing[i].GetSessionStatus().ToUpper() == "OPEN")
        {
            Console.WriteLine($"Listing ID: {listing[i].GetListID()}");
            Console.WriteLine($"Trainer Name: {listing[i].GetTrainerName()}");
            Console.WriteLine($"Session Date: {listing[i].GetDate()}");
            Console.WriteLine($"Session Time: {listing[i].GetTime()}");
            Console.WriteLine($"Session Cost: {listing[i].GetCost()}");
            Console.WriteLine();
        }
    }
}

                

    }
}