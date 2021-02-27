
namespace Kapitel3
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed§34; otherwise, false.</param>
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
            this.components = new System.ComponentModel.Container();
            this.paddle2 = new System.Windows.Forms.PictureBox();
            this.ball = new System.Windows.Forms.PictureBox();
            this.paddle1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel = new System.Windows.Forms.Panel();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.GameOverLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.paddle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddle1)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // paddle2
            // 
            this.paddle2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.paddle2.Location = new System.Drawing.Point(1252, 166);
            this.paddle2.Name = "paddle2";
            this.paddle2.Size = new System.Drawing.Size(24, 195);
            this.paddle2.TabIndex = 0;
            this.paddle2.TabStop = false;
            this.paddle2.Click += new System.EventHandler(this.paddle2_Click);
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Red;
            this.ball.Location = new System.Drawing.Point(633, 245);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(42, 42);
            this.ball.TabIndex = 1;
            this.ball.TabStop = false;
            // 
            // paddle1
            // 
            this.paddle1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.paddle1.Location = new System.Drawing.Point(43, 166);
            this.paddle1.Name = "paddle1";
            this.paddle1.Size = new System.Drawing.Size(24, 195);
            this.paddle1.TabIndex = 2;
            this.paddle1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.GameOverLabel);
            this.panel.Controls.Add(this.ScoreLabel);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1324, 589);
            this.panel.TabIndex = 3;
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.Location = new System.Drawing.Point(563, 27);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(182, 59);
            this.ScoreLabel.TabIndex = 0;
            this.ScoreLabel.Text = "Score: 0";
            this.ScoreLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // GameOverLabel
            // 
            this.GameOverLabel.AutoSize = true;
            this.GameOverLabel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.GameOverLabel.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameOverLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GameOverLabel.Location = new System.Drawing.Point(462, 107);
            this.GameOverLabel.Name = "GameOverLabel";
            this.GameOverLabel.Size = new System.Drawing.Size(382, 312);
            this.GameOverLabel.TabIndex = 1;
            this.GameOverLabel.Text = "Game Over!\r\n\r\nEsc  -  Quit\r\nF1    -  Restart";
            this.GameOverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GUI
            // 
            this.AccessibleDescription = "gui";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 589);
            this.Controls.Add(this.paddle1);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.paddle2);
            this.Controls.Add(this.panel);
            this.Name = "GUI";
            this.Text = "Pong";
            ((System.ComponentModel.ISupportInitialize)(this.paddle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddle1)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox paddle2;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.PictureBox paddle1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label GameOverLabel;
    }
}

