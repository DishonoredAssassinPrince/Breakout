namespace Breakout.Models.Contracts
{
    using Breakout.AdditionalEntities;

    public interface IMessageHandler
    {
        string Status { get; }
        string Message { get; }

        void OnEndGame(object sender, EndGameArgs endGameArgs);
    }
}
