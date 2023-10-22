// See https://aka.ms/new-console-template for more information

using System.Text;
using HackerRankPrep;

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

caesarCipher("There's a starman waiting in the sky", 3);

palindromeIndex("aaab");

gridChallenge(new[] { "eabcd", "fghij", "olkmn", "trpqs", "xywuv" }.ToList());

MemoizedFibonacci();

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

string caesarCipher(string s, int k)
{
    var alphaBet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    
    var res = new StringBuilder();
    for (int i = 0; i < s.Length; i++)
    {
        var curr = Char.ToUpper(s[i]);

        if (char.IsLetter(curr))
        {
            var index = Array.IndexOf(alphaBet, curr);
            var newIndex = index + k;

            if (newIndex >= alphaBet.Length)
                newIndex = newIndex % alphaBet.Length;

            res.Append(Char.IsUpper(s[i]) ? alphaBet[newIndex] : Char.ToLower(alphaBet[newIndex]));
        }
        else
            res.Append(s[i]);
    }

    return res.ToString();
}

int palindromeIndex(string s)
{
    if (IsPalindrome(s))
        return -1;

    for (int i = 0; i < s.Length; i++)
    {
        var toRemove = s.Remove(i, 1);
        if (IsPalindrome(toRemove))
            return i;
    }

    return -1;

    bool IsPalindrome(string s)
    {
        var copyS = s.ToCharArray();
        Array.Reverse(copyS);
        return s == new string(copyS);
    }
}

string gridChallenge(List<string> grid)
{
    // sort words
    var sortedGrid = new List<string>();
    foreach (var word in grid)
    {
        var copy = word.ToCharArray();
        Array.Sort(copy);
        sortedGrid.Add(new string(copy));
    }
    
    // check columns
    var newGrid = new List<string>();
    for (int i = 0; i < grid.First().Length; i++)
    {
        var temp = new StringBuilder();
        foreach (var word in grid)
            temp.Append(word[i]);
        
        newGrid.Add(temp.ToString());
    }
    
    foreach (var word in newGrid)
    {
        var copy = word.ToCharArray();
        Array.Sort(copy);
        if (word != new string(copy))
            return "NO";
    }
    
    return "YES";
}


// var points = new[] {
//     (0, 1), // up
//     (1, 0), // right
//     (0, -1), // down
//     (-1, 0) // left
// };
//
// var curr = (14, 5);
// foreach (var point in points)
// {
//     var newPoint = (curr.Item1 + point.Item1, curr.Item2 + point.Item2);
// }

int Fib(int n, Dictionary<int, int> memo)
{
    if (n <= 1)
        return 1;

    if (memo.ContainsKey(n))
        return n;
    
    var res = Fib(n - 1, memo) + Fib(n - 2, memo);
    memo.Add(n, res);
    return res;
}

void MemoizedFibonacci()
{
    Console.WriteLine(Fib(7, new Dictionary<int, int>()));
}


var node5 = new MyNode<int>(5, null);
var node4 = new MyNode<int>(4, node5);
var node3 = new MyNode<int>(3, node4);
var node2 = new MyNode<int>(2, node3);
var node1 = new MyNode<int>(1, node2);

var reversedListHead = ReverseLinkedList(node1);
Console.WriteLine(reversedListHead.ToString());

MyNode<T> ReverseLinkedList<T>(MyNode<T> head)
{
    MyNode<T>? prev = null;
    var current = head;

    while (current != null)
    {
        var next = current.Next;
        current = new MyNode<T>(current.Val, prev);
        prev = current;
        current = next;
    }

    return prev!;
}

var nums = new Dictionary<string, int>()
{
    { "I", 1 },
    { "V", 5 },
    { "X", 10 },
    { "L", 50 },
    { "C", 100 },
    { "D", 500 },
    { "M", 1000 },
};

var s = "CMXCVIII";

var sum = 0;
for (int i = 0; i < s.Length; i++)
{
    var curr = nums[s[i].ToString()];
    if(i + 1 < s.Length)
    {
        var next = nums[s[i + 1].ToString()];

        if (next > curr)
            sum -= curr;
        else
            sum += curr;
    }
    else
        sum += curr;
}
Console.WriteLine($"Roman numeral {s} is {sum} in decimal.");


int FindShortestSubArray(int[] nums) {
    var degrees = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    var maximums = degrees.Where(x => x.Value == degrees.Max(y => y.Value)).Select(x => x.Key).ToList();

    var result = int.MaxValue;
    foreach (var potential in maximums)
    {
        var first = Array.IndexOf(nums, potential);
        var last = Array.LastIndexOf(nums, potential);
        result = Math.Min(result, last - first + 1);
    }

    return result;
}
