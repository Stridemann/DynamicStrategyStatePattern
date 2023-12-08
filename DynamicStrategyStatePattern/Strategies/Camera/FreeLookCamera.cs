using DynamicStrategyStatePattern.DynamicStrategyStatePattern;

namespace DynamicStrategyStatePattern.Strategies.Camera;

public class FreeLookCamera : IStrategyChannel
{
    public StrategyChannel Channel => StrategyChannel.Camera;

    public void Activate()
    {
        Console.WriteLine("Activate FreeLookCamera");
    }

    public void Deactivate()
    {
        Console.WriteLine("Deactivate FreeLookCamera");
    }
}