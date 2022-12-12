
using day10;

var watch = new System.Diagnostics.Stopwatch();
watch.Start();
PuzzleSolver puzzleSolver = new PuzzleSolver();
puzzleSolver.SolvePuzzle2();
watch.Stop();
Console.WriteLine("Execution took " + watch.ElapsedMilliseconds + " ms");