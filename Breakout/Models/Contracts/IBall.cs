namespace Breakout.Models.Contracts
{
    using Breakout.AdditionalEntities;

    public interface IBall
    {
        void MoveBall(TargetBlocksCollection targetBlocksCollection);
        void IncreaseVelocity();
    }
}
