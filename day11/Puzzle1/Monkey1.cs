using System.Numerics;

namespace day11;

public class Monkey1 : Monkey
{
    public Monkey1(List<BigInteger> startingItems) : base(startingItems)
    {
        
    }

    public override BigInteger InspectItem(BigInteger item)
    {
        base.Inspections++;
        return (item + 3)/3;
    }

    public override void ThrowItem(BigInteger item)
    {
        if (item % 7 == 0)
        {
            base.MonkeyBuddies[1].Items.Add(item);
        }
        else
        {
            base.MonkeyBuddies[0].Items.Add(item);
        }
    }
}