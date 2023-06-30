using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout_Game
{
    public partial class Form1 : Form
    {
        bool goLeft, goRight, gameOver;
        int score, ballx, bally, playerSpeed;
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            setupGame();
        }
        public void setupGame()
        {
            score =0;
            ballx = 20;
            bally = 20;
            playerSpeed = 40;
            scoreText.Text = "Score: " + score;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "blocks")
                {
                    x.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                }
            }
        }
        private void GameOver(string massege)
        {
            gameOver = true;
            gameTimer.Stop();
            scoreText.Text="Score: "+score+" " + massege;
        }
        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            scoreText.Text = "Score: " + score;
            if (goLeft == true && player.Left > 0) 
            {
                player.Left -= playerSpeed;
            }
            if (goRight == true && player.Left < 700) 
            {
                player.Left+= playerSpeed;
            }
            Ball.Left += ballx;
            Ball.Top += bally;
            if (Ball.Left < 0 || Ball.Left > 780)
            {
                ballx = -ballx;
            }
            if (Ball.Top < 0 )
            {
                bally = -bally;
            }
            if (Ball.Bounds.IntersectsWith(player.Bounds))
            {
                bally = rand.Next(5, 20) * -1;

                if (ballx<0)
                {
                    ballx = rand.Next(5, 20) * -1;
                }
                else
                {
                    ballx = rand.Next(5, 20);
                }
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "blocks")
                {
                    if (Ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        score += 1;
                        bally = -bally;
                        this.Controls.Remove(x);
                    }          
                }
            }
            if (score==35)
            {
                GameOver("You Win!!");
                setupGame();
            }
            if (Ball.Top>490)
            {
                GameOver("You Lose");
                RestartGame();
            }
        }
        private void RestartGame()
        {
            if (gameOver && MessageBox.Show("You are Loseing ", "Game Over", MessageBoxButtons.OK) == DialogResult.OK)
            {
                Close();
            }
        }
        private void keyIsDown(object sender, KeyEventArgs e)
        {
            gameTimer.Start();
            if (e.KeyCode==Keys.Left)
            {
                goLeft= true;
            }
            if (e.KeyCode==Keys.Right)
            {
                goRight=true;
            }
            //if (e.KeyCode == Keys.Enter && gameOver == true)
            //{
            //}
        }
        private void keyIsUp(object sender, KeyEventArgs e)
        {
            goLeft = false;
            goRight = false;
        }
    }
}


