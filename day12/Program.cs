using System.Diagnostics;
using day12;

Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();
PuzzleSolver solver = new PuzzleSolver();
solver.PrintPuzzle1Solution();
stopwatch.Stop();

Console.WriteLine("Execution time " + stopwatch.ElapsedMilliseconds + " ms");
