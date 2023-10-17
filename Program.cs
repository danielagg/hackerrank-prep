// See https://aka.ms/new-console-template for more information

plusMinus(new[] { -4, 3, -9, 0, 4, 1 }.ToList());
miniMaxSum(new[] { 1, 3, 5, 7, 9 }.ToList());
timeConversion("12:06:00PM");

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
    else if (amOrPm == "pm")
        newHour = (int.Parse(hour) + 12).ToString("00");

    return $"{newHour}:{minute}:{sec}";
}