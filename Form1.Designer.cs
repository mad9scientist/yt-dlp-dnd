namespace yt_dlp_dnd
{
    partial class Form1
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        // private void InitializeComponent()
        // {
        //     this.SuspendLayout();
        //     // 
        //     // Form1
        //     // 
        //     this.ClientSize = new System.Drawing.Size(400, 120);
        //     this.Name = "Form1";
        //     this.Text = "Drop a YouTube URL Here";
        //     this.ResumeLayout(false);
        // }
        private System.Windows.Forms.Label emojiLabel;
        private System.Windows.Forms.Label instructionLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox outputTextBox;

        private void InitializeComponent()
        {

            this.emojiLabel = new System.Windows.Forms.Label();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // emojiLabel
            // 
            this.emojiLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.emojiLabel.Font = new System.Drawing.Font("Segoe UI Emoji", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.emojiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.emojiLabel.Text = "⬇️";
            this.emojiLabel.Height = 100;

            // 
            // instructionLabel
            // 
            this.instructionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.instructionLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.instructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.instructionLabel.Text = "Drop a Video URL here";
            this.instructionLabel.Height = 50;


            // this.outputTextBox = new System.Windows.Forms.TextBox();

            // // 
            // // outputTextBox
            // // 
            // this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            // this.outputTextBox.Multiline = true;
            // this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            // this.outputTextBox.ReadOnly = true;
            // this.outputTextBox.Font = new System.Drawing.Font("Consolas", 10F);
            // this.outputTextBox.BackColor = System.Drawing.Color.Black;
            // this.outputTextBox.ForeColor = System.Drawing.Color.Lime;

            // this.Controls.Add(this.outputTextBox);


            this.progressBar = new System.Windows.Forms.ProgressBar();

            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Height = 20;
            this.progressBar.Visible = false; // Start hidden

            // Add to controls (near bottom)
            this.Controls.Add(this.progressBar);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 180);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.emojiLabel);
            this.Name = "Form1";
            this.Text = "Video Downloader";
            this.ResumeLayout(false);
        }
    }
}