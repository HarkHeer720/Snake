using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        //creating lists
        List<Rectangle> playerBody = new List<Rectangle>();
        List<Rectangle> grid = new List<Rectangle>();

        //creating rectangles
        Rectangle playerHead = new Rectangle(40, 40, 20, 20);
        Rectangle apple = new Rectangle(200, 200, 20, 20);

        //declaring variables
        string gameState = "start";
        Random randGen = new Random();
        int randValue;
        int playerScore = 0;
        int playerSpeed = 20;
        int lastDirection = 0; // 1 = up, 2 = left, 3 = down, 4 = right
        int playerTailX;
        int playerTailY;
        int playerHeadX;
        int playerHeadY;
        int currentDirection = 1;
        int lastSquareX;
        int lastSquareY;
        int currentSquareX;
        int currentSquareY;

        //creating key presses
        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;

        //creating brushes
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush limeGreenBrush = new SolidBrush(Color.LimeGreen);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        public Form1()
        {
            InitializeComponent();
        }
        public void gameInitializer()
        {
            playerBody.Clear();
            playerScore = 0;

            Rectangle square = new Rectangle(40, 40, 20, 20);
            playerBody.Add(square);

            wDown = false;
            aDown = false;
            sDown = false;
            dDown = false;
            lastDirection = 0;

            gameState = "playing";
            gameTimer.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (lastDirection == 3)
                    {

                    }
                    else
                    {
                        wDown = true;
                        aDown = false;
                        sDown = false;
                        dDown = false;
                    }
                    break;
                case Keys.A:
                    if (lastDirection == 4)
                    {

                    }
                    else
                    {
                        wDown = false;
                        aDown = true;
                        sDown = false;
                        dDown = false;
                    }
                    break;
                case Keys.S:
                    if (lastDirection == 1)
                    {

                    }
                    else
                    {
                        wDown = false;
                        aDown = false;
                        sDown = true;
                        dDown = false;
                    }
                    break;
                case Keys.D:
                    if (lastDirection == 2)
                    {

                    }
                    else
                    {
                        wDown = false;
                        aDown = false;
                        sDown = false;
                        dDown = true;
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "start" || gameState == "won" || gameState == "lost")
                    {

                    }
                    else if (gameState == "playing")
                    {

                    }
                    Application.Exit();
                    break;
                case Keys.Space:
                    if (gameState == "start" || gameState == "won" || gameState == "lost")
                    {
                        gameInitializer();
                    }
                    else if (gameState == "playing")
                    {

                    }
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            playerTailX = playerHead.X;
            playerTailY = playerHead.Y;
            //move the player if they change their direction of movement
            if (wDown == true && lastDirection != 3)
            {
                for (int i = 0; i < playerBody.Count; i++)
                {
                    int X = playerBody[i].X - playerSpeed;
                    Rectangle player = new Rectangle(X, playerBody[i].Y, 20, 20);
                    playerBody.Insert(0, player);
                }
                lastDirection = 1;

                //if (currentDirection == lastDirection)
                //{

                //}
                //else if (currentDirection != lastDirection)
                //{
                //    playerHeadX = playerHead.X;
                //    playerHeadY = playerHead.Y;
                //}

                //for (int i = 0; i < playerBody.Count; i++)
                //{
                //    if (lastSquareX == 0)
                //    {
                //        lastSquareX = playerHead.X;
                //    }
                //    if (lastSquareY == 0)
                //    {
                //        lastSquareY = playerHead.Y;
                //    }
                //    currentSquareX = playerBody[i].X;
                //    currentSquareY = playerBody[i].Y;
                //    playerBody[i] = new Rectangle(lastSquareX, lastSquareY, 20, 20);
                //    lastSquareX = currentSquareX;
                //    lastSquareY = currentSquareY;
                //}
                /*
                if (lastDirection == 0)
                {

                }
                else if (lastDirection > 0 && currentDirection != lastDirection)
                {
                    turnPointX = playerHead.X;
                    turnPointY = playerHead.Y;
                }


                for (int i = 0; i < playerBody.Count; i++)
                {
                    if (playerBody[i].X == turnPointX && playerBody[i].Y == turnPointY)
                    {
                        int Y = playerBody[i].Y - playerSpeed;
                        playerBody[i] = new Rectangle(playerBody[i].X, Y, 20, 20);
                    }
                    if (playerBody[i].Y != turnPointY && lastDirection == 2)
                    {
                        int X = playerBody[i].X - playerSpeed;
                        playerBody[i] = new Rectangle(X, playerBody[i].Y, 20, 20);
                    }
                    if (playerBody[i].Y != turnPointY && lastDirection == 4)
                    {
                        int X = playerBody[i].X + playerSpeed;
                        playerBody[i] = new Rectangle(X, playerBody[i].Y, 20, 20);
                    }
                }
                */
            }
            if (aDown == true && lastDirection != 4)
            {
                for (int i = 0; i < playerBody.Count; i++)
                {
                    int Y = playerBody[i].X - playerSpeed;
                    Rectangle player = new Rectangle(playerBody[0].X, Y, 20, 20);
                    playerBody.Insert(0, player);
                }

                //currentDirection = 2;
                //if (currentDirection == lastDirection)
                //{

                //}
                //else if (currentDirection != lastDirection)
                //{
                //    playerHeadX = playerHead.X;
                //    playerHeadY = playerHead.Y;
                //}
                //playerHead.X -= playerSpeed;

                //for (int i = 0; i < playerBody.Count; i++)
                //{
                //    if (lastSquareX == 0)
                //    {
                //        lastSquareX = playerHead.X;
                //    }
                //    if (lastSquareY == 0)
                //    {
                //        lastSquareY = playerHead.Y;
                //    }
                //    currentSquareX = playerBody[i].X;
                //    currentSquareY = playerBody[i].Y;
                //    playerBody[i] = new Rectangle(lastSquareX, lastSquareY, 20, 20);
                //    lastSquareX = currentSquareX;
                //    lastSquareY = currentSquareY;
                //}
                /*
                currentDirection = 2;
                if (lastDirection == 0)
                {

                }
                else if (lastDirection > 0 && currentDirection != lastDirection)
                {
                    turnPointX = playerHead.X;
                    turnPointY = playerHead.Y;
                }

                for (int i = 0; i < playerBody.Count; i++)
                {
                    if (playerBody[i].X == turnPointX && playerBody[i].Y == turnPointY)
                    {
                        int X = playerBody[i].X - playerSpeed;
                        playerBody[i] = new Rectangle(X, playerBody[i].Y, 20, 20);
                    }
                    if (playerBody[i].X != turnPointX && lastDirection == 1)
                    {
                        int Y = playerBody[i].Y - playerSpeed;
                        playerBody[i] = new Rectangle(playerBody[i].X, Y, 20, 20);
                    }
                    if (playerBody[i].X != turnPointX && lastDirection == 3)
                    {
                        int Y = playerBody[i].Y + playerSpeed;
                        playerBody[i] = new Rectangle(playerBody[i].X, Y, 20, 20);
                    }
                }
                playerHead.X -= playerSpeed;
                */
                lastDirection = 2;
            }
            if (sDown == true && lastDirection != 1)
            {
                //do this for all movement directions
                int Y = playerBody[0].Y + playerSpeed;
                Rectangle player = new Rectangle(playerBody[0].X, Y, 20, 20);
                playerBody.Insert(0, player);
                if (playerBody.Count > 1)
                {
                    playerBody.RemoveAt(playerBody.Count - 1);
                }

                //currentDirection = 3;
                //if (lastDirection == currentDirection)
                //{

                //}
                //else if (lastDirection != currentDirection)
                //{
                //    playerHeadX = playerHead.X;
                //    playerHeadY = playerHead.Y;
                //}
                //playerHead.Y += playerSpeed;

                //for (int i = 0; i < playerBody.Count; i++)
                //{
                //    if (lastSquareX == 0)
                //    {
                //        lastSquareX = playerHead.X;
                //    }
                //    if (lastSquareY == 0)
                //    {
                //        lastSquareY = playerHead.Y;
                //    }
                //    currentSquareX = playerBody[i].X;
                //    currentSquareY = playerBody[i].Y;
                //    playerBody[i] = new Rectangle(lastSquareX, lastSquareY, 20, 20);
                //    lastSquareX = currentSquareX;
                //    lastSquareY = currentSquareY;
                //}
                /*
                currentDirection = 3;
                if (lastDirection == 0)
                {

                }
                else if (lastDirection > 0 && currentDirection != lastDirection)
                {
                    turnPointX = playerHead.X;
                    turnPointY = playerHead.Y;
                }

                for (int i = 0; i < playerBody.Count; i++)
                {
                    if (playerBody[i].X == turnPointX && playerBody[i].Y == turnPointY)
                    {
                        int Y = playerBody[i].Y + playerSpeed;
                        playerBody[i] = new Rectangle(playerBody[i].X, Y, 20, 20);
                    }
                    if (playerBody[i].Y != turnPointY && lastDirection == 2)
                    {
                        int X = playerBody[i].X - playerSpeed;
                        playerBody[i] = new Rectangle(X, playerBody[i].Y, 20, 20);
                    }
                    if (playerBody[i].Y != turnPointY && lastDirection == 4)
                    {
                        int X = playerBody[i].X + playerSpeed;
                        playerBody[i] = new Rectangle(X, playerBody[i].Y, 20, 20);
                    }
                }
                playerHead.Y += playerSpeed;
                */
                lastDirection = 3;
            }
            if (dDown == true && lastDirection != 2)
            {
                //create new body part for head at 0
                for (int i = 0; i < playerBody.Count; i++)
                {
                    int X = playerBody[i].X + playerSpeed;
                    Rectangle player = new Rectangle(playerBody[i].X, Y, 20, 20);
                    playerBody.Insert(0, player);
                }

                //currentDirection = 4;
                //if (currentDirection == lastDirection)
                //{

                //}
                //else if (currentDirection != lastDirection)
                //{
                //    playerHeadX = playerHead.X;
                //    playerHeadY = playerHead.Y;
                //}
                //playerHead.X += playerSpeed;

                //for (int i = 0; i < playerBody.Count; i++)
                //{
                //    if (lastSquareX == 0)
                //    {
                //        lastSquareX = playerHead.X;
                //    }
                //    if (lastSquareY == 0)
                //    {
                //        lastSquareY = playerHead.Y;
                //    }
                //    currentSquareX = playerBody[i].X;
                //    currentSquareY = playerBody[i].Y;
                //    playerBody[i] = new Rectangle(lastSquareX, lastSquareY, 20, 20);
                //    lastSquareX = currentSquareX;
                //    lastSquareY = currentSquareY;
                //}
                /*
                currentDirection = 4;
                if (lastDirection == 0)
                {

                }
                else if (lastDirection > 0 && currentDirection != lastDirection)
                {
                    turnPointX = playerHead.X;
                    turnPointY = playerHead.Y;
                }

                for (int i = 0; i < playerBody.Count; i++)
                {
                    if (playerBody[i].X == turnPointX && playerBody[i].Y == turnPointY)
                    {
                        int X = playerBody[i].X + playerSpeed;
                        playerBody[i] = new Rectangle(X, playerBody[i].Y, 20, 20);
                    }
                    if (playerBody[i].X != turnPointX && lastDirection == 1)
                    {
                        int Y = playerBody[i].Y - playerSpeed;
                        playerBody[i] = new Rectangle(playerBody[i].X, Y, 20, 20);
                    }
                    if (playerBody[i].X != turnPointX && lastDirection == 3)
                    {
                        int Y = playerBody[i].Y + playerSpeed;
                        playerBody[i] = new Rectangle(playerBody[i].X, Y, 20, 20);
                    }
                }
                playerHead.X += playerSpeed;
                */
                lastDirection = 4;
            }

            //checking if the player has collided with a wall
            if (playerHead.Y < 0)
            {
                gameState = "lost";
            }
            else if (playerHead.X < 0)
            {
                gameState = "lost";
            }
            else if (playerHead.X > this.Width - playerHead.Width)
            {
                gameState = "lost";
            }
            else if (playerHead.Y > this.Height - playerHead.Height)
            {
                gameState = "lost";
            }

            //checking if the player colided with the body of the snake
            for (int i = 0; i < playerBody.Count; i++)
            {
                if (playerHead.IntersectsWith(playerBody[i]) && i > 1)
                {
                    gameState = "lost";
                }
            }

            //check if a player has collided with an apple and giving them a point
            for (int i = 0; i < 10000; i++)
            {
                if (playerHead.IntersectsWith(apple))
                {
                    randValue = randGen.Next(1, 601);
                    if (randValue % 20 == 0 /*&& randValue != playerBody[i].X*/)
                    {
                        int appleX = randValue;
                        randValue = randGen.Next(1, 401);
                        if (randValue % 20 == 0 /*&& randValue != playerBody[i].Y*/)
                        {
                            int appleY = randValue;
                            playerScore++;
                            apple = new Rectangle(appleX, appleY, 20, 20);
                            if (lastDirection == 1)
                            {
                                int playerBodyX = playerTailX;
                                int playerBodyY = playerTailY;
                                Rectangle playerTail = new Rectangle(playerBodyX, playerBodyY, 20, 20);
                                playerBody.Add(playerTail);
                                playerTailX = playerTail.X;
                                playerTailY = playerTail.Y;
                                i = 0;
                            }
                            else if (lastDirection == 2)
                            {
                                int playerBodyX = playerTailX;
                                int playerBodyY = playerTailY;
                                Rectangle playerTail = new Rectangle(playerBodyX, playerBodyY, 20, 20);
                                playerBody.Add(playerTail);
                                playerTailX = playerTail.X;
                                playerTailY = playerTail.Y;
                                i = 0;
                            }
                            else if (lastDirection == 3)
                            {
                                int playerBodyX = playerTailX;
                                int playerBodyY = playerTailY;
                                Rectangle playerTail = new Rectangle(playerBodyX, playerBodyY, 20, 20);
                                playerBody.Add(playerTail);
                                playerTailX = playerTail.X;
                                playerTailY = playerTail.Y;
                                i = 0;
                            }
                            else if (lastDirection == 4)
                            {
                                int playerBodyX = playerTailX;
                                int playerBodyY = playerTailY;
                                Rectangle playerTail = new Rectangle(playerBodyX, playerBodyY, 20, 20);
                                playerBody.Add(playerTail);
                                playerTailX = playerTail.X;
                                playerTailY = playerTail.Y;
                                i = 0;
                            }
                        }
                    }
                }
            }
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //displaying different things on the screen depending on the game state
            if (gameState == "start")
            {

            }
            else if (gameState == "playing")
            {
                titleLabel.Text = "";
                subtitleLabel.Text = "";
                scoreLabel.Text = $"{playerScore}";

                e.Graphics.FillRectangle(redBrush, apple);
                //e.Graphics.FillRectangle(greenBrush, playerHead);
                for (int i = 0; i < playerBody.Count; i++)
                {
                    e.Graphics.FillRectangle(limeGreenBrush, playerBody[i]);
                }
            }
            else if (gameState == "won")
            {
                titleLabel.Text = "Snake";
                subtitleLabel.Text = "You won! \nPress space to play or press escape to exit";
            }
            else if (gameState == "lost")
            {
                titleLabel.Text = "Snake";
                subtitleLabel.Text = $"You lost! You got a score of {playerScore} \nPress space to play or press escape to exit";
            }
        }
    }
}
