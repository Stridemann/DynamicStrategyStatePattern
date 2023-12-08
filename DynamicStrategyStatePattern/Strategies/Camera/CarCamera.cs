using DynamicStrategyStatePattern.DynamicStrategyStatePattern;

namespace DynamicStrategyStatePattern.Strategies.Camera;

public class CarCamera : IStrategyChannel
{
    public StrategyChannel Channel => StrategyChannel.Camera;

    public void Activate()
    {
        Console.WriteLine("Activate CarCamera");
    }

    public void Deactivate()
    {
        Console.WriteLine("Deactivate CarCamera");
    }
}