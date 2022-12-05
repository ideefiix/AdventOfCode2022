namespace day4;

public class Puzzle2
{
    private string[] lines =
        System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day4\input.txt");

    public void PrintSolution()
    {
        int elfPairs = 0;
        foreach (var line in lines)
        {
            string[] elfParts = line.Split(new char[]{',', '-'}); // -> {21,32,14,55}
            (int, int) elf1 = (int.Parse(elfParts[0]), int.Parse(elfParts[1]));
            (int, int) elf2 = (int.Parse(elfParts[2]), int.Parse(elfParts[3]));
            if (ElfPairOverlap(elf1, elf2))
            {
                elfPairs++;
            }
        }
        Console.WriteLine("There are " + elfPairs + " overlapping pairs!");
    }
    
    public bool ElfPairOverlap((int start, int end) elf1, (int start, int end) elf2)
    {
        //Elf1 in elf2 region
        if ((elf1.start >= elf2.start && elf1.start <= elf2.end) || (elf1.end >= elf2.start && elf1.end <= elf2.end))
        {
            return true;
        }
        
        //Elf2 in elf1 region
        if ((elf2.start >= elf1.start && elf2.start <= elf1.end) || (elf2.end >= elf1.start && elf2.end <= elf1.end))
        {
            return true;
        }

        return false;
    }
}