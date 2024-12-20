List<int> locationsA = [];
List<int> locationsB = [];

foreach (var line in File.ReadLines("input.txt"))
{
    string[] correctLine = line.Split("   ");
    locationsA.Add(Int32.Parse(correctLine[0]));
    locationsB.Add(Int32.Parse(correctLine[1]));
}

// Part 1
// locationsA.Sort();
// locationsB.Sort();

// Stack<int> locA = new Stack<int>(locationsA);
// Stack<int> locB = new Stack<int>(locationsB);

// List<int> distance = [];

// while (locA.Count > 0 && locB.Count > 0)
// {
//     int minA = locA.Pop();
//     int minB = locB.Pop();
//     distance.Add(Math.Abs(minA - minB));
// }

// System.Console.WriteLine(distance.Sum());

// Part 2:
List<int> similarty = [];

foreach (int value in locationsA)
{
    int similartyScore = locationsB.Where(x => x == value).ToList().Count;
    similarty.Add(value * similartyScore);
}


System.Console.WriteLine(similarty.Sum());