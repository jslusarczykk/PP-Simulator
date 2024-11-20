namespace Simulator.Maps;

public abstract class SmallMap: Map
{
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 30)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX));
        }
    }
}