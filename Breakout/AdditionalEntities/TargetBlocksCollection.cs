namespace Breakout.AdditionalEntities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// Class defining a collection of target blocks.
    /// </summary>
    public class TargetBlocksCollection : ArrayList
    {
        public TargetBlocksCollection(IList<Control> targetBlockViews)
        {
            this.TargetBlockViews = targetBlockViews;
        }

        public IList<Control> TargetBlockViews;

        public event EventHandler BallSpeedToIncrease;
        public event EndGameEventHandler EndGame;

        public int DestroyedBlocks => this.Count - CountBlocks();

        public void Destroy(object sender, TargetBlockArgs targetBlockArgs)
        {
            int id = targetBlockArgs.ID;

            this[id] = null;
            this.TargetBlockViews[id].Dispose();
            this.TargetBlockViews[id] = null;

            int countOfBlocks = CountBlocks();

            //If there are no more blocks -> Stop game
            if (countOfBlocks == 0)
            {
                EndGame(this, new EndGameArgs(true, DestroyedBlocks));
            }
            //////if the destroyed block is a multiple of 5, increase speed of ball
            else if (countOfBlocks % 5 == 0)
            {
                BallSpeedToIncrease(this, new EventArgs());
            }
        }

        private int CountBlocks()
        {
            int countOfBlocks = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i] != null)
                {
                    countOfBlocks++;
                }
            }

            return countOfBlocks;
        }
    }
}
