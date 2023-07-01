using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Square_eater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<PictureBox> items = new List<PictureBox>();
        Random rand = new Random();

        int speed = 8, x, y, w = 12, a = 12, counts;
        int spawnTime = 20;
        bool moveUp, moveDown, moveRight, moveLeft, GameEnd = true;

        Color[] newColor = { Color.DarkBlue, Color.LimeGreen, Color.Red, Color.Gold };
        public void MakePictureBox()
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Height = 20;
            pictureBox.Width = 20;
            pictureBox.BackColor = newColor[rand.Next(0, newColor.Length)];

            x = rand.Next(5, this.ClientSize.Width - pictureBox.Width);
            y = rand.Next(5, this.ClientSize.Height - pictureBox.Height);

            pictureBox.Location = new Point(x, y);
            items.Add(pictureBox);
            this.Controls.Add(pictureBox);
        }
        private void keyIsDown(object sender, KeyEventArgs e)
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
        private void keyIsUp(object sender, KeyEventArgs e)
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
            if (e.KeyCode == Keys.Enter && GameEnd == false)
            {
                ResetGame();
            }
        }
        private void timerEvent_Tick(object sender, EventArgs e)
        {
            if (moveUp == true && player.Top > 2)
            {
                player.Top -= speed;
            }
            if (moveDown == true && player.Top < this.ClientSize.Height - w)
            {
                player.Top += speed;
            }
            if (moveRight == true && player.Left < this.ClientSize.Width - a)
            {
                player.Left += speed;
            }
            if (moveLeft == true && player.Left > 2)
            {
                player.Left -= speed;
            }
            spawnTime -= 2;
            if (spawnTime < 2)
            {
                if (items.Count() != 30)
                {
                    MakePictureBox();
                    spawnTime = 20;
                }
                if (counts == 190 && GameEnd == true)//xia vor 5 em grum restart linuma anel bayc 190 i vaxt chi grum,linuma 5i vaxtel chi grum
                {
                    IsGameEnd();
                }
                if (counts == 35)
                {
                    speed = 7;
                }
                if (counts == 50)
                {
                    speed = 6;
                }
                if (counts == 140)
                {
                    speed = 5;
                }
                if (counts == 180)
                {
                    speed = 4;
                }
            }
            foreach (PictureBox item in items.ToList())
            {
                if (player.Bounds.IntersectsWith(item.Bounds))
                {
                    counts++;
                    label1.Text = "Counts:" + counts.ToString();
                    player.BackColor = item.BackColor;
                    items.Remove(item);
                    this.Controls.Remove(item);
                    player.Width += 2;
                    player.Height += 2;
                    w += 2;
                    a += 2;
                }
            }
        }
        private void IsGameEnd()
        {
            GameEnd = false;
            label1.Text += " " + " Game Ended " + Environment.NewLine + "Press Enter to try again:";
            timerEvent.Stop();
        }
        private void ResetGame()
        {
            player.Width = 10;
            player.Height = 10;
            foreach (PictureBox item in items.ToList())
            {
                items.Remove(item);
                this.Controls.Remove(item);
            }
            timerEvent.Start();
            if (GameEnd == false)
            {
                counts = 0;
            }
            label1.Text = "Counts:" + counts;
            GameEnd = true;
        }
    }
}
