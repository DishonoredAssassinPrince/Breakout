namespace Breakout.Controllers
{
    using Breakout.AdditionalEntities;
    using Breakout.Controllers.Contracts;
    using Breakout.Models;
    using Breakout.Models.Contracts;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Controller class which updates the state of the in-game objects.
    /// </summary>
    public class GameplayController : IGameplayController
    {
        private PlayerPaddle paddleModel;
        private Control paddleView;
        private Ball ballModel;
        private Control ballView;
        private Form form;
        private TargetBlocksCollection targetBlocks;

        /// <summary>
        /// Constructor defining the different parameters used in the game loop.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="paddleModel"></param>
        /// <param name="paddleView"></param>
        /// <param name="ballModel"></param>
        /// <param name="ballView"></param>
        /// <param name="targetBlocksCollection"></param>
        /// <param name="messageHandler"></param>
        public GameplayController(GameplayForm form, PlayerPaddle paddleModel, Control paddleView, Ball ballModel,
            Control ballView, TargetBlocksCollection targetBlocksCollection, IMessageHandler messageHandler)
        {
            this.form = form;
            this.paddleModel = paddleModel;
            this.paddleView = paddleView;
            this.ballModel = ballModel;
            this.ballView = ballView;
            this.targetBlocks = targetBlocksCollection;

            this.targetBlocks.BallSpeedToIncrease += ballModel.OnBallSpeedIncreased;
            this.targetBlocks.EndGame += messageHandler.OnEndGame;
            this.targetBlocks.EndGame += form.OnEndGame;
            this.ballModel.EndGame += messageHandler.OnEndGame;
            this.ballModel.EndGame += form.OnEndGame;

            BindModelsToViews();
        }

        private void BindModelsToViews()
        {
            paddleView.Location = new Point(paddleModel.X, paddleModel.Y);

            ballView.Location = new Point(ballModel.X, ballModel.Y);
        }

        /// <summary>
        /// Changes paddleModel coordinates according to mouse position and updates View
        /// </summary>
        public void MovePaddle()
        {
            this.paddleModel.MovePaddle(Cursor.Position.X);
            BindModelsToViews();
        }

        /// <summary>
        /// Intermediary method used to update all logic step-by-step
        /// </summary>
        public void UpdateObjects()
        {
            MovePaddle();
            MoveBall();
        }

        private void MoveBall()
        {
            this.ballModel.MoveBall(targetBlocks);
            this.ballModel.CheckForBlockCollision(paddleModel);

            for (int i = 0; i < targetBlocks.Count; i++)
            {
                TargetBlock targetBlock = (TargetBlock)targetBlocks[i];
                if (targetBlock != null && this.ballModel.CheckForBlockCollision(targetBlock))
                {
                    targetBlock.Destroy();
                }
            }
        }
    }
}
