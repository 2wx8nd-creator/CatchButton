namespace CatchButton
{
    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;

  
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void InitializeComponent()
        {
            runawayButton = new Button();
            SuspendLayout();

            runawayButton.Location = new Point(283, 83);
            runawayButton.Name = "runawayButton";
            runawayButton.Size = new Size(252, 164);
            runawayButton.TabIndex = 0;
            runawayButton.Text = "클릭해보셈ㅋㅋ";
            runawayButton.UseVisualStyleBackColor = true;
            runawayButton.Click += runawayButton_Click;
            runawayButton.MouseEnter += runawayButton_MouseEnter;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(runawayButton);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button runawayButton;
    }
}
