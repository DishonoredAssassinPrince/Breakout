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

        private int VelocityXIncrementer = 1;
        private int VelocityYIncrementer = 1;

        public Ball(int x, int y, int screenWidth, int screenHeight) : base(x, y, DefaultWidth, DefaultHeight, screenWidth, screenHeight)
        {
            this.BaseVelocityX = StartVelocityX;
            this.BaseVelocityY = StartVelocityY;

            this.CurrentVelocityX = this.BaseVelocityX;
            this.CurrentVelocityY = this.BaseVelocityY;
        }

        private int BaseVelocityX { get; set; }
        private int BaseVelocityY { get; set; }

        private int CurrentVelocityX { get; set; }
        private int CurrentVelocityY { get; set; }

        private int NextX => this.X + this.CurrentVelocityX;
        private int NextY => this.Y + this.CurrentVelocityY;

        public event EndGameEventHandler EndGame;

        public void OnBallSpeedIncreased(object sender, EventArgs e)
        {
            this.IncreaseVelocity();
        }

        /// <summary>
        /// Changes ball position according to velocity values.
        /// </summary>
        /// <param name="targetBlocksCollection">Needed for calculating score should game end.</param>
        public void MoveBall(TargetBlocksCollection targetBlocksCollection)
        {
            this.X += CurrentVelocityX;

            if(this.X + this.Width >= this.ScreenWidth || this.X <= 0)
            {
                ChangeDirectionX();
            }

            this.Y += CurrentVelocityY;

            if (this.Y <= 0)
            {
                ChangeDirectionY();
            }

            if(this.Y + this.Width >= ScreenHeight)
            {
                EndGameArgs endGameArgs = new EndGameArgs(false, targetBlocksCollection.DestroyedBlocks);
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
                //Apply velocity change depending on point of collision with PlayerPaddle
                if(block is PlayerPaddle)
                {
                    int ballDistanceFromPaddleCenter = Math.Abs(block.Width / 2 - (this.X - block.X));
                    int centerDistanceFromBall = block.Width / 2 - ballDistanceFromPaddleCenter;
                    int directionX = this.X < block.X + block.Width / 2 ? -1 : 1;
                    int velocityX = ((ballDistanceFromPaddleCenter) / 10 + BaseVelocityX) / 2;
                    int velocityY = ((centerDistanceFromBall) / 10  + BaseVelocityY) / 2;
                    this.CurrentVelocityX = velocityX * directionX;
                    this.CurrentVelocityY = velocityY;
                    ChangeDirectionY();
                    return true;
                }
                //Check if in its current position the ball is below/above the block and change horizontal direction
                 if(this.X >= block.X && this.X <= block.X + block.Width)
                {
                    ChangeDirectionY();
                    return true;
                }
                //Check if in its current position the ball is beside the block and change vertical direction
                 if (this.Y >= block.Y && this.Y <= block.Y + block.Height)
                {
                    ChangeDirectionX();
                    return true;
                }

                return false;
            }
            return false;
        }

        /// <summary>
        /// Increases velocity of the ball according to object incrementers.
        /// </summary>
        public void IncreaseVelocity()
        {
            this.BaseVelocityX++;
            this.BaseVelocityY++;
        }


        private void ChangeDirectionX()
        {
            this.CurrentVelocityX = -this.CurrentVelocityX;
            this.VelocityXIncrementer = -this.VelocityXIncrementer;
        }

        private void ChangeDirectionY()
        {
            this.CurrentVelocityY = -this.CurrentVelocityY;
            this.VelocityYIncrementer = -this.VelocityYIncrementer;
        }
    }
}
