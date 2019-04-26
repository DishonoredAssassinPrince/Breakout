namespace Breakout
{
    partial class GameplayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameplayForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBoxPaddle = new System.Windows.Forms.PictureBox();
            this.pictureBoxBall = new System.Windows.Forms.PictureBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelPause = new System.Windows.Forms.Label();
            this.buttonExitMenu = new System.Windows.Forms.Button();
            this.buttonExitDesktop = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBall)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPaddle
            // 
            this.pictureBoxPaddle.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxPaddle.Location = new System.Drawing.Point(988, 831);
            this.pictureBoxPaddle.Name = "pictureBoxPaddle";
            this.pictureBoxPaddle.Size = new System.Drawing.Size(300, 50);
            this.pictureBoxPaddle.TabIndex = 0;
            this.pictureBoxPaddle.TabStop = false;
            // 
            // pictureBoxBall
            // 
            this.pictureBoxBall.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBall.Image = global::Breakout.Properties.Resources.Ball;
            this.pictureBoxBall.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxBall.InitialImage")));
            this.pictureBoxBall.Location = new System.Drawing.Point(1014, 615);
            this.pictureBoxBall.Name = "pictureBoxBall";
            this.pictureBoxBall.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxBall.TabIndex = 1;
            this.pictureBoxBall.TabStop = false;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labelMessage.ForeColor = System.Drawing.Color.Brown;
            this.labelMessage.Location = new System.Drawing.Point(750, 400);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(181, 31);
            this.labelMessage.TabIndex = 2;
            this.labelMessage.Text = "labelMessage";
            this.labelMessage.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.labelStatus.ForeColor = System.Drawing.Color.Brown;
            this.labelStatus.Location = new System.Drawing.Point(737, 342);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(217, 46);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "labelStatus";
            this.labelStatus.Visible = false;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labelScore.ForeColor = System.Drawing.Color.Brown;
            this.labelScore.Location = new System.Drawing.Point(750, 474);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(142, 31);
            this.labelScore.TabIndex = 4;
            this.labelScore.Text = "labelScore";
            this.labelScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelScore.Visible = false;
            // 
            // labelPause
            // 
            this.labelPause.AutoSize = true;
            this.labelPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.labelPause.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelPause.Location = new System.Drawing.Point(777, 601);
            this.labelPause.Name = "labelPause";
            this.labelPause.Size = new System.Drawing.Size(115, 39);
            this.labelPause.TabIndex = 5;
            this.labelPause.Text = "Pause";
            this.labelPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPause.Visible = false;
            // 
            // buttonExitMenu
            // 
            this.buttonExitMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExitMenu.Location = new System.Drawing.Point(200, 736);
            this.buttonExitMenu.Name = "buttonExitMenu";
            this.buttonExitMenu.Size = new System.Drawing.Size(150, 50);
            this.buttonExitMenu.TabIndex = 6;
            this.buttonExitMenu.Text = "Exit To Menu";
            this.buttonExitMenu.UseVisualStyleBackColor = true;
            this.buttonExitMenu.Visible = false;
            this.buttonExitMenu.Click += new System.EventHandler(this.buttonExitMenu_Click);
            // 
            // buttonExitDesktop
            // 
            this.buttonExitDesktop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExitDesktop.Location = new System.Drawing.Point(1314, 736);
            this.buttonExitDesktop.Name = "buttonExitDesktop";
            this.buttonExitDesktop.Size = new System.Drawing.Size(150, 50);
            this.buttonExitDesktop.TabIndex = 7;
            this.buttonExitDesktop.Text = "Exit";
            this.buttonExitDesktop.UseVisualStyleBackColor = true;
            this.buttonExitDesktop.Visible = false;
            this.buttonExitDesktop.Click += new System.EventHandler(this.buttonExitDesktop_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRestart.Location = new System.Drawing.Point(756, 736);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(150, 50);
            this.buttonRestart.TabIndex = 8;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Visible = false;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // GameplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1664, 1012);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.buttonExitDesktop);
            this.Controls.Add(this.buttonExitMenu);
            this.Controls.Add(this.labelPause);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.pictureBoxBall);
            this.Controls.Add(this.pictureBoxPaddle);
            this.KeyPreview = true;
            this.Name = "GameplayForm";
            this.Text = "GameplayForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameplayForm_FormClosed);
            this.Load += new System.EventHandler(this.GameplayForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameplayForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBoxPaddle;
        private System.Windows.Forms.PictureBox pictureBoxBall;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelPause;
        private System.Windows.Forms.Button buttonExitMenu;
        private System.Windows.Forms.Button buttonExitDesktop;
        private System.Windows.Forms.Button buttonRestart;
    }
}