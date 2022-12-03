Console.WriteLine("Solution for part 2!");

string[] lines = System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day1\input.txt");
int currentElf_calories = 0;
int[] highestElf_calories = { 0,0,0 };
int previousHighest_calories;
int total_calories;

foreach (string line in lines)
{
    
    if (String.IsNullOrEmpty(line)) //End of elf's backpack
    {
        for (int i = 0; i < 3; i++)//Compare with the 3 biggest backpacks
        {
            if (currentElf_calories > highestElf_calories[i]) 
            {
                previousHighest_calories = highestElf_calories[i];
                highestElf_calories[i] = currentElf_calories;
                currentElf_calories = previousHighest_calories;
            }
        }
        
        currentElf_calories = 0;
        continue;
    }

    int value = int.Parse(line);
    currentElf_calories += value; //Add calories to backpack
    
}

total_calories = highestElf_calories[0] + highestElf_calories[1] + highestElf_calories[2];
Console.WriteLine("The fattest backpacks contain together " + total_calories + " calories");