using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Game
{
    public partial class Form1 : Form
    {
        int pipespeed = 8;
        int gravity = 15;
        int score = 0;
        bool gameOver = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipeBottom.Left -= pipespeed;
            pipeTop.Left -= pipespeed;
            scoreText.Text = "Score : "+ score;
      
            if(pipeBottom.Left < -150)
            {
                pipeBottom.Left = 500;
                score++;
            }
            if (pipeTop.Left < -170)
            {
                pipeTop.Left = 600;
                score++;
            }
            if(bird.Bounds.IntersectsWith(pipeBottom.Bounds) || bird.Bounds.IntersectsWith(pipeTop.Bounds) || bird.Bounds.IntersectsWith(ground.Bounds) || bird.Top < -25)
            {
                endGame();
            }
            if (score > 5)
            {
                pipespeed = 8 + ((score / 5) * 3);
            }
           
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
            if(e.KeyCode == Keys.R && gameOver)
            {
                RestartGame();
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
            if (e.KeyCode == Keys.R && gameOver)
            {
                RestartGame();
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += "  Game Over. Press R to Retry";
            gameOver = true;
        }
        private void RestartGame()
        {
            gameOver = false;

            bird.Location = new Point(12,162);

            pipeTop.Left = 600;
            pipeBottom.Left = 900;

            pipespeed = 8;
            score = 0;
            scoreText.Text = "Score : 0";
            gameTimer.Start();
        }
    }
}
