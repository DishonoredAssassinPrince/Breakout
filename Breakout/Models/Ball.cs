namespace Breakout.Models
{
    using Breakout.AdditionalEntities;
    using Breakout.Models.Contracts;
    using System;

    /// <summary>
    /// Class defining a ball object. 
    /// </summary>

    public class Ball : BaseBlock, IBall
    {
        private const int DefaultWidth = 25;
        private const int DefaultHeight = 25;

        private const int StartVelocityX = 2; //2
        private const int StartVelocityY = 2; //2

        private int VelocityXIncrementer = 2;
        private int VelocityYIncrementer = 1;

        public Ball(int x, int y, int screenWidth, int screenHeight) : base(x, y, DefaultWidth, DefaultHeight, screenWidth, screenHeight)
        {
            this.VelocityX = StartVelocityX;
            this.VelocityY = StartVelocityY;
        }

        private int VelocityX { get; set; }
        private int VelocityY { get; set; }

        private int NextX => this.X + this.VelocityX;
        private int NextY => this.Y + this.VelocityY;

        public event EndGameEventHandler EndGame;

        public void OnBallSpeedIncreased(object sender, EventArgs e)
        {
            this.IncreaseVelocity();
        }

        /// <summary>
        /// Changes ball position according to velocity values.
        /// </summary>
        public void MoveBall()
        {
            this.X += VelocityX;

            if(this.X + this.Width >= this.ScreenWidth || this.X <= 0)
            {
                ChangeDirectionX();
            }

            this.Y += VelocityY;

            if (this.Y + this.Height >= this.ScreenHeight || this.Y <= 0)
            {
                ChangeDirectionY();
            }

            if(this.Y + this.Width >= ScreenHeight)
            {
                EndGameArgs endGameArgs = new EndGameArgs(false);
                this.EndGame(this, endGameArgs);
            }
        }

        /// <summary>
        /// Checks for a collision between the ball and a block object, changing the direction of the ball if there is one. Returns a boolean value, indicating if there was a collision.
        /// </summary>
        public bool CheckForBlockCollision(IBlock block)
        {
            //First makes check if in its next move the ball will be inside a block.
            if(((this.NextX >= block.X && this.NextX + this.Width <= block.X + block.Width) 
                || (this.NextX + this.Width >= block.X && this.NextX <= block.X + block.Width)) &&
                ((this.NextY >= block.Y && this.NextY + this.Height <= block.Y + block.Height)
                || (this.NextY + this.Height >= block.Y && this.NextY <= block.Y + block.Height)))
            {
                //Check if in its current position the ball is below/above the block and change horizontal direction
                if(this.X >= block.X && this.X <= block.X + block.Width)
                {
                    ChangeDirectionY();
                }
                //Check if in its current position the ball is beside the block and change vertical direction
                else if (this.Y >= block.Y && this.Y <= block.Y + block.Height)
                {
                    ChangeDirectionX();
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Increases velocity of the ball according to object incrementers.
        /// </summary>
        public void IncreaseVelocity()
        {
            this.VelocityX += VelocityXIncrementer;
            this.VelocityY += VelocityYIncrementer;
        }


        private void ChangeDirectionX()
        {
            this.VelocityX = -this.VelocityX;
            this.VelocityXIncrementer = -this.VelocityXIncrementer;
        }

        private void ChangeDirectionY()
        {
            this.VelocityY = -this.VelocityY;
            this.VelocityYIncrementer = -this.VelocityYIncrementer;
        }
    }
}
