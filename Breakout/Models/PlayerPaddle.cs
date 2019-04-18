namespace Breakout.Models
{
    using Breakout.Models.Contracts;

    /// <summary>
    /// Class defining a player-controlled paddle.
    /// </summary>

    public class PlayerPaddle : BaseBlock, IPlayerPaddle
    {
        private const int defaultWidth = 300; 
        private const int defaultHeight = 50; 

        public PlayerPaddle(int x, int y, int screenWidth, int screenHeight)
            : base(x, y, defaultWidth, defaultHeight, screenWidth, screenHeight)
        {
            this.X -= this.Width;
            this.Y -= this.Height;
        }

        /// <summary>
        /// Move paddle according to cursor position.
        /// </summary>
        /// <param name="cursorPositionX"></param>
        public void MovePaddle(int cursorPositionX)
        {
            this.X = cursorPositionX - this.Width / 2;
        }
    }
}
