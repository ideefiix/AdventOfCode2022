using System.Numerics;

namespace day11;

public class Monkey4 : Monkey
{
    public Monkey4(List<BigInteger> startingItems) : base(startingItems)
    {
        
    }

    public override BigInteger InspectItem(BigInteger item)
    {
        base.Inspections++;
        return (item + 7)/3;
    }

    public override void ThrowItem(BigInteger item)
    {
        if (item % 3 == 0)
        {
            base.MonkeyBuddies[1].Items.Add(item);
        }
        else
        {
            base.MonkeyBuddies[0].Items.Add(item);
        }
    }
}