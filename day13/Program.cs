using System.Diagnostics;
using day13;

Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();
PuzzleSolver solver = new PuzzleSolver();
solver.Puzzle2Solution();
stopwatch.Stop();

Console.WriteLine("Execution time " + stopwatch.ElapsedMilliseconds + " ms");
