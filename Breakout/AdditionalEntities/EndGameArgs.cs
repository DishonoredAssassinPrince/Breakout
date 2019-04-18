namespace Breakout.AdditionalEntities
{
    using System;

    public class EndGameArgs : EventArgs
    {
        public EndGameArgs(bool status)
        {
            this.Status = status;
        }

        public bool Status { get; }
    }
}