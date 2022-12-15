using System.Numerics;

namespace day11;

public class Monkey3 : Monkey
{
    public Monkey3(List<BigInteger> startingItems) : base(startingItems)
    {
        
    }

    public override BigInteger InspectItem(BigInteger item)
    {
        base.Inspections++;
        return (item + 5)/3;
    }

    public override void ThrowItem(BigInteger item)
    {
        if (item % 11 == 0)
        {
            base.MonkeyBuddies[0].Items.Add(item);
        }
        else
        {
            base.MonkeyBuddies[1].Items.Add(item);
        }
    }
}