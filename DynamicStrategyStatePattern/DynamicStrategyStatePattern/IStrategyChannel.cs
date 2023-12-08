namespace DynamicStrategyStatePattern.DynamicStrategyStatePattern;

public interface IStrategyChannel
{
    StrategyChannel Channel { get; }
    void Activate();
    void Deactivate();
}