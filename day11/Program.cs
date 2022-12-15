using day11;

//PuzzleSolver puzzleSolver = new PuzzleSolver();
Puzzle2 puzzle2 = new Puzzle2();
var watch = new System.Diagnostics.Stopwatch();
watch.Start();
//puzzleSolver.PrintPuzzle1Solution();
puzzle2.PrintPuzzleSolution();
watch.Stop();

Console.WriteLine("Execution time is " + watch.ElapsedMilliseconds + " ms");
