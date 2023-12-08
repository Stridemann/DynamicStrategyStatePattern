using DynamicStrategyStatePattern.DynamicStrategyStatePattern;

namespace DynamicStrategyStatePattern.Strategies.Input;

public class PlayerInput : IStrategyChannel
{
    public StrategyChannel Channel => StrategyChannel.Input;

    public void Activate()
    {
        Console.WriteLine("Activate PlayerInput");
    }

    public void Deactivate()
    {
        Console.WriteLine("Deactivate PlayerInput");
    }
}