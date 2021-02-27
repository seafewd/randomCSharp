using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitel3
{
    public partial class GUI : Form
    {
        private readonly int PADDLE_SCREEN_OFFSET = 30;
        private double ballSpeedX = -10;
        private double ballSpeedY = 10;
        private int score = 0;
        private double speedMultiplier = 1.1f;
        private double maxSpeed = 40f;
        private int AIPaddlePos;


        public GUI()
        {
            InitializeComponent();
            timer1.Enabled = true;
            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;        // remove border
            //this.TopMost = true;                              // bring form to front
            this.Bounds = Screen.PrimaryScreen.Bounds;          // make fullscreen


            // init position of paddles and ball
            // paddle1.Top means distance from the top of the box to the top of container (the window). Basically the y-value of the box.
            paddle1.Top = panel.Height / 2 + paddle1.Height / 2;
            paddle1.Left = PADDLE_SCREEN_OFFSET;

            paddle2.Top = panel.Height / 2 - paddle1.Height / 2;
            paddle2.Left = panel.Right - PADDLE_SCREEN_OFFSET - paddle2.Width;  
            
            // set position of paddle2
            ball.Top = panel.Height / 2 + ball.Height / 2; 
            ball.Left = panel.Width / 2 + ball.Width / 2;

            // hide game over screen
            GameOverLabel.Visible = false;

            // position score label
            ScoreLabel.Left = (panel.Width / 2) - (ScoreLabel.Width / 2);
            ScoreLabel.Top = 50;

        }

        // handle key presses
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                Console.WriteLine("closing");
                return true;
            }
            if (keyData == Keys.F1)
            {
                ResetGame();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            paddle1.Top = Cursor.Position.Y - (paddle1.Height / 2);     // set center of paddle to position of cursor
            ball.Left += (int)ballSpeedX;
            ball.Top += (int)ballSpeedY;

            // move AI paddle
            UpdateAIPaddlePos(paddle2, ball);
            paddle2.Top = AIPaddlePos;

            // TODO: fix utkukning while corner collision
            if (Intersects(ball, paddle1) || Intersects(ball, paddle2)) {
                Console.WriteLine("intersected paddle");
                if (Math.Abs(ballSpeedX) < maxSpeed)
                    ballSpeedX *= -speedMultiplier;
                else
                    ballSpeedX *= -1;
            }
            // wall collision
            if (IntersectsWallHorizontally(ball, panel))
                ballSpeedY *= -1;
            if (IntersectsWallVertically(ball, panel))
                ShowGameOverScreen();

            UpdateScore();
        }

        /// <summary>
        /// Asynchronously update AI paddle position to artificially introduce difficulty/AI smartness... 
        /// </summary>
        /// <param name="paddle"></param>
        /// <param name="ball"></param>
        async void UpdateAIPaddlePos(PictureBox paddle, PictureBox ball)
        {
            int paddleMidPos = (paddle.Height / 2);
            Random rand = new Random();
            await Task.Run(() =>
            {
                Task.Delay(rand.Next(0, 100)).Wait();
                AIPaddlePos = ball.Top - paddleMidPos;
            });
        }

        /// <summary>
        /// Show game over screen
        /// </summary>
        void ShowGameOverScreen()
        {
            GameOverLabel.Left = (panel.Width / 2) - (GameOverLabel.Width / 2);
            GameOverLabel.Top = (panel.Height / 2) - (GameOverLabel.Height / 2);
            GameOverLabel.Visible = true;
        }

        void ResetGame()
        {
            ball.Top = (panel.Height / 2);
            ball.Left = (panel.Width / 2);
            ballSpeedY = 10;
            ballSpeedX = 10;
            ScoreLabel.Text = "Score: 0";
            timer1.Enabled = true;
            GameOverLabel.Visible = false;

        }

        /// <summary>
        /// Update score whenever the ball hits one of the paddles
        /// </summary>
        void UpdateScore()
        {
            if (Intersects(ball, paddle1) || Intersects(ball, paddle2))
            {
                score++;
                ScoreLabel.Text = "Points: " + score;
            }
        }


        // Returns true if there is an intersection between the given ball and paddle 
        // Using simple boolean algebra
        bool Intersects(PictureBox aBall, PictureBox aPaddle)
        {
            bool ballIsAbove = aBall.Bottom < aPaddle.Top;
            bool ballIsBelow = aBall.Top > aPaddle.Bottom;
            bool ballIsRightOf = aBall.Left > aPaddle.Right;
            bool ballIsLeftOf = aBall.Right < aPaddle.Left;

            // The logic:
            // If the ball is above or below or left of, etc,  its not intersecting the paddle.
            // If we take the negation of the above we know when IT DOES intersect
            return !(ballIsAbove || ballIsBelow || ballIsLeftOf || ballIsRightOf);
        }


        // Returns true if, say the distance from the top of the box is less than the top of the panel (windows in our case) 
        // Same idea with the rest
        bool IntersectsWallHorizontally(PictureBox box, Panel pan)
        {
            return box.Top <= pan.Top || box.Bottom >= pan.Bottom;
        }
        bool IntersectsWallVertically(PictureBox box, Panel pan)
        {
            return box.Right >= pan.Right || box.Left <= pan.Left;
        }

        private void paddle2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
