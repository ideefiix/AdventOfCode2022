using System.Numerics;

namespace day11;

public class PuzzleSolver
{
    public PuzzleSolver()
    {
        
    }

    public void PrintPuzzle1Solution()
    {
        int monkeyBuisness;
        List<Monkey> monkeys = new List<Monkey>();
        Monkey0 monkey0 = new Monkey0(new List<BigInteger> { 52,78,79,63,51,94});
        Monkey1 monkey1 = new Monkey1(new List<BigInteger> { 77,94,70,83,53 });
        Monkey2 monkey2 = new Monkey2(new List<BigInteger> { 98,50,76 });
        Monkey3 monkey3 = new Monkey3(new List<BigInteger> { 92,91,61,75,99,63,84,69 });
        Monkey4 monkey4 = new Monkey4(new List<BigInteger> { 51,53,83,52});
        Monkey5 monkey5 = new Monkey5(new List<BigInteger> { 76,76 });
        Monkey6 monkey6 = new Monkey6(new List<BigInteger> { 75, 59, 93, 69, 76, 96, 65 });
        Monkey7 monkey7 = new Monkey7(new List<BigInteger> { 89 });

        monkey0.MonkeyBuddies = new List<Monkey> { monkey1, monkey6 };
        monkey1.MonkeyBuddies = new List<Monkey> { monkey3, monkey5 };
        monkey2.MonkeyBuddies = new List<Monkey> { monkey0, monkey6 };
        monkey3.MonkeyBuddies = new List<Monkey> { monkey5, monkey7 };
        monkey4.MonkeyBuddies = new List<Monkey> { monkey0, monkey2 };
        monkey5.MonkeyBuddies = new List<Monkey> { monkey4, monkey7 };
        monkey6.MonkeyBuddies = new List<Monkey> { monkey1, monkey3};
        monkey7.MonkeyBuddies = new List<Monkey> { monkey2, monkey4 };
        
        monkeys.Add(monkey0);
        monkeys.Add(monkey1);
        monkeys.Add(monkey2);
        monkeys.Add(monkey3);
        monkeys.Add(monkey4);
        monkeys.Add(monkey5);
        monkeys.Add(monkey6);
        monkeys.Add(monkey7);
        
        playRounds(monkeys, 20);

        monkeyBuisness = CalculateMonkeyBuisness(monkeys);
        Console.WriteLine("The monkeybuisness after 20 rounds are " + monkeyBuisness);
    }

    public int CalculateMonkeyBuisness(List<Monkey> monkeys)
    {
        List<int> inspectedTimes = new List<int>();
        foreach (var monkey in monkeys)
        {
            inspectedTimes.Add(monkey.Inspections);
        }
        
        inspectedTimes.Sort();

        return inspectedTimes[inspectedTimes.Count - 1] * inspectedTimes[inspectedTimes.Count - 2];
    }

    public void playRounds(List<Monkey> monkeys, int rounds)
    {
        for (int i = 0; i < rounds; i++)
        {
            foreach (var monkey in monkeys)
            {
                for (int j = 0; j < monkey.Items.Count; j++)
                {
                    monkey.Items[j] = monkey.InspectItem(monkey.Items[j]);
                    monkey.ThrowItem(monkey.Items[j]);
                }
                monkey.RemoveAllItems();
            }
        }
    }
}