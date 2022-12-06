using System.Collections;
using System.Linq;

namespace day6;

public class Puzzle1
{
    public void PrintSolution()
    {
        int newpacketMarker;
        string communicationData =
            System.IO.File.ReadAllText(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day6\input.txt");
        char[] charaters = communicationData.ToCharArray();
        newpacketMarker = CharactersBeforeNewPacket(charaters);
        Console.WriteLine("There are " + newpacketMarker + " characters before the start of a new packet");
    }

    public int CharactersBeforeNewPacket(char[] input)
    {
        int lastReadCharacter = 14;
        List<char> currentCharacter = new List<char>();
        currentCharacter.Add(input[0]);
        currentCharacter.Add(input[1]);
        currentCharacter.Add(input[2]);
        currentCharacter.Add(input[3]);
        currentCharacter.Add(input[4]);
        currentCharacter.Add(input[5]);
        currentCharacter.Add(input[6]);
        currentCharacter.Add(input[7]);
        currentCharacter.Add(input[8]);
        currentCharacter.Add(input[9]);
        currentCharacter.Add(input[10]);
        currentCharacter.Add(input[11]);
        currentCharacter.Add(input[12]);
        currentCharacter.Add(input[13]);
        if (ListHasUniqueItems(currentCharacter))
        {
            return lastReadCharacter;
        }

        for (int i = 14; i < input.Length; i++)
        {
            currentCharacter.RemoveAt(0);
            currentCharacter.Add(input[i]);
            lastReadCharacter++;
            if (ListHasUniqueItems(currentCharacter))
            {
                return lastReadCharacter;
            }
        }

        throw new Exception("Didn't find any start of packet marker!");

    }

    public bool ListHasUniqueItems(List<char> collection)
    {
        foreach (var item in collection)
        {
            if (collection.FindAll(c => c == item).Count >= 2)
            {
                return false;
            }
        }

        return true;
    }
}