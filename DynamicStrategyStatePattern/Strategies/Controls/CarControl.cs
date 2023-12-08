using DynamicStrategyStatePattern.DynamicStrategyStatePattern;

namespace DynamicStrategyStatePattern.Strategies.Controls;

public class CarControl : IStrategyChannel
{
    public StrategyChannel Channel => StrategyChannel.Controls;

    public void Activate()
    {
        Console.WriteLine("Activate CarControl");
    }

    public void Deactivate()
    {
        Console.WriteLine("Deactivate CarControl");
    }
}