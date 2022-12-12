using System.Text;

namespace day10;

public class PuzzleSolver
{
    private string[] instructions;
    private int signalstrenghtSum;
    private StringBuilder image;

    public PuzzleSolver()
    {
        instructions =
            System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day10\input.txt");
        image = new StringBuilder();
    }

    public void SolvePuzzle1()
    {
        signalstrenghtSum = ExecuteInstructionsUntilCycle(220);
        Console.WriteLine("The signal strength after 220 cycles are " + signalstrenghtSum);
    }

    public void SolvePuzzle2()
    {
        ExecuteInstructionsUntilCycle(999999);
        image.Remove(0, 1); //Remove first empty line
        Console.WriteLine(image.ToString());
    }

    private int ExecuteInstructionsUntilCycle(int cyclesToRun)
    {
        int signalStrenghSum = 0;
        int register = 1;
        int cycle = 0;

        foreach (var instruction in instructions)
        {
            if (cycle >= cyclesToRun) break;
            string[] parts = instruction.Split(" ");
            if (parts.Length == 1) //NOOP instruction
            {
                cycle++;
                DrawImage(cycle, register);
                signalStrenghSum += SignalStrength(cycle, register);
            }
            else //ADDX instruction
            {
                cycle++;
                DrawImage(cycle, register);
                signalStrenghSum += SignalStrength(cycle, register);
                cycle++;
                DrawImage(cycle, register);
                signalStrenghSum += SignalStrength(cycle, register);
                register += Int32.Parse(parts[1]);
            }
        }

        return signalStrenghSum;
    }

    //Each 40th cycle and the 20th has signalStrength > 0
    private int SignalStrength(int cycle, int register)
    {
        if ((cycle - 20) % 40 == 0)
        {
            //Console.WriteLine("Adding " + cycle * register + " to the signalstrength!");
            return cycle * register;
        }
        else
        {
            return 0;
        }
    }

    private void DrawImage(int cycle, int spritePos)
    {
        int pixelPos = (cycle - 1) % 40;
        if (pixelPos == 0)
        {
            image.Append('\n');
        }

        if (Math.Abs(pixelPos - spritePos) < 2)
        {
            image.Append('#');
        }
        else
        {
            image.Append('.');
        }
    }
}