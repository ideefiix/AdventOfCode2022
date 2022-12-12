using day9;

var watch = new System.Diagnostics.Stopwatch();
watch.Start();
/*PuzzleSolver solver = new PuzzleSolver();
solver.PrintPuzzle1Solution();*/
PuzzleSolver2 solver2 = new PuzzleSolver2();
solver2.PrintPuzzle2Solution();
watch.Stop();

Console.WriteLine("Execution time " + watch.ElapsedMilliseconds + " ms");