using System.Text;

List<KeyValuePair<char, int>> letterMappings = new List<KeyValuePair<char, int>>()
{
    new KeyValuePair<char, int>('a', 1),
    new KeyValuePair<char, int>('b', 2),
    new KeyValuePair<char, int>('c', 3),
    new KeyValuePair<char, int>('d', 4),
    new KeyValuePair<char, int>('e', 5),
    new KeyValuePair<char, int>('f', 6),
    new KeyValuePair<char, int>('g', 7),
    new KeyValuePair<char, int>('h', 8),
    new KeyValuePair<char, int>('i', 9),
    new KeyValuePair<char, int>('j', 10),
    new KeyValuePair<char, int>('k', 11),
    new KeyValuePair<char, int>('l', 12),
    new KeyValuePair<char, int>('m', 13),
    new KeyValuePair<char, int>('n', 14),
    new KeyValuePair<char, int>('o', 15),
    new KeyValuePair<char, int>('p', 16),
    new KeyValuePair<char, int>('q', 17),
    new KeyValuePair<char, int>('r', 18),
    new KeyValuePair<char, int>('s', 19),
    new KeyValuePair<char, int>('t', 20),
    new KeyValuePair<char, int>('u', 21),
    new KeyValuePair<char, int>('v', 22),
    new KeyValuePair<char, int>('w', 23),
    new KeyValuePair<char, int>('x', 24),
    new KeyValuePair<char, int>('y', 25),
    new KeyValuePair<char, int>('z', 26),
    new KeyValuePair<char, int>('A', 27),
    new KeyValuePair<char, int>('B', 28),
    new KeyValuePair<char, int>('C', 29),
    new KeyValuePair<char, int>('D', 30),
    new KeyValuePair<char, int>('E', 31),
    new KeyValuePair<char, int>('F', 32),
    new KeyValuePair<char, int>('G', 33),
    new KeyValuePair<char, int>('H', 34),
    new KeyValuePair<char, int>('I', 35),
    new KeyValuePair<char, int>('J', 36),
    new KeyValuePair<char, int>('K', 37),
    new KeyValuePair<char, int>('L', 38),
    new KeyValuePair<char, int>('M', 39),
    new KeyValuePair<char, int>('N', 40),
    new KeyValuePair<char, int>('O', 41),
    new KeyValuePair<char, int>('P', 42),
    new KeyValuePair<char, int>('Q', 43),
    new KeyValuePair<char, int>('R', 44),
    new KeyValuePair<char, int>('S', 45),
    new KeyValuePair<char, int>('T', 46),
    new KeyValuePair<char, int>('U', 47),
    new KeyValuePair<char, int>('V', 48),
    new KeyValuePair<char, int>('W', 49),
    new KeyValuePair<char, int>('X', 50),
    new KeyValuePair<char, int>('Y', 51),
    new KeyValuePair<char, int>('Z', 52)
};

Console.WriteLine("The solution to puzzle 1 is: " + Puzzle1Solution(letterMappings) + " points");
Console.WriteLine("The solution to puzzle 2 is: " + Puzzle2Solution(letterMappings) + " points");

static int Puzzle1Solution(List<KeyValuePair<char, int>> letterMappings)
{
    int totalItemScore = 0;
    string[] lines =
        System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day3\input.txt");
    
    foreach (var line in lines)
    {
        string firstCompartment = line.Substring(0, line.Length / 2);
        string secondCompartment = line.Substring(line.Length / 2);
        char commonCharacter = FindCommonLetterInCompartments(firstCompartment, secondCompartment);
        KeyValuePair<char, int> scorePair = letterMappings.Find(pair => pair.Key == commonCharacter);
        totalItemScore += scorePair.Value;
    }

    return totalItemScore;
}

static int Puzzle2Solution(List<KeyValuePair<char, int>> letterMappings)
{
    int totalItemScore = 0;
    string[] lines =
        System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day3\input.txt");

    for (int i = 0; i < lines.Length; i += 3)
    {
        string commonString = FindCommonLettersInCompartments(lines[i], lines[i +1]);
        char commonChar = FindCommonLetterInCompartments(commonString, lines[i + 2]);
        KeyValuePair<char, int> scorePair = letterMappings.Find(pair => pair.Key == commonChar);
        totalItemScore += scorePair.Value;
    }

    return totalItemScore;
}

static char FindCommonLetterInCompartments(string compartment1, string compartment2)
{
    char[] compartment1Array = compartment1.ToCharArray();
    char[] compartment2Array = compartment2.ToCharArray();

    for (int i = 0; i < compartment1Array.Length; i++)
    {
        for (int j = 0; j < compartment2.Length; j++)
        {
            if (compartment1Array[i] == compartment2Array[j])
                    {
                        return compartment1Array[i];
                    }
        }
        
    }

    throw new ArgumentException("Compartments does not have any common letters!");
}

static string FindCommonLettersInCompartments(string compartment1, string compartment2)
{
    char[] compartment1Array = compartment1.ToCharArray();
    char[] compartment2Array = compartment2.ToCharArray();
    StringBuilder commonLetters = new StringBuilder();

    for (int i = 0; i < compartment1Array.Length; i++)
    {
        for (int j = 0; j < compartment2.Length; j++)
        {
            if (compartment1Array[i] == compartment2Array[j])
            {
                commonLetters.Append(compartment1[i]);
            }
        }
        
    }

    if (commonLetters.ToString() == "")
    {
    throw new ArgumentException("Compartments does not have any common letters!");
    }
    return commonLetters.ToString();
}




