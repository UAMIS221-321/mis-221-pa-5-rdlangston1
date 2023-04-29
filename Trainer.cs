namespace TLAC{

    public class Trainer{

        private int trainerID;
        
        private string trainerName;

        private string trainerMailAdress;

        private string trainerEmailAdress;

        static private int count;

         public Trainer(int trainerID, string trainerName, string trainerMailAdress, string trainerEmailAdress) {
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.trainerMailAdress = trainerMailAdress;
            this.trainerEmailAdress = trainerEmailAdress;
        }

        public Trainer()
        {
        }

        public void SetTrainerID(int trainerID){
            this.trainerID = trainerID;
        }

        public int GetTrainerID(){
            return trainerID;
        }

        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }

        public string GetTrainerName(){
            return trainerName;
        }

        public void SetTrainerMailAdress(string trainerMailAdress){
            this.trainerMailAdress = trainerMailAdress;
        }

        public string GetTrainerMailAdress(){
            return trainerMailAdress;
        }

        public void SetTrainerEMailAdress(string trainerEmailAddress){
            this.trainerEmailAdress = trainerEmailAddress;
        }

        public string GetTrainerEMailAdress(){
            return trainerEmailAdress;
        }

        static public void SetCount(int count){
            Trainer.count = count;
        }

        static public void IncCount(){
            count++;
        }

        static public int GetCount(){
            return count;
        }

        public string ToFile()
        {
            return $"{trainerID}#{trainerName}#{trainerMailAdress}#{trainerEmailAdress}";
        }

        public override string ToString()
        {
            return $"{trainerID} {trainerName} {trainerMailAdress} {trainerEmailAdress}";
        }



        }


    }

