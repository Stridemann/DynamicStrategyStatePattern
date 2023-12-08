using DynamicStrategyStatePattern.DynamicStrategyStatePattern;

namespace DynamicStrategyStatePattern.Strategies.Camera;

public class CinematicCamera : IStrategyChannel
{
    public StrategyChannel Channel => StrategyChannel.Camera;

    public void Activate()
    {
        Console.WriteLine("Activate CinematicCamera");
    }

    public void Deactivate()
    {
        Console.WriteLine("Deactivate CinematicCamera");
    }
}