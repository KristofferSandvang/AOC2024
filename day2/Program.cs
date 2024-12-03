List<List<int>> reports = new List<List<int>>();

foreach (var line in File.ReadLines("input.txt"))
{
    string[] correctLine = line.Split(" ");
    List<int> report = new List<int>();
    foreach (string level in correctLine) 
    {
        report.Add(Int32.Parse(level));
    }
    reports.Add(report);

}
int SafeReports = 0;
int SafeReportsPt2 = 0;
foreach (var report in reports) {
    if (isReportSafe(report)) {
        SafeReports++;
    }
    if (ProblemDampener(report)) {
        SafeReportsPt2++;
    }
}

System.Console.WriteLine(String.Format("number of safe reports = {0}", SafeReports));
System.Console.WriteLine(String.Format("number of safe reports using problem dampner = {0}", SafeReportsPt2));


bool isReportSafe(List<int> report) 
{
    Ordering order = getOrdering(report);
    if (order == Ordering.Both) 
    {
        return false;
    }

    for (int i = 1; i < report.Count; i++)
    {

        if (Math.Abs(report[i] - report[i - 1]) >= 1 && Math.Abs(report[i] - report[i - 1]) <= 3)
        {
            continue;
        }
        return false;
    }
    return true;
}

bool ProblemDampener(List<int> report) {
    if (isReportSafe(report)) 
    {
        return true;
    }
    for (int i = 0; i < report.Count; i++)
    {
        List<int> tempReport = new List<int>(report);
        tempReport.RemoveAt(i);

        if (isReportSafe(tempReport))
        {
            return true;
        }
    }
    return false;
}

Ordering getOrdering(List<int> report) 
{
    int IncreasingPairs = 0;
    int DecreasingPairs = 0;

    for (int i = 1; i < report.Count; i++)
    {
        if (report[i] < report[i - 1])
        {
         DecreasingPairs++;
         continue;
        }
        IncreasingPairs++;
    }
    if (IncreasingPairs != 0 && DecreasingPairs == 0) 
    {
        return Ordering.Increasing;
    }
    else if (DecreasingPairs != 0 && IncreasingPairs == 0) 
    {
        return Ordering.Decreasing;
    } else
    {
        return Ordering.Both;
    }
}

public enum Ordering
{
    Increasing,
    Decreasing,
    Both,
}