using System.Collections;
using System.Text;

namespace day5;

public class Puzzle2
{
    private Stack<char> stack1 = new Stack<char>();
    private Stack<char> stack2 = new Stack<char>();
    private Stack<char> stack3 = new Stack<char>();
    private Stack<char> stack4 = new Stack<char>();
    private Stack<char> stack5 = new Stack<char>();
    private Stack<char> stack6 = new Stack<char>();
    private Stack<char> stack7 = new Stack<char>();
    private Stack<char> stack8 = new Stack<char>();
    private Stack<char> stack9 = new Stack<char>();
    private List<Stack<char>> stackPointers = new List<Stack<char>>();

    private string[] lines =
        System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day5\input.txt");
    

    public Puzzle2()
    {
        stack1.Push('D');
        stack1.Push('H');
        stack1.Push('N');
        stack1.Push('Q');
        stack1.Push('T');
        stack1.Push('W');
        stack1.Push('V');
        stack1.Push('B');
        
        stack2.Push('D');
        stack2.Push('W');
        stack2.Push('B');
        
        stack3.Push('T');
        stack3.Push('S');
        stack3.Push('Q');
        stack3.Push('W');
        stack3.Push('J');
        stack3.Push('C');
        
        stack4.Push('F');
        stack4.Push('J');
        stack4.Push('R');
        stack4.Push('N');
        stack4.Push('Z');
        stack4.Push('T');
        stack4.Push('P');
        
        stack5.Push('G');
        stack5.Push('P');
        stack5.Push('V');
        stack5.Push('J');
        stack5.Push('M');
        stack5.Push('S');
        stack5.Push('T');
        
        stack6.Push('B');
        stack6.Push('W');
        stack6.Push('F');
        stack6.Push('T');
        stack6.Push('N');
        
        stack7.Push('B');
        stack7.Push('L');
        stack7.Push('D');
        stack7.Push('Q');
        stack7.Push('F');
        stack7.Push('H');
        stack7.Push('V');
        stack7.Push('N');
        
        
        stack8.Push('H');
        stack8.Push('P');
        stack8.Push('F');
        stack8.Push('R');
        
        stack9.Push('Z');
        stack9.Push('S');
        stack9.Push('M');
        stack9.Push('B');
        stack9.Push('L');
        stack9.Push('N');
        stack9.Push('P');
        stack9.Push('H');

        stackPointers.Add(stack1);
        stackPointers.Add(stack2);
        stackPointers.Add(stack3);
        stackPointers.Add(stack4);
        stackPointers.Add(stack5);
        stackPointers.Add(stack6);
        stackPointers.Add(stack7);
        stackPointers.Add(stack8);
        stackPointers.Add(stack9);

    }

    public void printSolution()
    {
        ExecuteCraneInstructions();
        string highestCrates = getHighestCrates();
        Console.WriteLine("The letter on the highest crates are: " + highestCrates);
    }
    private void ExecuteCraneInstructions()
    {
        foreach (string line in lines)
        {
            string[] parts = line.Split(' ');
            int cratesOnMove = Int32.Parse(parts[1]);
            int fromStackIndex = Int32.Parse(parts[3]) - 1;
            int toStackIndex = Int32.Parse(parts[5]) - 1;
            Stack<char> crateReverser = new Stack<char>();

            for (int i = 0; i < cratesOnMove; i++)
            {
                char crate = stackPointers[fromStackIndex].Pop();
                crateReverser.Push(crate);
            }
            for (int i = 0; i < cratesOnMove; i++)
            {
                char reveresedCrate = crateReverser.Pop();
                stackPointers[toStackIndex].Push(reveresedCrate);
            }
        }
        
    }
    private string getHighestCrates()
    {
        StringBuilder highestCrates = new StringBuilder();

        for (int i = 0; i < stackPointers.Count; i++)
        {
            highestCrates.Append(stackPointers[i].Peek());
        }

        return highestCrates.ToString();
    }


}