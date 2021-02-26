using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitel3
{
    public partial class GUI : Form
    {
        private readonly int PADDLE_SCREEN_OFFSET = 30;
        private int ballSpeedX = 10;
        private int ballSpeedY = 10;
        //private int ballSpeed = 4;
        private int points = 0;
        

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

        }

        private void GUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                Console.WriteLine("closing");
            }
            if (e.KeyCode == Keys.F1)
            {
                //reset
            }
            if (e.KeyCode == Keys.Down)
            {
                // down
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            paddle1.Top = Cursor.Position.Y - (paddle1.Height / 2);     // set center of paddle to position of cursor
            ball.Left += ballSpeedX;
            ball.Top += ballSpeedY;

            // TODO: fix utkukning while corner collision
            if (Intersects(ball, paddle1) || Intersects(ball, paddle2))
                ballSpeedX *= -1;

            // wall collision
            if (IntersectsWallHorizontally(ball, panel))
                ballSpeedY *= -1;
            if (IntersectsWallVertically(ball, panel))
                ballSpeedX *= -1;
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
    }
}
