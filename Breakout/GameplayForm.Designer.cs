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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBall)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPaddle
            // 
            this.pictureBoxPaddle.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxPaddle.Location = new System.Drawing.Point(1000, 736);
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
            // GameplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1664, 1012);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.pictureBoxBall);
            this.Controls.Add(this.pictureBoxPaddle);
            this.Name = "GameplayForm";
            this.Text = "GameplayForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameplayForm_FormClosed);
            this.Load += new System.EventHandler(this.GameplayForm_Load);
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
    }
}