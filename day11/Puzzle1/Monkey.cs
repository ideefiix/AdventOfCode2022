using System.Numerics;

namespace day11;

public abstract class Monkey
{
    public List<BigInteger> Items { get; set; }
    public int Inspections { get; set; }
    public List<Monkey> MonkeyBuddies { get; set; }

    public Monkey(List<BigInteger> startingItems)
    {
        Items = startingItems;
        Inspections = 0;
    }

        
        public abstract BigInteger InspectItem(BigInteger item);
        public abstract void ThrowItem(BigInteger item);

        public void RemoveAllItems()
        {
            Items = new List<BigInteger>();
        }
}