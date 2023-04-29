namespace TLAC{
    public class TrainerUtility{

        private Trainer[] trainers;


        public TrainerUtility(Trainer[] trainers){
            this.trainers = trainers;
        }

        public void GetAllTrainersFromFile(){
            //open
            StreamReader inFile = new StreamReader("trainers.txt");


            // process
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line!= null){
                string[] temp = line.Split('#');
                // wordCount+=temp.Length();
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                Trainer.IncCount();
                line = inFile.ReadLine();
            }

            //close
            inFile.Close();
        }

    //     public void AddTrainer(){
    //     System.Console.WriteLine("Please enter the trainer ID");
    //     Trainer myTrainer = new Trainer();
    //     myTrainer.SetTrainerID(int.Parse(Console.ReadLine()));
    //     System.Console.WriteLine("Enter the Trainer's name");
    //     myTrainer.SetTrainerName(Console.ReadLine());
    //     System.Console.WriteLine("Enter the trainer's mailing adress");
    //     myTrainer.SetTrainerMailAdress(Console.ReadLine());
    //     System.Console.WriteLine("Enter the trainer's Email adress");
    //     myTrainer.SetTrainerEMailAdress(Console.ReadLine());
        

    //     trainers[Trainer.GetCount()] = myTrainer;
    //     Trainer.IncCount();

    //     Save();

    // }

    public void AddTrainer()
{
    System.Console.WriteLine("Please enter the trainer ID");
    int trainerID = int.Parse(Console.ReadLine());

    System.Console.WriteLine("Enter the Trainer's name");
    string trainerName = Console.ReadLine();

    System.Console.WriteLine("Enter the trainer's mailing address");
    string trainerMailAddress = Console.ReadLine();

    System.Console.WriteLine("Enter the trainer's Email address");
    string trainerEmailAddress = Console.ReadLine();

    Trainer newTrainer = new Trainer(trainerID, trainerName, trainerMailAddress, trainerEmailAddress);

    // Add the new trainer to the array
    trainers[Trainer.GetCount()] = newTrainer;
    Trainer.IncCount();

    // Save the updated data to the file
    Save();
}


//     public void UpdateTrainer() {
//     System.Console.WriteLine("Enter the name of the trainer you would like to edit");
//     string searchName = Console.ReadLine();
//     int foundIndex = Find(searchName);
//     if (foundIndex != -1) {
//         System.Console.WriteLine("Please enter the trainer ID");
//         trainers[foundIndex].SetTrainerID(int.Parse(Console.ReadLine()));
//         System.Console.WriteLine("Please enter the trainer name");
//         trainers[foundIndex].SetTrainerName(Console.ReadLine());
//         System.Console.WriteLine("Please enter the trainer's mailing address");
//         trainers[foundIndex].SetTrainerMailAdress(Console.ReadLine());
//         System.Console.WriteLine("Please enter the trainer's Email address");
//         trainers[foundIndex].SetTrainerEMailAdress(Console.ReadLine());

//         Save();
//     }
//     else {
//         System.Console.WriteLine("Trainer not found");
//     }
// }


public void UpdateTrainerName() {
    System.Console.WriteLine("Enter the name of the trainer you would like to edit");
    string searchName = Console.ReadLine();
    int foundIndex = Find(searchName);
    if (foundIndex != -1) {
        System.Console.WriteLine("Please enter the new trainer name");
        trainers[foundIndex].SetTrainerName(Console.ReadLine());

        Save();
    }
    else {
        System.Console.WriteLine("Trainer not found");
    }
}

public void UpdateTrainerID() {
    System.Console.WriteLine("Enter the name of the trainer you would like to edit");
    string searchName = Console.ReadLine();
    int foundIndex = Find(searchName);
    if (foundIndex != -1) {
        System.Console.WriteLine("Please enter the new trainer ID");
        trainers[foundIndex].SetTrainerID(int.Parse(Console.ReadLine()));

        Save();
    }
    else {
        System.Console.WriteLine("Trainer not found");
    }
}

public void UpdateTrainerAddress() {
    System.Console.WriteLine("Enter the name of the trainer you would like to edit");
    string searchName = Console.ReadLine();
    int foundIndex = Find(searchName);
    if (foundIndex != -1) {
        System.Console.WriteLine("Please enter the new trainer mailing Address");
        trainers[foundIndex].SetTrainerMailAdress(Console.ReadLine());

        Save();
    }
    else {
        System.Console.WriteLine("Trainer not found");
    }
}

public void UpdateTrainerEmail() {
    System.Console.WriteLine("Enter the name of the trainer you would like to edit");
    string searchName = Console.ReadLine();
    int foundIndex = Find(searchName);
    if (foundIndex != -1) {
        System.Console.WriteLine("Please enter the new trainer Email Address");
        trainers[foundIndex].SetTrainerEMailAdress(Console.ReadLine());

        Save();
    }
    else {
        System.Console.WriteLine("Trainer not found");
    }
}











    public void DeleteTrainer(){
        System.Console.WriteLine("Enter the ID of the trainer you would like to delete");
         StreamReader inFile = new StreamReader("trainers.txt");

        int searchID = int.Parse(Console.ReadLine());
        
            // process
            string line = inFile.ReadLine();
           while(line != null){
                string[] temp = line.Split('#');
                if(line!= searchID.ToString()){
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                Trainer.IncCount();
                line = inFile.ReadLine();
            }
            else line = inFile.ReadLine();
           }

            Save();
            //close
            inFile.Close();
        }

 public void PrintAllTrainers(){
            for(int i = 0; i < Trainer.GetCount(); i++){
                System.Console.WriteLine(trainers[i].ToString());
            }
        }

    public void Save(){
        StreamWriter outFile = new StreamWriter("trainers.txt");

        for(int i = 0; i < Trainer.GetCount(); i++){
            outFile.WriteLine(trainers[i].ToFile());
        }


        outFile.Close();
    }

    public int Find(string searchVal){
        for(int i = 0; i < Trainer.GetCount(); i++){
            if(trainers[i].GetTrainerName().ToUpper() == searchVal.ToUpper()){
                return i;
            }
        }
        return -1;
    }

    public void Sort(){
        for(int i = 0; i < Trainer.GetCount() - 1; i++){
            int min = i;
            for(int j = i +1; j <Trainer.GetCount(); j++){
                if(trainers[j].GetTrainerName().CompareTo(trainers[min].GetTrainerName()) < 0 ||(trainers[j].GetTrainerName() == trainers[min].GetTrainerName() && trainers[j].GetTrainerID() < trainers[min].GetTrainerID()) ){
                    min = j;
                }
            }
            if(min != i){
                Swap(min, i);
            }
        }
    }

    private void Swap(int x, int y){
        Trainer temp = trainers[x];
        trainers[x] = trainers[y];
        trainers[y] = temp;
    }


    }
}