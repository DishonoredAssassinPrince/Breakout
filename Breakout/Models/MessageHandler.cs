namespace Breakout.Models
{
    using Breakout.AdditionalEntities;
    using Breakout.Models.Contracts;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Class which handles messages to be displayed in end game states.
    /// </summary>
    public class MessageHandler : IMessageHandler
    {
        private const string WinStatus = "WIN";
        private const string WinMessage = "All blocks destroyed";
        private const string LossStatus = "LOSS";
        private const string LossMessage = "Ball went out of bounds";
        private const string ScoreText = "Score: ";

        private Control statusView;
        private Control messageView;
        private Control scoreView;

        private string status;
        private string message;
        private int score;

        private event EventHandler StatusChanged;
        private event EventHandler MessageChanged;
        private event EventHandler ScoreChanged;

        /// <summary>
        /// Base constructor for MessageHandler class.
        /// </summary>
        /// <param name="statusView">View for game status.</param>
        /// <param name="messageView">View for displayed message.</param>
        public MessageHandler(Control statusView, Control messageView, Control scoreView)
        {
            this.statusView = statusView;
            this.messageView = messageView;
            this.scoreView = scoreView;

            this.StatusChanged += OnStatusChanged;
            this.MessageChanged += OnMessageChanged;
            this.ScoreChanged += OnScoreChanged;
        }

        private void OnStatusChanged(object sender, EventArgs e)
        {
            this.statusView.Text = status;
            this.statusView.Visible = true;
        }

        private void OnMessageChanged(object sender, EventArgs e)
        {
            this.messageView.Text = message;
            this.messageView.Visible = true;
        }

        private void OnScoreChanged(object sender, EventArgs e)
        {
            this.scoreView.Text = ScoreText + score;
            this.scoreView.Visible = true;
        }

        /// <summary>
        /// Defines end game state.
        /// </summary>
        public string Status
        {
            get
            {
                return this.status;
            }
            private set
            {
                this.status = value;
                this.StatusChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Defines end game message.
        /// </summary>
        public string Message
        {
            get
            {
                return this.message;
            }
            private set
            {
                this.message = value;
                this.MessageChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Defines end game score.
        /// </summary>
        public int Score
        {
            get
            {
                return this.score;
            }
            private set
            {
                this.score = value;
                this.ScoreChanged(this, new EventArgs());
            }
        }


        /// <summary>
        /// Changes end game status and triggers events.
        /// </summary>
        public void OnEndGame(object sender, EndGameArgs endGameArgs)
        {
            bool status = endGameArgs.Status;
            int score = endGameArgs.Score;

            //true -> win
            //false -> loss
            if (status)
            {
                this.Status = WinStatus;
                this.Message = WinMessage;
            }
            else
            {
                this.Status = LossStatus;
                this.Message = LossMessage;
            }

            this.Score = score;
        }
    }
}
