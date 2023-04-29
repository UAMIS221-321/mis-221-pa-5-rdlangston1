namespace TLAC{

    public class Report{

        private int sessionID;

        private string custName;

        private string custEmail;

        // private string sessionDate;

        private int sessionDay;

        private int sessionMonth;

        // private int sessionDate;

        private int sessionYear;

        private int trainerID;

        private string trainerName;

        private string status;

        private double cost;

        static private int count;

        static public void SetCount(int count){
            Report.count = count;
        }

        static public void IncCount(){
            count++;
        }

        static public int GetCount(){
            return count;
        }

        public void SetSessionID(int sessionID){
            this.sessionID = sessionID;
        }

        public int GetSessionID(){
            return sessionID;
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

        // public void SetSessionDate(string sessionDate){
        //     this.sessionDate = sessionDate;
        // }

        // public string GetSessionDate(){
        //     return sessionDate;
        // }

        public void SetSessionMonth(int sessionMonth){
            this.sessionMonth = sessionMonth;
        }

        public int GetSessionMonth(){
            return sessionMonth;
        }

        public void SetSessionDay(int sessionDay){
            this.sessionDay = sessionDay;
        }

        public int GetSessionDay(){
            return sessionDay;
        }



        public void SetSessionYear(int sessionYear){
            this.sessionYear = sessionYear;
        }

        public int GetSessionYear(){
            return sessionYear;
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

        public void SetCost(double cost){
            this.cost = cost;
        }

        public double GetCost(){
            return cost;
        }

    




        public Report(){

        }

        public Report(int sessionID, string custName, string custEmail, int sessionMonth, int sessionDay, int sessionYear, int trainerID, string trainerName, string status, double cost){
            this.sessionID = sessionID;
            this.custName = custName;
            this.custEmail = custEmail;
            this.sessionMonth = sessionMonth;
            this.sessionDay = sessionDay;
            // this.sessionDate = sessionDate;
            this.sessionYear = sessionYear;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.status = status;
            this.cost = cost;
        }

        public override string ToString()
    {
        return $"{sessionID}#{custName}#{custEmail}#{sessionMonth}#{sessionDay}#{sessionYear}#{trainerID}#{trainerName}#{status}{cost}";
    }



    


    }
}