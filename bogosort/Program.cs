// Import Libraries
using System.Diagnostics;

Random rnd = new Random();
Stopwatch sw = new Stopwatch();

// Sorts array a[0..n-1] using Bogo Sort
List<int> a = new List<int>();
int attempts = 0;

// Primary Sort Function
void bogoSort(List<int> a)
{
    var n = a.Count();
    while (!isSorted(a))
    {
        shuffle(a);
    }
}

// Check if array is sorted or not
bool isSorted(List<int> a)
{
    var n = a.Count();
    foreach (var i in Enumerable.Range(0, n - 1))
    {
        if (a[i] > a[i + 1])
        {
            attempts++;
            return false;
        }
    }
    return true;
}

// Shuffle the permutation of the array
void shuffle(List<int> a)
{
    var n = a.Count();
    foreach (var i in Enumerable.Range(0, n))
    {
        var r = rnd.Next(0, n);
        var aI = a[i];
        var aR = a[r];
        a[i] = aR;
        a[r] = aI;
    }
}

// Write the progress to the console.
double attemptsPerSecond = 0;
object lockObject = new object();

void writeConsole()
{
    while (!isSorted(a))
    {
        lock (lockObject)
        {
            attemptsPerSecond = attempts / sw.Elapsed.TotalSeconds;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write($"Attempt Number: {attempts} | {(int)Math.Round(attemptsPerSecond)} attempts/sec | Running For: {Math.Round(sw.Elapsed.TotalSeconds)} seconds");
        }
        Thread.Sleep(1000); // Update every second
    }
}

// Test
Console.WriteLine("Attempting to sort array..");
a = new List<int> { 2, 2, 4, 1, 0, 5, 9, 2, 5, 10, 43, 12, 31};
sw.Start();

// Start a thread for sorting
Thread bogoThread = new Thread(() => bogoSort(a));
bogoThread.Start();

// Start a thread for updating console
Thread consoleThread = new Thread(writeConsole);
consoleThread.Start();

// Wait for sorting thread to finish
bogoThread.Join();

// Wait for console update thread to finish
consoleThread.Join();

Console.WriteLine("\nSorted Array:");
foreach (var i in a)
{
    Console.WriteLine(i);
}
