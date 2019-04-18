namespace Breakout.Models
{
    using Breakout.Models.Contracts;

    /// <summary>
    /// Base class for block objects.
    /// </summary>
    public abstract class BaseBlock : IBlock
    {
        private int x;
        private int y;

        /// <summary>
        /// BaseBlock constructor.
        /// </summary>
        /// <param name="x">X position of block</param>
        /// <param name="y">Y position of block</param>
        /// <param name="width">Width of block</param>
        /// <param name="height">Height of block</param>
        /// <param name="screenWidth">Screen Width</param>
        /// <param name="screenHeight">Screen Height</param>
        public BaseBlock(int x, int y, int width, int height, int screenWidth, int screenHeight)
        {
            this.ScreenHeight = screenHeight;
            this.ScreenWidth = screenWidth;

            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// X position of block.
        /// </summary>
        public int X {
            get
            {
                return this.x;
            }
            protected set
            {
                if(value < 0)
                {
                    value = 0;
                }
                else if(value + this.Width > this.ScreenWidth)
                {
                    value = ScreenWidth - this.Width;
                }
             
                this.x = value;
            }
        }

        /// <summary>
        /// Y position of block.
        /// </summary>
        public int Y {
            get
            {
                return this.y;
            }
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > ScreenHeight)
                {
                    value = ScreenHeight;
                }
                this.y = value;
            }
        }

        /// <summary>
        /// Width of block.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Height of block.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Screen Height.
        /// </summary>
        public int ScreenHeight { get; set; }

        /// <summary>
        /// Screen Width.
        /// </summary>
        public int ScreenWidth { get; set; }
    }
}
