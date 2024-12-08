using System.Text.RegularExpressions;
int sum = 0;
bool allowed = true;
foreach (var line in File.ReadLines("input.txt"))
{
    string pattern = @"mul\(\d{1,3},\d{1,3}\)";
    string allow =  @"do\(\)";
    string deny =  @"don't\(\)";
    string combinedPattern = $"{pattern}|{allow}|{deny}";
    MatchCollection matches = Regex.Matches(line, combinedPattern);
    List<List<int>> matchNumbers = new List<List<int>>();
    foreach (Match match in matches)
    {
        if (match.Value == "do()") 
        {
            allowed = true;
            continue;
        }
        if (match.Value == "don't()") 
        {
            allowed = false;
            continue;
        }
        if (allowed) {
        string[] numbers = match.Value.Substring(4).Split(new[] { ',', ')' });
        matchNumbers.Add(new List<int> {Int32.Parse(numbers[0]), Int32.Parse(numbers[1])});
        }
    }

    List<int> products = getProducts(matchNumbers);
    sum += products.Sum();
}
System.Console.WriteLine(sum);

List<int> getProducts(List<List<int>> matchNumbers) {
    List<int> products = new List<int>();
    foreach (var match in matchNumbers)
    {
        products.Add(match[0] * match[1]);
    }

    return products;
}