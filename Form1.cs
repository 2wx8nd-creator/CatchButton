using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace CatchButton
{
    public partial class Form1 : Form
    {
        private Random random = new Random();

        private SoundPlayer missSound = new SoundPlayer("miss.wav");
        private SoundPlayer successSound = new SoundPlayer("success.wav");

        private int difficultyDelay = 100;
        private int missCount = 0;


        private Button btnNextLevel;
        private Button btnRestart;
        private TextBox txtStatus;

        public Form1()
        {
            InitializeComponent();
        }

        private async void runawayButton_MouseEnter(object sender, EventArgs e)
        {
            missCount++;
            if (missCount >= 10)
            {
                ShowGameOver("실패", Color.Red, false);
                return;
            }

            SystemSounds.Beep.Play();
            
            await Task.Delay(difficultyDelay);

            int maxX = this.ClientSize.Width - runawayButton.Width;
            int maxY = this.ClientSize.Height - runawayButton.Height;

            runawayButton.Location = new Point(random.Next(0, maxX), random.Next(0, maxY));
        }

        private void runawayButton_Click(object sender, EventArgs e)
        {
            SystemSounds.Asterisk.Play();
            ShowGameOver("성　공", Color.LightYellow, true);
        }

        private void ShowGameOver(string message, Color bgColor, bool isSuccess)
        {
            runawayButton.Visible = false;
            runawayButton.Enabled = false;
            this.BackColor = bgColor;

            txtStatus = new TextBox();
            txtStatus.Text = message;
            txtStatus.Width = 200;
            txtStatus.TextAlign = HorizontalAlignment.Center;
            txtStatus.ReadOnly = true;
            txtStatus.Location = new Point((this.ClientSize.Width - txtStatus.Width) / 2, (this.ClientSize.Height - txtStatus.Height) / 2 - 20);
            this.Controls.Add(txtStatus);

            if (isSuccess)
            {
                btnNextLevel = new Button();
                btnNextLevel.Text = "다음레벨 도전";
                btnNextLevel.Width = 120;
                btnNextLevel.Location = new Point((this.ClientSize.Width - btnNextLevel.Width) / 2, txtStatus.Bottom + 10);
                btnNextLevel.Click += BtnNextLevel_Click;
                this.Controls.Add(btnNextLevel);
            }
            else
            {
                btnRestart = new Button();
                btnRestart.Text = "처음부터 다시";
                btnRestart.Width = 120;
                btnRestart.Location = new Point((this.ClientSize.Width - btnRestart.Width) / 2, txtStatus.Bottom + 10);
                btnRestart.Click += BtnRestart_Click;
                this.Controls.Add(btnRestart);
            }
        }

        private void BtnNextLevel_Click(object sender, EventArgs e)
        {

            difficultyDelay = Math.Max(10, difficultyDelay - 20);
            ResetGameArea();
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            difficultyDelay = 100;
            ResetGameArea();
        }

        private void ResetGameArea()
        {
            missCount = 0;
            this.BackColor = SystemColors.Control;

            if (txtStatus != null) this.Controls.Remove(txtStatus);
            if (btnNextLevel != null) this.Controls.Remove(btnNextLevel);
            if (btnRestart != null) this.Controls.Remove(btnRestart);

            runawayButton.Visible = true;
            runawayButton.Enabled = true;
            runawayButton.Location = new Point(100, 100);
        }
    }
}