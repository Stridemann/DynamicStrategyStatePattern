using DynamicStrategyStatePattern.Strategies.Camera;
using DynamicStrategyStatePattern.Strategies.Controls;
using DynamicStrategyStatePattern.Strategies.Input;

namespace DynamicStrategyStatePattern;

public static class Program
{
    public static void Main()
    {
        var statesController = new PlayerStatesController();

        Console.WriteLine("Activating initial CharacterState:");
        statesController.ActivateInitialState(statesController.CharacterState);
        Console.WriteLine();

        Console.WriteLine("Switching to CarState:");
        statesController.SwitchToState(statesController.CarState);
        Console.WriteLine();

        Console.WriteLine("Switching to CinematicState:");
        statesController.SwitchToState(statesController.CinematicState);
        Console.WriteLine();

        Console.WriteLine("Switching to CharacterState:");
        statesController.SwitchToState(statesController.CharacterState);
        Console.WriteLine();

        Console.ReadLine();
    }
}