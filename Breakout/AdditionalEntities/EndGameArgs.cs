namespace Breakout.AdditionalEntities
{
    using System;

    public class EndGameArgs : EventArgs
    {
        public EndGameArgs(bool status, int score)
        {
            this.Status = status;
            this.Score = score;
        }

        public bool Status { get; }
        public int Score { get; }
    }
}