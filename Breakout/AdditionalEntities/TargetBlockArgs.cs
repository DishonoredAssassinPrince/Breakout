namespace Breakout.AdditionalEntities
{
    using System;

    public class TargetBlockArgs : EventArgs
    {
        public TargetBlockArgs(int id)
        {
            this.ID = id;
        }

        public int ID { get; }
    }
}