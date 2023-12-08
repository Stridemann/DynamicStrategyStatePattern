using DynamicStrategyStatePattern.DynamicStrategyStatePattern;
using DynamicStrategyStatePattern.Strategies.Camera;
using DynamicStrategyStatePattern.Strategies.Controls;
using DynamicStrategyStatePattern.Strategies.Input;

namespace DynamicStrategyStatePattern;

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