namespace day9;

public class PuzzleSolver
{
    private string[] instructions;
    private HashSet<ValueTuple<int, int>> tailVisitedPositions;
    private ValueTuple<int, int> headPosition;
    private ValueTuple<int, int> tailPosition;


    public PuzzleSolver()
    {
        instructions =
            System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day9\input.txt");
        tailVisitedPositions = new HashSet<ValueTuple<int,int>>();
        headPosition = new ValueTuple<int,int>(0, 0);
        tailPosition = new ValueTuple<int,int>(0, 0);
        tailVisitedPositions.Add(new ValueTuple<int,int>(0, 0));
    }
    
    public void PrintPuzzle1Solution()
    {
        foreach (var instruction in instructions)
        {
            ExecuteInstruction(instruction);
        }
        Console.WriteLine("The tail visited " + tailVisitedPositions.Count + " coordinates in puzzle 1");
    }

    private void ExecuteInstruction(string instruction)
    {
        int headMoveX = 0;
        int headMoveY = 0;
        string[] directionAndSteps = instruction.Split(" ");

        switch (char.Parse(directionAndSteps[0]))
        {
            case 'U':
                headMoveY = - int.Parse(directionAndSteps[1]);
                break;
            case 'D':
                headMoveY = int.Parse(directionAndSteps[1]);
                break;
            case 'L':
                headMoveX = - int.Parse(directionAndSteps[1]);
                break;
            case 'R':
                headMoveX = int.Parse(directionAndSteps[1]);
                break;
            default:
                throw new ArgumentException("Invalid direction!");
        }
        MoveHead(headMoveX, headMoveY);
    }

    private void MoveHead(int x, int y)
    {
        //Move in X 
        for (int i = 0; i < Math.Abs(x); i++)
        {
            if (x > 0)
            {
                ValueTuple<int,int> oldPosHead = (headPosition.Item1, headPosition.Item2);
                headPosition.Item1 += 1;
                MoveTail(oldPosHead);
            }
            else
            {
                ValueTuple<int,int> oldPosHead = (headPosition.Item1, headPosition.Item2);
                headPosition.Item1 -= 1;
                MoveTail(oldPosHead);
            }
            
        }
        
        //Move in Y
        for (int i = 0; i < Math.Abs(y); i++)
        {
            if (y > 0)
            {
                ValueTuple<int,int> oldPosHead = (headPosition.Item1, headPosition.Item2);
                headPosition.Item2 += 1;
                MoveTail(oldPosHead);
            }
            else
            {
                ValueTuple<int,int> oldPosHead = (headPosition.Item1, headPosition.Item2);
                headPosition.Item2 -= 1;
                MoveTail(oldPosHead);
            }
        }
    }
    private void MoveTail(ValueTuple<int, int> oldPosHead)
    {
        if (Math.Abs(headPosition.Item1 - tailPosition.Item1) > 1  ||
            Math.Abs(headPosition.Item2 - tailPosition.Item2) > 1) //Tail need to move
        {
            tailPosition = oldPosHead;
            tailVisitedPositions.Add(tailPosition);
        }
        else
        {
            //All good sarge.
        }
    }
}