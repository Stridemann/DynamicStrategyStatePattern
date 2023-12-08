namespace DynamicStrategyStatePattern.DynamicStrategyStatePattern;

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

    public void InitialActivate()
    {
        foreach (var strategyChannel in _strategyChannels)
        {
            strategyChannel?.Activate();
        }
    }

    public void SetChannelStrategy(IStrategyChannel strategy)
    {
        _strategyChannels[(int)strategy.Channel] = strategy;
    }

    public void RemoveChannelStrategy(IStrategyChannel strategy)
    {
        _strategyChannels[(int)strategy.Channel] = null;
    }
}