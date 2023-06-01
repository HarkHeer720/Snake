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
        List<Rectangle> player2Body = new List<Rectangle>();

        //creating rectangles
        Rectangle playerHead = new Rectangle(40, 40, 20, 20);
        Rectangle apple = new Rectangle(100, 100, 20, 20);

        //declaring variables
        string gameState = "start";
        Random randGen = new Random();
        int randValue;
        int player1Score = 0;
        int player2Score = 0;
        int playerSpeed = 20;
        int lastDirection = 0; // 1 = up, 2 = left, 3 = down, 4 = right
        int lastDirection2 = 0; // 1 = up, 2 = left, 3 = down, 4 = right
        int playerTailX;
        int playerTailY;
        int appleY;
        int appleX;

        //creating key presses
        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;
        bool upDown = false;
        bool leftDown = false;
        bool downDown = false;
        bool rightDown = false;

        //creating brushes
        Pen magentaPen = new Pen(Color.Magenta, 40);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush limeGreenBrush = new SolidBrush(Color.LimeGreen);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        public Form1()
        {
            InitializeComponent();
        }
        public void gameInitializer1Player()
        {
            playerBody.Clear();
            player1Score = 0;

            Rectangle square = new Rectangle(40, 40, 20, 20);
            playerBody.Add(square);

            wDown = false;
            aDown = false;
            sDown = false;
            dDown = false;

            gameState = "1Player";
            gameTimer.Enabled = true;
        }

        public void gameInitializer2Player()
        {
            playerBody.Clear();
            player2Body.Clear();

            player1Score = 0;
            player2Score = 0;

            Rectangle square = new Rectangle(40, 40, 20, 20);
            playerBody.Add(square);

            Rectangle square2 = new Rectangle(40, 40, 20, 20);
            player2Body.Add(square2);

            wDown = false;
            aDown = false;
            sDown = false;
            dDown = false;
            upDown = false;
            leftDown = false;
            downDown = false;
            rightDown = false;

            gameState = "2Player";
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
                case Keys.Up:
                    if (lastDirection2 == 3)
                    {

                    }
                    else
                    {
                        upDown = true;
                        leftDown = false;
                        downDown = false;
                        rightDown = false;
                    }
                    break;
                case Keys.Left:
                    if (lastDirection2 == 4)
                    {

                    }
                    else
                    {
                        upDown = false;
                        leftDown = true;
                        downDown = false;
                        rightDown = false;
                    }
                    break;
                case Keys.Down:
                    if (lastDirection2 == 1)
                    {

                    }
                    else
                    {
                        upDown = false;
                        leftDown = false;
                        downDown = true;
                        rightDown = false;
                    }
                    break;
                case Keys.Right:
                    if (lastDirection2 == 2)
                    {

                    }
                    else
                    {
                        upDown = false;
                        leftDown = false;
                        downDown = false;
                        rightDown = true;
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "start" || gameState == "wonPlayer1" || gameState == "lostPlayer1")
                    {

                    }
                    else if (gameState == "1Player" || gameState == "2Player")
                    {

                    }
                    Application.Exit();
                    break;
                case Keys.Space:
                    if (gameState == "start" || gameState == "won" || gameState == "lost")
                    {
                        gameInitializer1Player();
                    }
                    else if (gameState == "1Player" || gameState == "2Player")
                    {

                    }
                    break;
                case Keys.G:
                    if (gameState == "start" || gameState == "wonPlayer1" || gameState == "lostPlayer1")
                    {
                        gameInitializer2Player();
                    }
                    else if (gameState == "playing" || gameState == "2Player")
                    {

                    }
                    break;
                case Keys.C:
                    if (gameTimer.Enabled == true)
                    {
                        gameTimer.Enabled = false;
                    }
                    else if (gameTimer.Enabled == false)
                    {
                        gameTimer.Enabled = true;
                    }
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (gameState == "1Player")
            {
                //check if a player has collided with an apple and giving them a point
                for (int i = 0; i < 20; i++)
                {
                    if (playerBody[0].IntersectsWith(apple))
                    {
                        if (i > 1)
                        {
                            i = 0;
                        }
                        randValue = randGen.Next(1, 581);
                        if (randValue % 20 == 0)
                        {
                            if (i > 1)
                            {
                                i = 0;
                            }
                            appleX = randValue;
                            randValue = randGen.Next(1, 381);
                            if (randValue % 20 == 0)
                            {
                                appleY = randValue;
                                for (int j = 0; j < playerBody.Count; j++)
                                {
                                    if (appleX == playerBody[j].X && appleY == playerBody[j].Y)
                                    {
                                        appleX = 0;
                                        appleY = 0;
                                    }
                                }
                                player1Score++;
                                apple = new Rectangle(appleX, appleY, 20, 20);
                                if (lastDirection == 1)
                                {
                                    //making a temporary variable to store 
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

                //move the player if they change their direction of movement
                if (wDown == true && lastDirection != 3)
                {
                    //create new body part for head at 0
                    int Y = playerBody[0].Y - playerSpeed;
                    Rectangle player = new Rectangle(playerBody[0].X, Y, 20, 20);
                    playerBody.Insert(0, player);
                    if (playerBody.Count > 1)
                    {
                        playerBody.RemoveAt(playerBody.Count - 1);
                    }

                    lastDirection = 1;
                }
                if (aDown == true && lastDirection != 4)
                {
                    //create new body part for head at 0
                    int X = playerBody[0].X - playerSpeed;
                    Rectangle player = new Rectangle(X, playerBody[0].Y, 20, 20);
                    playerBody.Insert(0, player);
                    if (playerBody.Count > 1)
                    {
                        playerBody.RemoveAt(playerBody.Count - 1);
                    }

                    lastDirection = 2;
                }
                if (sDown == true && lastDirection != 1)
                {
                    //create new body part for head at 0
                    int Y = playerBody[0].Y + playerSpeed;
                    Rectangle player = new Rectangle(playerBody[0].X, Y, 20, 20);
                    playerBody.Insert(0, player);
                    if (playerBody.Count > 1)
                    {
                        playerBody.RemoveAt(playerBody.Count - 1);
                    }

                    lastDirection = 3;
                }
                if (dDown == true && lastDirection != 2)
                {
                    //create new body part for head at 0
                    int X = playerBody[0].X + playerSpeed;
                    Rectangle player = new Rectangle(X, playerBody[0].Y, 20, 20);
                    playerBody.Insert(0, player);
                    if (playerBody.Count > 1)
                    {
                        playerBody.RemoveAt(playerBody.Count - 1);
                    }
                    lastDirection = 4;
                }

                //checking if the player has collided with a wall
                if (playerBody[0].Y < 0)
                {
                    gameState = "lost1Player";
                }
                else if (playerBody[0].X < 0)
                {
                    gameState = "lost1Player";
                }
                else if (playerBody[0].X > this.Width - playerHead.Width)
                {
                    gameState = "lost1Player";
                }
                else if (playerBody[0].Y > this.Height - playerHead.Height)
                {
                    gameState = "lost1Player";
                }

                //checking if the player colided with the body of the snake
                for (int i = 0; i < playerBody.Count; i++)
                {
                    if (playerBody[0].IntersectsWith(playerBody[i]) && i > 1)
                    {
                        gameState = "lost1Player";
                    }
                }

                //checking if the player won
                if (player1Score == 599)
                {
                    gameState = "won1Player";
                }
            }

            else if (gameState == "2Player")
            {
                // player 1 code
                //check if a player has collided with an apple and giving them a point
                for (int i = 0; i < 20; i++)
                {
                    if (playerBody[0].IntersectsWith(apple))
                    {
                        if (i > 1)
                        {
                            i = 0;
                        }
                        randValue = randGen.Next(1, 581);
                        if (randValue % 20 == 0)
                        {
                            if (i > 1)
                            {
                                i = 0;
                            }
                            appleX = randValue;
                            randValue = randGen.Next(1, 381);
                            if (randValue % 20 == 0)
                            {
                                appleY = randValue;
                                for (int j = 0; j < playerBody.Count; j++)
                                {
                                    if (appleX == playerBody[j].X && appleY == playerBody[j].Y)
                                    {
                                        appleX = 0;
                                        appleY = 0;
                                    }
                                }
                                for (int j = 0; j < player2Body.Count; j++)
                                {
                                    if (appleX == player2Body[j].X && appleY == player2Body[j].Y)
                                    {
                                        appleX = 0;
                                        appleY = 0;
                                    }
                                }
                                player1Score++;
                                apple = new Rectangle(appleX, appleY, 20, 20);
                                if (lastDirection == 1)
                                {
                                    //making a temporary variable to store 
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

                //move the player if they change their direction of movement
                if (wDown == true && lastDirection != 3)
                {
                    //create new body part for head at 0
                    int Y = playerBody[0].Y - playerSpeed;
                    Rectangle player = new Rectangle(playerBody[0].X, Y, 20, 20);
                    playerBody.Insert(0, player);
                    if (playerBody.Count > 1)
                    {
                        playerBody.RemoveAt(playerBody.Count - 1);
                    }

                    lastDirection = 1;
                }
                if (aDown == true && lastDirection != 4)
                {
                    //create new body part for head at 0
                    int X = playerBody[0].X - playerSpeed;
                    Rectangle player = new Rectangle(X, playerBody[0].Y, 20, 20);
                    playerBody.Insert(0, player);
                    if (playerBody.Count > 1)
                    {
                        playerBody.RemoveAt(playerBody.Count - 1);
                    }

                    lastDirection = 2;
                }
                if (sDown == true && lastDirection != 1)
                {
                    //create new body part for head at 0
                    int Y = playerBody[0].Y + playerSpeed;
                    Rectangle player = new Rectangle(playerBody[0].X, Y, 20, 20);
                    playerBody.Insert(0, player);
                    if (playerBody.Count > 1)
                    {
                        playerBody.RemoveAt(playerBody.Count - 1);
                    }

                    lastDirection = 3;
                }
                if (dDown == true && lastDirection != 2)
                {
                    //create new body part for head at 0
                    int X = playerBody[0].X + playerSpeed;
                    Rectangle player = new Rectangle(X, playerBody[0].Y, 20, 20);
                    playerBody.Insert(0, player);
                    if (playerBody.Count > 1)
                    {
                        playerBody.RemoveAt(playerBody.Count - 1);
                    }
                    lastDirection = 4;
                }

                //checking if the player has collided with a wall
                if (playerBody[0].Y < 0)
                {
                    gameState = "lost1Player";
                }
                else if (playerBody[0].X < 0)
                {
                    gameState = "lost1Player";
                }
                else if (playerBody[0].X > this.Width - playerHead.Width)
                {
                    gameState = "lost1Player";
                }
                else if (playerBody[0].Y > this.Height - playerHead.Height)
                {
                    gameState = "lost1Player";
                }

                //checking if the player colided with the body of the snake
                for (int i = 0; i < playerBody.Count; i++)
                {
                    if (playerBody[0].IntersectsWith(playerBody[i]) && i > 1)
                    {
                        gameState = "lost1Player";
                    }
                }

                //checking if player 1 won

                /*
                //player 2 code
                //check if a player has collided with an apple and giving them a point
                for (int i = 0; i < 20; i++)
                {
                    if (player2Body[0].IntersectsWith(apple))
                    {
                        if (i > 1)
                        {
                            i = 0;
                        }
                        randValue = randGen.Next(1, 581);
                        if (randValue % 20 == 0)
                        {
                            if (i > 1)
                            {
                                i = 0;
                            }
                            appleX = randValue;
                            randValue = randGen.Next(1, 381);
                            if (randValue % 20 == 0)
                            {
                                appleY = randValue;
                                for (int j = 0; j < playerBody.Count; j++)
                                {
                                    if (appleX == playerBody[j].X && appleY == playerBody[j].Y)
                                    {
                                        appleX = 0;
                                        appleY = 0;
                                    }
                                }

                                for (int j = 0; j < player2Body.Count; j++)
                                {
                                    if (appleX == player2Body[j].X && appleY == player2Body[j].Y)
                                    {
                                        appleX = 0;
                                        appleY = 0;
                                    }
                                }
                                player1Score++;
                                apple = new Rectangle(appleX, appleY, 20, 20);
                                if (lastDirection == 1)
                                {
                                    Rectangle playerTail = new Rectangle(0, 0, 20, 20);
                                    playerBody.Add(playerTail);
                                    i = 0;
                                }
                                else if (lastDirection == 2)
                                {
                                    Rectangle playerTail = new Rectangle(0, 0, 20, 20);
                                    playerBody.Add(playerTail);
                                    i = 0;
                                }
                                else if (lastDirection == 3)
                                {
                                    Rectangle playerTail = new Rectangle(0, 0, 20, 20);
                                    playerBody.Add(playerTail);
                                    i = 0;
                                }
                                else if (lastDirection == 4)
                                {
                                    Rectangle playerTail = new Rectangle(0, 0, 20, 20);
                                    playerBody.Add(playerTail);
                                    i = 0;
                                }
                            }
                        }
                    }
                }

                //move the player if they change their direction of movement
                if (wDown == true && lastDirection != 3)
                {
                    //create new body part for head at 0
                    int Y = playerBody[0].Y - playerSpeed;
                    Rectangle player = new Rectangle(playerBody[0].X, Y, 20, 20);
                    playerBody.Insert(0, player);
                    if (playerBody.Count > 1)
                    {
                        playerBody.RemoveAt(playerBody.Count - 1);
                    }

                    lastDirection = 1;
                }
                if (aDown == true && lastDirection != 4)
                {
                    //create new body part for head at 0
                    int X = playerBody[0].X - playerSpeed;
                    Rectangle player = new Rectangle(X, playerBody[0].Y, 20, 20);
                    playerBody.Insert(0, player);
                    if (playerBody.Count > 1)
                    {
                        playerBody.RemoveAt(playerBody.Count - 1);
                    }

                    lastDirection = 2;
                }
                if (sDown == true && lastDirection != 1)
                {
                    //create new body part for head at 0
                    int Y = playerBody[0].Y + playerSpeed;
                    Rectangle player = new Rectangle(playerBody[0].X, Y, 20, 20);
                    playerBody.Insert(0, player);
                    if (playerBody.Count > 1)
                    {
                        playerBody.RemoveAt(playerBody.Count - 1);
                    }

                    lastDirection = 3;
                }
                if (dDown == true && lastDirection != 2)
                {
                    //create new body part for head at 0
                    int X = playerBody[0].X + playerSpeed;
                    Rectangle player = new Rectangle(X, playerBody[0].Y, 20, 20);
                    playerBody.Insert(0, player);
                    if (playerBody.Count > 1)
                    {
                        playerBody.RemoveAt(playerBody.Count - 1);
                    }
                    lastDirection = 4;
                }

                //checking if the player has collided with a wall
                if (playerBody[0].Y < 0)
                {
                    gameState = "lost1Player";
                }
                else if (playerBody[0].X < 0)
                {
                    gameState = "lost1Player";
                }
                else if (playerBody[0].X > this.Width - playerHead.Width)
                {
                    gameState = "lost1Player";
                }
                else if (playerBody[0].Y > this.Height - playerHead.Height)
                {
                    gameState = "lost1Player";
                }

                //checking if the player colided with the body of the snake
                for (int i = 0; i < playerBody.Count; i++)
                {
                    if (playerBody[0].IntersectsWith(playerBody[i]) && i > 1)
                    {
                        gameState = "lost1Player";
                    }
                }

                //checking if the player won
                if (player1Score == 599)
                {
                    gameState = "won1Player";
                }
                */
            }
            Refresh();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //displaying different things on the screen depending on the game state
            if (gameState == "start")
            {

            }
            else if (gameState == "1Player")
            {
                titleLabel.Text = "";
                subtitleLabel.Text = "";
                scoreLabel.Text = $"{player1Score}";
                scoreLabel2.Text = "";

                e.Graphics.FillRectangle(redBrush, apple);
                for (int i = 0; i < playerBody.Count; i++)
                {
                    if (i == 0)
                    {
                        e.Graphics.FillRectangle(greenBrush, playerBody[i]);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(limeGreenBrush, playerBody[i]);
                    }
                }
            }
            else if (gameState == "2Player")
            {
                titleLabel.Text = "";
                subtitleLabel.Text = "";
                scoreLabel.Text = $"{player1Score}";
                scoreLabel2.Text = $"{player2Score}";

                e.Graphics.FillRectangle(redBrush, apple);

                // draw player 1
                for (int i = 0; i < playerBody.Count; i++)
                {
                    if (i == 0)
                    {
                        e.Graphics.FillRectangle(greenBrush, playerBody[i]);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(limeGreenBrush, playerBody[i]);
                    }
                }

                // draw player 2
                for (int i = 0; i < player2Body.Count; i++)
                {
                    if (i == 0)
                    {
                        e.Graphics.FillRectangle(greenBrush, player2Body[i]);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(limeGreenBrush, player2Body[i]);
                    }
                }
            }
            else if (gameState == "won1Player")
            {
                titleLabel.Text = "Snake";
                subtitleLabel.Text = "You won! \nPress space to play or press escape to exit";
            }
            else if (gameState == "lost1Player")
            {
                titleLabel.Text = "Snake";
                subtitleLabel.Text = $"You lost! You got a score of {player1Score} \nPress space to play or press escape to exit";
            }
            else if (gameState == "player1Win")
            {

            }
            else if (gameState == "player2Win")
            {

            }
        }
    }
}