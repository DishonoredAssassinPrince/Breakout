namespace Breakout
{
    using Breakout.AdditionalEntities;
    using Breakout.Controllers;
    using Breakout.Controllers.Contracts;
    using Breakout.Models;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class GameplayForm : Form
    {
        private IGameplayController gameplayController;
        private bool loopIsRunning;

        public GameplayForm()
        {
            InitializeComponent();
        }

        private void GameplayForm_Load(object sender, EventArgs e)
        {
            PlayerPaddle paddleModel = new PlayerPaddle(this.Width, this.Height, this.Width, this.Height);
            int ballX = this.Width / 2 - 15;
            int ballY = this.Height / 2 + 50;
            Ball ballModel = new Ball(ballX, ballY, this.Width, this.Height);
            pictureBoxPaddle.Size = new Size(paddleModel.Width, paddleModel.Height);
            pictureBoxBall.Size = new Size(ballModel.Width, ballModel.Height);

            TargetBlocksCollection targetBlocksCollection = GenerateTargetBlocks();

            SetMessageLocations();
            MessageHandler messageHandler = new MessageHandler(this.labelStatus, this.labelMessage, this.labelScore);

            this.gameplayController = new GameplayController(this, paddleModel, pictureBoxPaddle, ballModel, 
                this.pictureBoxBall, targetBlocksCollection, messageHandler);

            Application.Idle += RunLoop;
            loopIsRunning = true;
        }

        private void SetMessageLocations()
        {
            int statusX = this.Width / 2 - 100;
            int statusY = this.Height / 2 - 200;
            int messageX = this.Width / 2 - 180;
            int messageY = this.Height / 2 - 100;
            this.labelStatus.Location = new Point(statusX, statusY);
            this.labelMessage.Location = new Point(messageX, messageY);
        }

        private TargetBlocksCollection GenerateTargetBlocks()
        {
            IList<Control> targetBlockViews = new List<Control>();
            TargetBlocksCollection targetBlocks = new TargetBlocksCollection(targetBlockViews);

            //Horizontal blocks -> 10
            //Vertical blocks -> Half of screen height, 6
            int countOfBlocksHorizontal = 10;
            int countOfBlocksVertical = 6;

            int BlockWidth = this.Width / countOfBlocksHorizontal;
            int BlockHeight = (this.Height / 2) / countOfBlocksVertical;

            int y = 0;
            for (int vertical = 0; vertical < countOfBlocksVertical; vertical++)
            {
                int x = 0;
                for (int horizontal = 0; horizontal < countOfBlocksHorizontal; horizontal++)
                {
                    int width = 0;
                    int height = 0;

                    Button currentTargetBlockView = new Button();
                    currentTargetBlockView.FlatStyle = FlatStyle.Flat;
                    currentTargetBlockView.FlatAppearance.BorderColor = Color.CornflowerBlue;
                    currentTargetBlockView.FlatAppearance.BorderSize = 3;
                    currentTargetBlockView.BackColor = Color.DarkGreen;
                    currentTargetBlockView.FlatAppearance.MouseOverBackColor = Color.DarkGreen;
                    currentTargetBlockView.FlatAppearance.MouseDownBackColor = Color.DarkGreen;
                    currentTargetBlockView.Location = new Point(x, y);


                    if (horizontal == countOfBlocksHorizontal - 1)
                    {
                        width = this.Width - x;
                    }
                    else
                    {
                        width = BlockWidth;
                    }

                    if(vertical == countOfBlocksVertical - 1)
                    {
                        height = (this.Height / 2) - y;
                    }
                    else
                    {
                        height = BlockHeight;
                    }

                    currentTargetBlockView.Size = new Size(width, height);
                    TargetBlock targetBlock = new TargetBlock(x, y, width, height, this.Width, this.Height,
                        targetBlocks);

                    this.Controls.Add(currentTargetBlockView);
                    targetBlockViews.Add(currentTargetBlockView);
                    targetBlocks.Add(targetBlock);

                    x += BlockWidth;
                }
                y += BlockHeight;
            }

            return targetBlocks;
        }

        public void OnEndGame(object sender, EventArgs e)
        {
            Application.Idle -= RunLoop;
            loopIsRunning = true;
        }

        public void RunLoop(object sender, EventArgs e)
        {
            NativeMethods.Message message;

            while (!NativeMethods.PeekMessage(out message, IntPtr.Zero, 0, 0, 0))
            {
                HandleInput(sender, e);
            }
        }

        Stopwatch stopWatch = Stopwatch.StartNew();

        readonly TimeSpan TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 60);
        readonly TimeSpan MaxElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 10);

        TimeSpan accumulatedTime;
        TimeSpan lastTime;


        private void HandleInput(object sender, EventArgs e)
        {
            TimeSpan currentTime = stopWatch.Elapsed;
            TimeSpan elapsedTime = currentTime - lastTime;
            lastTime = currentTime;

            if (elapsedTime > MaxElapsedTime)
            {
                elapsedTime = MaxElapsedTime;
            }

            accumulatedTime += elapsedTime;

            bool updated = false;

            while (accumulatedTime >= TargetElapsedTime)
            {
                this.gameplayController.UpdateObjects();
                this.Update();

                accumulatedTime -= TargetElapsedTime;
                updated = true;
            }

            if (updated)
            {
                this.Invalidate();
            }
        }

        //Ends process when form is closed.
        private void GameplayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void GameplayForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                if (loopIsRunning)
                {
                    Application.Idle -= RunLoop;
                    loopIsRunning = false;

                    this.buttonExitDesktop.Visible = true;
                    this.buttonRestart.Visible = true;
                    this.buttonExitMenu.Visible = true;
                    this.labelPause.Visible = true;
                }
                else
                {
                    this.labelPause.Visible = false;
                    this.buttonRestart.Visible = false;
                    this.buttonExitMenu.Visible = false;
                    this.buttonExitDesktop.Visible = false;

                    loopIsRunning = true;
                    Application.Idle += RunLoop;
                }
            }
        }

        private void buttonExitMenu_Click(object sender, EventArgs e)
        {
            Application.Idle -= RunLoop;
            loopIsRunning = false;
            this.Hide();
            StartGameForm startGameForm = new StartGameForm();
            startGameForm.Show();
        }

        private void buttonExitDesktop_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameplayForm startGameForm = new GameplayForm();
            startGameForm.Show();
        }
    }
}
