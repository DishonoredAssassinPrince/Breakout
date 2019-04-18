namespace Breakout.Models
{
    using Breakout.AdditionalEntities;

    /// <summary>
    /// Class defining a target block object.
    /// </summary>
    /// 
    public class TargetBlock : BaseBlock
    {
        public TargetBlock(int x, int y, int width, int height, int screenWidth, int screenHeight, TargetBlocksCollection targetBlocks) : base(x, y, width, height, screenWidth, screenHeight)
        {
            this.ID = targetBlocks.Count;
            this.Destroyed += new TargetBlockEventHandler(targetBlocks.Destroy);
        }

        /// <summary>
        /// Integer defining a unique ID for every target block.
        /// </summary>
        public int ID { get; private set; }

        private event TargetBlockEventHandler Destroyed;

        /// <summary>
        /// Raises the Destroyed event of the TargetBlock object.
        /// </summary>
        public void Destroy()
        {
            TargetBlockArgs targetBlockArgs = new TargetBlockArgs(this.ID);
            this.Destroyed(this, targetBlockArgs);
        }
    }
}
