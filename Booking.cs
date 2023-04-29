namespace TLAC{

    public class Booking{

        private int listID;

        private string custName;

        private string custEmail;

        private string sessionDate;

        private int trainerID;

        private string trainerName;

        private string status;

        static private int count;

        static public void SetCount(int count){
            Booking.count = count;
        }

        static public void IncCount(){
            count++;
        }

        static public int GetCount(){
            return count;
        }

        public void SetListID(int listID){
            this.listID = listID;
        }

        public int GetListId(){
            return listID;
        }

        // public int SetSessionID(){
        //     return listID;
        // }

        public void SetCustName(string custName){
            this.custName = custName; 
        }

        public string GetCustName(){
            return custName;
        }

        public void SetCustEmail(string custEmail){
            this.custEmail= custEmail;
        }

        public string GetCustEmail(){
            return custEmail;
        }

        public void SetSessionDate(string sessionDate){
            this.sessionDate = sessionDate;
        }

        public string GetSessionDate(){
            return sessionDate;
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

        public void SetStatus(string status){
            this.status = status;
        }

        public string GetStatus(){
            return status;
        }




        public Booking(){

        }

        public Booking(int listID, string custName, string custEmail, string sessionDate, int trainerID, string trainerName, string status){
            this.listID = listID;
            this.custName = custName;
            this.custEmail = custEmail;
            this.sessionDate = sessionDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.status = status;

        }

        public string ToFile()
    {
        return $"{listID}#{custName}#{custEmail}#{sessionDate}#{trainerID}#{trainerName}#{status}";
    }


        


    }
}