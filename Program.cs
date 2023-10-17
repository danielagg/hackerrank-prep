// See https://aka.ms/new-console-template for more information

plusMinus(new[] { -4, 3, -9, 0, 4, 1 }.ToList());
miniMaxSum(new[] { 1, 3, 5, 7, 9 }.ToList());

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