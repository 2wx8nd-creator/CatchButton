using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;


namespace CatchButton
{
    public partial class Form1 : Form
    {

        private SoundPlayer missSound = new SoundPlayer("miss.wav");
        private SoundPlayer successSound = new SoundPlayer("success.wav");

        private Random random = new Random();

        private int missCount = 0;
        private Button btnRestart;
        private TextBox txtStatus;

        public Form1()
        {
            InitializeComponent();
        }

        private async　void runawayButton_MouseEnter(object sender, EventArgs e)
        {
            missCount++;
            if (missCount >= 10)
            {
                ShowGameOver("실패", Color.Red);
                return;
            }

            SystemSounds.Beep.Play(); ;
            await Task.Delay(100);

            int maxX = this.ClientSize.Width - runawayButton.Width;
            int maxY = this.ClientSize.Height - runawayButton.Height;


            int nextX = random.Next(0, maxX);
            int nextY = random.Next(0, maxY);

            runawayButton.Location = new Point(nextX, nextY);

        }

        private void ShowGameOver(string message, Color bgColor)
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


            btnRestart = new Button();
            btnRestart.Text = "재도전";
            btnRestart.Width = 100;
            btnRestart.Location = new Point((this.ClientSize.Width - btnRestart.Width) / 2, txtStatus.Bottom + 10);
            btnRestart.Click += BtnRestart_Click;
            this.Controls.Add(btnRestart);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void runawayButton_Click(object sender, EventArgs e)
        {

            SystemSounds.Asterisk.Play();

            runawayButton.Visible = false;
            this.BackColor = Color.LightYellow;

            TextBox txtSuccess = new TextBox();
            txtSuccess.Text = "성　공";
            txtSuccess.Width = 200;
            txtSuccess.TextAlign = HorizontalAlignment.Center;
            txtSuccess.ReadOnly = true;

            txtSuccess.Location = new Point(
                (this.ClientSize.Width - txtSuccess.Width) / 2,
                (this.ClientSize.Height - txtSuccess.Height) / 2
            );

            this.Controls.Add(txtSuccess);
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            missCount = 0;
            this.BackColor = SystemColors.Control;


            this.Controls.Remove(txtStatus);
            this.Controls.Remove(btnRestart);


            runawayButton.Visible = true;
            runawayButton.Enabled = true;
            runawayButton.Location = new Point(100, 100);
        }
    }
}
