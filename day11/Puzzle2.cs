using System.Text.RegularExpressions;

namespace day11;

/**
 * Solution is taken from encse
 * Link to his github: https://github.com/encse/adventofcode/blob/master/2022/Day11/Solution.cs
 */
public class Puzzle2
{
    public void PrintPuzzleSolution()
    {
        string[] input =
            System.IO.File.ReadAllLines(@"C:\Users\flind\Desktop\Github repos\AdventOfCode2022\day11\input.txt");
        var monkeys = ParseMonkeys(input);
        var mod = monkeys.Aggregate(1, (mod, monkey) => mod * monkey.mod);
        Run(10_000, monkeys, w => w % mod); // <- I missed this
        Console.WriteLine("Monkeybuisness after 10 000 rounds is " + GetMonkeyBusinessLevel(monkeys));
    }

    Monkey[] ParseMonkeys(string[] input)
    {
        List<Monkey> monkeyList = new List<Monkey>();
        for (int i = 0; i < input.Length; i++)
        {
            var tryParse = LineParser(input[i]);
            if (tryParse(@"Monkey (\d+)", out var arg))
            {
                monkeyList.Add(ParseMonkey(input, i));
            }
        }

        Monkey[] monkeys = monkeyList.ToArray();
        return monkeys;
    }

    Monkey ParseMonkey(string[] input, int startLine)
    {
        var monkey = new Monkey();

        for (int i = startLine; i < startLine + 6; i++)
        {
            var tryParse = LineParser(input[i]);
            if (tryParse(@"Monkey (\d+)", out var arg))
            {
                // pass
            }
            else if (tryParse("Starting items: (.*)", out arg))
            {
                monkey.items = new Queue<long>(arg.Split(", ").Select(long.Parse));
            }
            else if (tryParse(@"Operation: new = old \* old", out _))
            {
                monkey.operation = old => old * old;
            }
            else if (tryParse(@"Operation: new = old \* (\d+)", out arg))
            {
                monkey.operation = old => old * int.Parse(arg);
            }
            else if (tryParse(@"Operation: new = old \+ (\d+)", out arg))
            {
                monkey.operation = old => old + int.Parse(arg);
            }
            else if (tryParse(@"Test: divisible by (\d+)", out arg))
            {
                monkey.mod = int.Parse(arg);
            }
            else if (tryParse(@"If true: throw to monkey (\d+)", out arg))
            {
                monkey.passToMonkeyIfDivides = int.Parse(arg);
            }
            else if (tryParse(@"If false: throw to monkey (\d+)", out arg))
            {
                monkey.passToMonkeyOtherwise = int.Parse(arg);
            }
            else
            {
                Console.WriteLine(input[i]);
                throw new ArgumentException(input[i]);
            }
        }

        return monkey;
    }

    long GetMonkeyBusinessLevel(IEnumerable<Monkey> monkeys) =>
        monkeys
            .OrderByDescending(monkey => monkey.inspectedItems)
            .Take(2)
            .Aggregate(1L, (res, monkey) => res * monkey.inspectedItems);

    void Run(int rounds, Monkey[] monkeys, Func<long, long> updateWorryLevel)
    {
        for (var i = 0; i < rounds; i++)
        {
            foreach (var monkey in monkeys)
            {
                while (monkey.items.Any())
                {
                    monkey.inspectedItems++;

                    var item = monkey.items.Dequeue();
                    item = monkey.operation(item);
                    item = updateWorryLevel(item);

                    var targetMonkey = item % monkey.mod == 0
                        ? monkey.passToMonkeyIfDivides
                        : monkey.passToMonkeyOtherwise;

                    monkeys[targetMonkey].items.Enqueue(item);
                }
            }
        }
    }

    class Monkey
    {
        public Queue<long> items;
        public Func<long, long> operation;
        public int inspectedItems;
        public int mod;
        public int passToMonkeyIfDivides, passToMonkeyOtherwise;
    }

    // converts a line into a tryParse-style parser function
    TryParse LineParser(string line)
    {
        bool match(string pattern, out string arg)
        {
            var m = Regex.Match(line, pattern);
            if (m.Success)
            {
                arg = m.Groups[m.Groups.Count - 1].Value;
                return true;
            }
            else
            {
                arg = "";
                return false;
            }
        }

        return match;
    }

    delegate bool TryParse(string pattern, out string arg);
}