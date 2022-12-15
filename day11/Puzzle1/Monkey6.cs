using System.Numerics;

namespace day11;

public class Monkey6 : Monkey
{
    public Monkey6(List<BigInteger> startingItems) : base(startingItems)
    {
        
    }

    public override BigInteger InspectItem(BigInteger item)
    {
        base.Inspections++;
        return (item * 19)/3;
    }

    public override void ThrowItem(BigInteger item)
    {
        if (item % 17 == 0)
        {
            base.MonkeyBuddies[0].Items.Add(item);
        }
        else
        {
            base.MonkeyBuddies[1].Items.Add(item);
        }
    }
}