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
        private int ballSpeedX = 4;
        private int ballSpeedY = 4;
        private int ballSpeed = 4;
        private int points = 0;
        

        public GUI()
        {
            InitializeComponent();
            timer1.Enabled = true;
            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;        // remove border
            //this.TopMost = true;                              // bring form to front
            this.Bounds = Screen.PrimaryScreen.Bounds;          // make fullscreen

            paddle1.Top = panel.Bottom - (panel.Height / 2);    // set position of paddle1
            paddle1.Left = 30;                                  // set position of paddle1
            paddle2.Top = panel.Bottom - (panel.Height / 2);    // set position of paddle2
            paddle2.Left = panel.Right - 50;                    // set position of paddle2
            ball.Top = panel.Bottom - (panel.Height / 2);       // set position of ball
            ball.Left = (panel.Right / 2);                       // set position of ball

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

            if (ball.Bottom >= paddle1.Top &&
                ball.Bottom <= paddle1.Bottom && 
                ball.Left >= paddle1.Left && 
                ball.Right <= paddle1.Right)
            {
                ballSpeedY += 2;
                ballSpeedX += 2;
                ballSpeed = -ballSpeed; // change dir
                points++;
            }

            // wall collision
            if(ball.Top >= panel.Top)
            {
                ballSpeedY = -ballSpeedY;
            }
            if (ball.Bottom >= panel.Bottom)
            {
                ballSpeedY = -ballSpeedY;
            }
            if (ball.Right >= panel.Right || ball.Left <= panel.Left)
            {
                timer1.Enabled = false;
            }
        }
    }
}
