namespace TLAC
{

    public class ReportUtility
    {
        private Booking[] bookings;

        private Report[] reports;

        public ReportUtility(Booking[] bookings){
            this.bookings = bookings;
            reports = new Report[50];
        }

        public void PrintAllBookings(){
            for(int i = 0; i < bookings.Length; i++){
                System.Console.WriteLine(bookings[i].ToString());
            }
        }



public void GetAllTransactionsFromFile()
{
    StreamReader inFile = new StreamReader("transactions.txt");

    Report.SetCount(0);  // Reset the count of bookings

     string line = inFile.ReadLine();
    while(line!= null){
        string[] temp = line.Split('#');
        reports[Report.GetCount()] = new Report(int.Parse(temp[0]), temp[1], temp[2], int.Parse(temp[3]), int.Parse(temp[4]),int.Parse(temp[5]), int.Parse(temp[6]), temp[7], temp[8], double.Parse(temp[9]));
        Report.IncCount();
        line = inFile.ReadLine();
    }

    inFile.Close();
}


public void PrintAllTransactions(){
            for(int i = 0; i < Report.GetCount(); i++){
                System.Console.WriteLine(reports[i].ToString());
            }
        }


       public void SessionsByEmail()
{
    Console.WriteLine("Enter email:");
    string email = Console.ReadLine();
    
    bool foundSessions = false;

    for (int i = 0; i < Report.GetCount(); i++)
    {
        if (reports[i].GetCustEmail() == email)
        {
            Console.WriteLine(reports[i].ToString());
            foundSessions = true;
        }
    }

    if (!foundSessions)
    {
        Console.WriteLine("No sessions found email.");
    }
}


public void RevenueByMonthAndYear()
{
    int currMonth = reports[0].GetSessionMonth();
    int currYear = reports[0].GetSessionYear();
    double revenue = reports[0].GetCost();

    for (int i = 1; i < Report.GetCount(); i++)
    {
        Report report = reports[i];

        if (report.GetSessionMonth() == currMonth && report.GetSessionYear() == currYear)
        {
            revenue += report.GetCost();
        }
        else
        {
            ProcessBreak(currMonth, currYear, revenue);
            currMonth = report.GetSessionMonth();
            currYear = report.GetSessionYear();
            revenue = report.GetCost();
        }
    }

    ProcessBreak(currMonth, currYear, revenue);
}

public void ProcessBreak(int month, int year, double revenue)
{
    Console.WriteLine($"{month}/{year}\t{revenue}");
}





// public void PrintSessionsByCustomerAndDate()
// {
//     SortReportsByCustomerAndDate();

//     string currentCustomer = reports[0].GetCustName();
//     string currentDate = reports[0].GetSessionDate();
//     int currentYear = reports[0].GetSessionYear();
//     int sessionsCount = 1;

//     for (int i = 1; i < Report.GetCount(); i++)
//     {
//         string customer = reports[i].GetCustName();
//         string date = reports[i].GetSessionDate();
//         int year = reports[i].GetSessionYear();

//         if (customer == currentCustomer && year == currentYear && String.Compare(date, currentDate) == 0)
//         {
//             sessionsCount++;
//         }
//         else
//         {
//             ProcessBreak(currentCustomer, currentDate, currentYear, sessionsCount);
//             currentCustomer = customer;
//             currentDate = date;
//             currentYear = year;
//             sessionsCount = 1;
//         }
//     }

//     ProcessBreak(currentCustomer, currentDate, currentYear, sessionsCount);
// }

// private void SortReportsByCustomerAndDate()
// {
//     for (int i = 0; i < Report.GetCount() - 1; i++)
//     {
//         for (int j = i + 1; j < Report.GetCount(); j++)
//         {
//             if (
//                 (reports[j].GetCustName() == reports[i].GetCustName() && reports[j].GetSessionYear() < reports[i].GetSessionYear()) || (reports[j].GetCustName() == reports[i].GetCustName() && reports[j].GetSessionYear() == reports[i].GetSessionYear()))
//             {
//                 SwapReports(i, j);
//             }
//         }
//     }
// }

// private void SwapReports(int i, int j)
// {
//     Report temp = reports[i];
//     reports[i] = reports[j];
//     reports[j] = temp;
// }

// public void ProcessBreak(string customer, string date, int year, int sessionsCount)
// {
//     Console.WriteLine($"Customer: {customer}");
//     Console.WriteLine($"Date: {date}, {year}");
//     Console.WriteLine($"Total Sessions: {sessionsCount}");
//     Console.WriteLine();
// }




public void TrainerWithMostExpensiveSession()
{
    RevenueByMonthAndYear();

    Console.WriteLine("Sorting revenue from highest to lowest:");

    // Sort reports array in descending order based on revenue (cost)
    for (int i = 0; i < Report.GetCount() - 1; i++)
    {
        for (int j = i + 1; j < Report.GetCount(); j++)
        {
            if (reports[j].GetCost() > reports[i].GetCost())
            {
                SwapReports(i, j);
            }
        }
    }

    for (int i = 0; i < Report.GetCount(); i++)
    {
        Console.WriteLine($"session cost: ${reports[i].GetCost()}\tTrainer: {reports[i].GetTrainerName()}");
    }
    System.Console.WriteLine($"{reports[0].GetTrainerName()} has the most expensive session");  
}

public void SwapReports(int index1, int index2)
{
    Report temp = reports[index1];
    reports[index1] = reports[index2];
    reports[index2] = temp;
}



public void MonthWithHighestRevenue()
{
    int maxRevenueMonth = reports[0].GetSessionMonth();
    int maxRevenueYear = reports[0].GetSessionYear();
    double maxRevenue = 0;

    int currMonth = reports[0].GetSessionMonth();
    int currYear = reports[0].GetSessionYear();
    double revenue = reports[0].GetCost();

    for (int i = 1; i < Report.GetCount(); i++)
    {
        Report report = reports[i];

        if (report.GetSessionMonth() == currMonth && report.GetSessionYear() == currYear)
        {
            revenue += report.GetCost();
        }
        else
        {
            if (revenue > maxRevenue)
            {
                maxRevenue = revenue;
                maxRevenueMonth = currMonth;
                maxRevenueYear = currYear;
            }

            currMonth = report.GetSessionMonth();
            currYear = report.GetSessionYear();
            revenue = report.GetCost();
        }
    }

    // Check the last month's revenue
    if (revenue > maxRevenue)
    {
        maxRevenue = revenue;
        maxRevenueMonth = currMonth;
        maxRevenueYear = currYear;
    }

    Console.WriteLine($"Month with highest revenue: {maxRevenueMonth}/{maxRevenueYear}");
}



public void MonthWithLowestRevenue()
{
    int minRevenueMonth = reports[0].GetSessionMonth();
    int minRevenueYear = reports[0].GetSessionYear();
    double minRevenue = reports[0].GetCost();

    int currMonth = reports[0].GetSessionMonth();
    int currYear = reports[0].GetSessionYear();
    double revenue = reports[0].GetCost();

    for (int i = 1; i < Report.GetCount(); i++)
    {
        Report report = reports[i];

        if (report.GetSessionMonth() == currMonth && report.GetSessionYear() == currYear)
        {
            revenue += report.GetCost();
        }
        else
        {
            if (revenue < minRevenue)
            {
                minRevenue = revenue;
                minRevenueMonth = currMonth;
                minRevenueYear = currYear;
            }

            currMonth = report.GetSessionMonth();
            currYear = report.GetSessionYear();
            revenue = report.GetCost();
        }
    }

    // Check the last month's revenue
    if (revenue < minRevenue)
    {
        minRevenue = revenue;
        minRevenueMonth = currMonth;
        minRevenueYear = currYear;
    }

    Console.WriteLine($"Month with lowest revenue: {minRevenueMonth}/{minRevenueYear}");
}


public void AverageRevenuePerMonth()
{
    int currMonth = reports[0].GetSessionMonth();
    int currYear = reports[0].GetSessionYear();
    double revenue = reports[0].GetCost();
    int count = 1;

    for (int i = 1; i < Report.GetCount(); i++)
    {
        Report report = reports[i];

        if (report.GetSessionMonth() == currMonth && report.GetSessionYear() == currYear)
        {
            revenue += report.GetCost();
            count++;
        }
        else
        {
            double averageRevenue = revenue / count;
            ProcessBreak(currMonth, currYear, averageRevenue);

            currMonth = report.GetSessionMonth();
            currYear = report.GetSessionYear();
            revenue = report.GetCost();
            count = 1;
        }
    }

    double averageRevenueLastMonth = revenue / count;
    ProcessBreak(currMonth, currYear, averageRevenueLastMonth);
}

public void TrainerWithMostSessions()
{
    string currTrainer = reports[0].GetTrainerName();
    int sessionCount = 1;
    string trainerWithMostSessions = currTrainer;
    int maxSessionCount = sessionCount;

    for (int i = 1; i < Report.GetCount(); i++)
    {
        Report report = reports[i];

        if (report.GetTrainerName() == currTrainer)
        {
            sessionCount++;
        }
        else
        {
            if (sessionCount > maxSessionCount)
            {
                trainerWithMostSessions = currTrainer;
                maxSessionCount = sessionCount;
            }
            currTrainer = report.GetTrainerName();
            sessionCount = 1;
        }
    }

    if (sessionCount > maxSessionCount)
    {
        trainerWithMostSessions = currTrainer;
        maxSessionCount = sessionCount;
    }

    ProcessBreak(trainerWithMostSessions, maxSessionCount);
}

public void ProcessBreak(string trainerName, int sessionCount)
{
    Console.WriteLine($"Trainer with most sessions: {trainerName}\t she has scheduled {sessionCount} sessions");
}




}
}

