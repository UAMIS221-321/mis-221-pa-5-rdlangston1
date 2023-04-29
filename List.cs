namespace TLAC{
    public class List{

        private int listID;
        
        private string trainerName;

        private string sessionDate;

        private string sessionTime;

        private double sessionCost;

        private string sessionStatus;

        static private int count;

        public List(int listID, string trainerName, string sessionDate, string sessionTime, double sessionCost, string sessionStatus) {
            this.listID = listID;
            this.trainerName = trainerName;
            this.sessionDate = sessionDate;
            this.sessionTime = sessionTime;
            this.sessionCost = sessionCost;
            this.sessionStatus = sessionStatus;
        }

        public List()
        {
        }

        public void SetListID(int listID){
            this.listID = listID;
        }

        public int GetListID(){
            return listID;
        }

        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }

        public string GetTrainerName(){
            return trainerName;
        }

        public void SetDate(string sessionDate){
            this.sessionDate = sessionDate;
        }

        public string GetDate(){
            return sessionDate;
        }

        public void SetTime(string sessionTime){
            this.sessionTime = sessionTime;
        }

        public string GetTime(){
            return sessionTime;
        }

        public void SetCost(double sessionCost){
            this.sessionCost = sessionCost;
        }

        public double GetCost(){
            return sessionCost;
        }

        public void SetSessionStatus(string sessionStatus){
            this.sessionStatus = sessionStatus;
        }

        public string GetSessionStatus(){
            return sessionStatus;
        }

        static public void SetCount(int count){
            List.count = count;
        }

        static public void IncCount(){
            count++;
        }

        static public int GetCount(){
            return count;
        }

        public string ToFile()
        {
            return $"{listID}#{trainerName}#{sessionDate}#{sessionTime}#{sessionCost}#{sessionStatus}";
        }

        public override string ToString()
        {
            return $"{listID} {trainerName} {sessionDate} {sessionTime} {sessionCost} {sessionStatus}";
        }


        





}
}