namespace Breakout.Models.Contracts
{
    public interface IBlock
    {
        int X { get; }
        int Y { get; }
        int Width { get; }
        int Height { get; }
    }
}
