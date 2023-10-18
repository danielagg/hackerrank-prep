// See https://aka.ms/new-console-template for more information

plusMinus(new[] { -4, 3, -9, 0, 4, 1 }.ToList());
miniMaxSum(new[] { 1, 3, 5, 7, 9 }.ToList());
timeConversion("12:06:00PM");

findMedian(new[] { 1, 5, 2, 4, 3 }.ToList());

lonelyinteger(new[] { 1, 2, 3, 4, 2, 3, 1 }.ToList());

diagonalDifference(new[]
{
    new[] { 1, 2, 3 }.ToList(),
    new[] { 4, 5, 6 }.ToList(),
    new[] { 9, 8, 9 }.ToList(),
}.ToList());

countingSort(new[] { 1, 1, 3, 2, 1 }.ToList());

Console.WriteLine("Bye!");


void plusMinus(List<int> arr)
{
    var zeros = arr.Count(x => x == 0) / (float)arr.Count;
    var positives = arr.Count(x => x > 0) / (float)arr.Count;
    var negatives = arr.Count(x => x < 0) / (float)arr.Count;

    Console.WriteLine(positives.ToString("0.000000"));
    Console.WriteLine(negatives.ToString("0.000000"));
    Console.WriteLine(zeros.ToString("0.000000"));
}

void miniMaxSum(List<int> arr)
{
    var sorted = arr.OrderBy(x => x).ToList();
    
    var min = sorted.Take(4).Sum(x => (long)x);
    var max = sorted.Skip(1).Take(4).Sum(x => (long)x);
    
    Console.WriteLine($"{min} {max}");
}

string timeConversion(string s)
{
    var hour = s.Substring(0, 2);
    var minute = s.Substring(3, 2);
    var sec = s.Substring(6, 2);

    var amOrPm = s.Substring(8, 2).ToLower();

    var newHour = hour;

    if (hour == "12" && amOrPm == "am")
        newHour = "00";
    else if (amOrPm == "pm" && int.Parse(hour) != 12)
        newHour = (12 + int.Parse(hour)).ToString("00");

    return $"{newHour}:{minute}:{sec}";
}

int findMedian(List<int> arr)
{
    var sorted = arr.OrderBy(x => x).ToList();
    var middle = arr.Count / 2;
    return sorted.ElementAt(middle);
}

int lonelyinteger(List<int> a)
{
    return a
        .GroupBy(x => x)
        .ToDictionary(x => x.Key, x => x.Count())
        .Single(x => x.Value == 1)
        .Key;
}


int diagonalDifference(List<List<int>> arr)
{
    var len = arr[0].Count;

    var sum1 = 0;
    for (int i = 0; i < len; i++)
        sum1 += arr[i][i];
    
    var sum2 = 0;
    for (int i = 0; i < len; i++)
        sum2 += arr[i][len - 1 - i];

    return Math.Abs(sum1 - sum2);
}

List<int> countingSort(List<int> arr)
{
    var res = new int[100];

    foreach (var i in arr)
        res[i] += 1;

    return res.ToList();
}