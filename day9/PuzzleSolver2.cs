namespace day9;

public class PuzzleSolver2
{
    private string[] instructions;
    private HashSet<ValueTuple<int, int>> tailVisitedPositions;
    private LinkedList<ValueTuple<int, int>> knots;


    public PuzzleSolver2()
    {
        instructions =
            System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day9\input.txt");
        //Add knots
        knots = new LinkedList<ValueTuple<int, int>>();
        knots.AddFirst(new ValueTuple<int, int>(0, 0));
        knots.AddFirst(new ValueTuple<int, int>(0, 0));
        knots.AddFirst(new ValueTuple<int, int>(0, 0));
        knots.AddFirst(new ValueTuple<int, int>(0, 0));
        knots.AddFirst(new ValueTuple<int, int>(0, 0));
        knots.AddFirst(new ValueTuple<int, int>(0, 0));
        knots.AddFirst(new ValueTuple<int, int>(0, 0));
        knots.AddFirst(new ValueTuple<int, int>(0, 0));
        knots.AddFirst(new ValueTuple<int, int>(0, 0));
        knots.AddFirst(new ValueTuple<int, int>(0, 0));

        tailVisitedPositions = new HashSet<ValueTuple<int, int>>();
        tailVisitedPositions.Add(new ValueTuple<int, int>(0, 0));
    }

    public void PrintPuzzle2Solution()
    {
        foreach (var instruction in instructions)
        {
            ExecuteInstruction(instruction);
        }

        Console.WriteLine("The tail visited " + tailVisitedPositions.Count + " coordinates in puzzle 2");
    }

    private void ExecuteInstruction(string instruction)
    {
        int headMoveX = 0;
        int headMoveY = 0;
        string[] directionAndSteps = instruction.Split(" ");

        switch (char.Parse(directionAndSteps[0]))
        {
            case 'U':
                headMoveY = -int.Parse(directionAndSteps[1]);
                break;
            case 'D':
                headMoveY = int.Parse(directionAndSteps[1]);
                break;
            case 'L':
                headMoveX = -int.Parse(directionAndSteps[1]);
                break;
            case 'R':
                headMoveX = int.Parse(directionAndSteps[1]);
                break;
            default:
                throw new ArgumentException("Invalid direction!");
        }

        MoveHead(headMoveX, headMoveY, knots.First);
    }

    private void MoveHead(int x, int y, LinkedListNode<ValueTuple<int, int>> head)
    {
        //Move in X 
        for (int i = 0; i < Math.Abs(x); i++)
        {
            if (x > 0)
            {
                ValueTuple<int, int> oldPosHead = head.Value;
                head.Value = new ValueTuple<int, int>(head.Value.Item1 + 1, head.Value.Item2);
                MoveTail(head.Next);
            }
            else
            {
                ValueTuple<int, int> oldPosHead = head.Value;
                head.Value = new ValueTuple<int, int>(head.Value.Item1 - 1, head.Value.Item2);
                MoveTail(head.Next);
            }
        }

        //Move in Y
        for (int i = 0; i < Math.Abs(y); i++)
        {
            if (y > 0)
            {
                ValueTuple<int, int> oldPosHead = head.Value;
                head.Value = new ValueTuple<int, int>(head.Value.Item1, head.Value.Item2 + 1);
                MoveTail(head.Next);
            }
            else
            {
                ValueTuple<int, int> oldPosHead = head.Value;
                head.Value = new ValueTuple<int, int>(head.Value.Item1, head.Value.Item2 - 1);
                MoveTail(head.Next);
            }
        }
    }

    //All nodes after headNode are tailNodes
    private void MoveTail(LinkedListNode<ValueTuple<int, int>> tailNode)
    {
        int xDiff = tailNode.Previous.Value.Item1 - tailNode.Value.Item1;
        int yDiff = tailNode.Previous.Value.Item2 - tailNode.Value.Item2;
        
        if (!(Math.Abs(xDiff) > 1 ||
              Math.Abs(yDiff) > 1)) return; //Tail do not move


        tailNode.Value = new ValueTuple<int, int>(tailNode.Value.Item1 + Math.Sign(xDiff),
            tailNode.Value.Item2 + Math.Sign(yDiff));
       
        if (tailNode.Next == null) //Last node in tail
        {
            tailVisitedPositions.Add(tailNode.Value);
        }
        else
        {
            MoveTail(tailNode.Next);
        }
    }
}