using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Callition_and_Relaction__WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool moveLeft, moveRight, moveUp, moveDown;
        int speed = 8;
        private void mainTimerEvent(object sender, EventArgs e)
        {
            if (moveLeft == true && player.Left > 0)
            {
                player.Left -= speed;
            }
            if (moveRight == true && player.Right < 620)
            {
                player.Left += speed;
            }
            if (moveUp == true && player.Top > 4)
            {
                player.Top -= speed;
            }
            if (moveDown == true && player.Top < 419)
            {
                player.Top += speed;
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "object")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        x.BackColor = Color.Red;
                        label1.Text = "You hit with " + x.Name;
                    }
                    else
                    {
                        x.BackColor = Color.DarkBlue;
                    }
                }
            }
        }
        private void keyisDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = true;
            }
        }
        private void keyisUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = false;
            }
        }
    }
}
