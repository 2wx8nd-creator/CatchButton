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

        public Form1()
        {
            InitializeComponent();
        }

        private async　void runawayButton_MouseEnter(object sender, EventArgs e)
        {
            SystemSounds.Beep.Play(); ;
            await Task.Delay(100);

            int maxX = this.ClientSize.Width - runawayButton.Width;
            int maxY = this.ClientSize.Height - runawayButton.Height;


            int nextX = random.Next(0, maxX);
            int nextY = random.Next(0, maxY);

            runawayButton.Location = new Point(nextX, nextY);

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

    }
}
