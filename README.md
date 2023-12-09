# Dynamic Strategy State Pattern
This pattern helps activate and deactivate strategies within a state when switching to another state, depending on whether the other state contains that strategy or not.

# Introduction
This pattern helps activate and deactivate strategies within a state when switching to another state, depending on whether the other state contains that strategy or not.
In the current article will be described an example of use of this pattern in game development.

# Example Situation
The player has three states: Character State, Car State, and Cinematic State. Each **state** has an array of **strategies** categorized by functionality and placed in corresponding array indices known as **channels**. These **channels** are **activated** or **deactivated** when **switching between states**. Some strategies will be shared among player states:

![DynamicStrategyStatePattern_0](https://github.com/Stridemann/DynamicStrategyStatePattern/assets/7633163/1ae7b0b3-97e6-4d68-851e-611564a45f5e)

In current example **strategy channel** is defined as C# Enum (integer value can be used as well):
```cs
public enum StrategyChannel
{
    Camera = 0,
    Input = 1,
    Controls = 2
}
```
Each **channel strategy** can have any implementation and in current example is defined as interface:
```cs
public interface IStrategyChannel
{
    StrategyChannel Channel { get; }
    void Activate();
    void Deactivate();
}
```
Example implementation of IStrategyChannel for CarCamera:
```cs
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
```
While switching to another **state**, we track the **strategy** changes in each **strategy channel** and **activate** or **deactivate** corresponding **strategies** if any changes occur:
![DynamicStrategyStatePattern_1](https://github.com/Stridemann/DynamicStrategyStatePattern/assets/7633163/7647a1e1-6205-4a7b-bd73-0d337c8b50dc)
State class implementation:
```cs
public class PlayerState
{
    private const int CHANNELS = 3;
    private readonly IStrategyChannel[] _strategyChannels = new IStrategyChannel[CHANNELS];

    public void SwitchToState(PlayerState state)
    {
        for (var i = 0; i < CHANNELS; i++)
        {
            var currentStrategy = _strategyChannels[i];
            var targetStrategy = state._strategyChannels[i];

            //strategy been changed
            if (currentStrategy != targetStrategy)
            {
                if (currentStrategy != null)
                {
                    currentStrategy.Deactivate();
                }

                if (targetStrategy != null)
                {
                    targetStrategy.Activate();
                }
            }
        }
    }

    public void SetChannelStrategy(IStrategyChannel strategy)
    {
        _strategyChannels[(int)strategy.Channel] = strategy;
    }
}
```
PlayerStatesController builds and keeps all the states, keeps track of current one and initializes initial state:
```cs
public class PlayerStatesController
{
    private PlayerState _currentState;
    public readonly PlayerState CharacterState;
    public readonly PlayerState CarState;
    public readonly PlayerState CinematicState;

    public PlayerStatesController()
    {
        CharacterState = new PlayerState();
        CarState = new PlayerState();
        CinematicState = new PlayerState();

        var playerInput = new PlayerInput();
        CharacterState.SetChannelStrategy(new FreeLookCamera());
        CharacterState.SetChannelStrategy(playerInput);
        CarState.SetChannelStrategy(new CarCamera());
        CarState.SetChannelStrategy(playerInput);
        CarState.SetChannelStrategy(new CarControl());
        CinematicState.SetChannelStrategy(new CinematicCamera());
    }

    public void ActivateInitialState(PlayerState state)
    {
        _currentState = state;
        _currentState.InitialActivate();
    }

    public void SwitchToState(PlayerState state)
    {
        _currentState.SwitchToState(state);
        _currentState = state;
    }
}
```
# Usage example
In this code example we activate each state sequentially and then switch back to the first one:
```cs
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
```
After executing we will get the following output:
```
Activating initial CharacterState:
Activate FreeLookCamera
Activate PlayerInput

Switching to CarState:
Deactivate FreeLookCamera
Activate CarCamera
Activate CarControl

Switching to CinematicState:
Deactivate CarCamera
Activate CinematicCamera
Deactivate PlayerInput
Deactivate CarControl

Switching to CharacterState:
Deactivate CinematicCamera
Activate FreeLookCamera
Activate PlayerInput
```
