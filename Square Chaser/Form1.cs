using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Square_Chaser
{
    public partial class Form1 : Form
    {
        Random randGen = new Random();

        Rectangle player1 = new Rectangle(10, 130, 20, 20);
        Rectangle player2 = new Rectangle(10, 200, 20, 20);
        Rectangle ball = new Rectangle(295, 195, 10, 10);
        Rectangle boarder = new Rectangle(25, 25, 450, 400);
        Rectangle point = new Rectangle(250, 160, 10, 10);

        int player1Score = 0;
        int player2Score = 0;
        int playerTurn = 1;

        int playerSpeed = 4;
        int ballXSpeed = 6;
        int ballYSpeed = -6;

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush pinkBrush = new SolidBrush(Color.Pink);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush violetBrush = new SolidBrush(Color.Violet);
        Pen whitePen = new Pen(Color.White);
        Pen bluePen = new Pen(Color.Blue, 10);
        Pen yellowPen = new Pen(Color.Yellow, 10);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    sDown = false;
                    aDown = false;
                    dDown = false;
                    break;
                case Keys.S:
                    sDown = true;
                    wDown = false;
                    aDown = false;
                    dDown = false;
                    break;
                case Keys.A:
                    aDown = true;
                    wDown = false;
                    sDown = false;
                    dDown = false;
                    break;
                case Keys.D:
                    dDown = true;
                    wDown = false;
                    aDown = false;
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    downArrowDown = false;
                    leftArrowDown = false;
                    rightArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    upArrowDown = false;
                    leftArrowDown = false;
                    rightArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    downArrowDown = false;
                    upArrowDown = false;
                    rightArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    downArrowDown = false;
                    leftArrowDown = false;
                    upArrowDown = false;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(bluePen, boarder);
            e.Graphics.FillRectangle(pinkBrush, player1);
            e.Graphics.FillRectangle(greenBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, point);
            e.Graphics.FillEllipse(violetBrush, 200, 170, 10, 10);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move player 1 
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }

            if (aDown == true && player1.X > 0)
            {
                player1.X -= playerSpeed;
            }
            if (dDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X += playerSpeed;
            }

            //move player 2 
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            if (leftArrowDown == true && player2.X > 0)
            {
                player2.X -= playerSpeed;
            }
            if (rightArrowDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += playerSpeed;
            }

            //player scores
            if(player1.IntersectsWith(point))
            {
                int x = randGen.Next(20, 150);
                int y = randGen.Next(50, 200);
                point.Location = (new Point (x, y));
                player1ScoreLabel.Visible = true;
                player1Score++;
                player1ScoreLabel.Text = $"{player1Score}";
            }

            else if (player2.IntersectsWith(point))
            {
                int x = randGen.Next(20, 150);
                int y = randGen.Next(50, 200);
                point.Location = (new Point(x, y));
                player2ScoreLabel.Visible = true;
                player2Score++;
                player2ScoreLabel.Text = $"{player2Score}";
            }

            Refresh();

            //if player reaches 5 points game ends
            if (player1Score == 5)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 1 Wins!!";
            }
            else if (player2Score == 5)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 2 Wins!!";
            }

            Refresh();
        }
    }
}
