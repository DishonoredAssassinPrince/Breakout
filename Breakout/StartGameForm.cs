namespace Breakout
{
    using System;
    using System.Threading;
    using System.Windows.Forms;

    public partial class StartGameForm : Form
    {
        public StartGameForm()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            GameplayForm gameplayForm = new GameplayForm();
            gameplayForm.Show();
            this.Hide();
        }

        private void StartGameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
