using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

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
        int appleY;
        int appleX;
        int playerX;
        int playerY;
        int player2X;
        int player2Y;

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
            player1Score = 1;

            appleX = 0;
            appleY = 0;
            playerX = 0;
            playerY = 0;
            lastDirection = 0;

            wDown = false;
            aDown = false;
            sDown = false;
            dDown = false;

            for (int i = 0; i < 10000; i++)
            {
                randValue = randGen.Next(1, 581);
                if (randValue % 20 == 0)
                {
                    playerX = randValue;
                    randValue = randGen.Next(1, 381);
                    if (randValue % 20 == 0)
                    {
                        playerY = randValue;
                        Rectangle square = new Rectangle(playerX, playerY, 20, 20);
                        playerBody.Add(square);
                        i = 10000;
                    }
                }
            }

            for (int i = 0; i < 10000; i++)
            {
                randValue = randGen.Next(1, 581);
                if (randValue % 20 == 0)
                {
                    appleX = randValue;
                    randValue = randGen.Next(1, 381);
                    if (randValue % 20 == 0)
                    {
                        if (appleX == playerX && appleY == playerY)
                        {
                            appleX = 0;
                            appleY = 0;
                            i = 0;
                        }
                        appleY = randValue;
                        apple = new Rectangle(appleX, appleY, 20, 20);
                        i = 10000;
                    }
                }
            }

            gameState = "1Player";
            gameTimer.Enabled = true;
        }

        public void gameInitializer2Player()
        {
            playerBody.Clear();
            player2Body.Clear();

            player1Score = 1;
            player2Score = 1;

            appleX = 0;
            appleY = 0;
            playerX = 0;
            playerY = 0;
            player2X = 0;
            player2Y = 0;
            lastDirection = 0;
            lastDirection2 = 0;

            wDown = false;
            aDown = false;
            sDown = false;
            dDown = false;
            upDown = false;
            leftDown = false;
            downDown = false;
            rightDown = false;

            for (int i = 0; i < 10000; i++)
            {
                if (i == 9999)
                {
                    i = 0;
                }
                randValue = randGen.Next(1, 581);
                if (randValue % 20 == 0)
                {
                    if (i == 9999)
                    {
                        i = 0;
                    }
                    playerX = randValue;
                    randValue = randGen.Next(1, 381);
                    if (randValue % 20 == 0)
                    {
                        playerY = randValue;
                        Rectangle square = new Rectangle(playerX, playerY, 20, 20);
                        playerBody.Add(square);
                        i = 10000;
                    }
                }
            }

            for (int i = 0; i < 10000; i++)
            {
                if (i > 9999)
                {
                    i = 0;
                }
                randValue = randGen.Next(1, 581);
                if (randValue % 20 == 0)
                {
                    if (i > 9999)
                    {
                        i = 0;
                    }
                    appleX = randValue;
                    randValue = randGen.Next(1, 381);
                    if (randValue % 20 == 0)
                    {
                        if (appleX == playerX && appleY == playerY || appleX == player2X && appleY == player2Y)
                        {
                            appleX = 0;
                            appleY = 0;
                            i = 0;
                        }
                        else
                        {
                            appleY = randValue;
                            apple = new Rectangle(appleX, appleY, 20, 20);
                            i = 10000;
                        }
                    }
                }
            }

            for (int i = 0; i < 10000; i++)
            {
                if (i > 9999)
                {
                    i = 0;
                }
                randValue = randGen.Next(1, 581);
                if (randValue % 20 == 0)
                {
                    if (i > 9999)
                    {
                        i = 0;
                    }
                    player2X = randValue;
                    randValue = randGen.Next(1, 381);
                    if (randValue % 20 == 0)
                    {
                        player2Y = randValue;
                        if (player2X == playerX && playerX == playerY)
                        {
                            player2X = 0;
                            player2Y = 0;
                        }
                        else
                        {
                            Rectangle square = new Rectangle(player2X, player2Y, 20, 20);
                            player2Body.Add(square);
                            i = 10000;
                        }
                    }
                }
            }

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
                    if (gameState == "start" || gameState == "won1Player" || gameState == "lost1Player" || gameState == "draw" || gameState == "player1Win" || gameState == "player2Win")
                    {

                    }
                    else if (gameState == "1Player" || gameState == "2Player")
                    {

                    }
                    Application.Exit();
                    break;
                case Keys.Space:
                    if (gameState == "start" || gameState == "won1Player" || gameState == "lost1Player" || gameState == "draw" || gameState == "player1Win" || gameState == "player2Win")
                    {
                        gameInitializer1Player();
                    }
                    else if (gameState == "1Player" || gameState == "2Player")
                    {

                    }
                    break;
                case Keys.G:
                    if (gameState == "start" || gameState == "won1Player" || gameState == "lost1Player" || gameState == "draw" || gameState == "player1Win" || gameState == "player2Win")
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
                                        i = 0;
                                    }
                                }
                                apple = new Rectangle(appleX, appleY, 20, 20);
                                player1Score++;
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
                if (player1Score == 600)
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
                    gameState = "player2Win";
                }
                else if (playerBody[0].X < 0)
                {
                    gameState = "player2Win";
                }
                else if (playerBody[0].X > this.Width - playerHead.Width)
                {
                    gameState = "player2Win";
                }
                else if (playerBody[0].Y > this.Height - playerHead.Height)
                {
                    gameState = "player2Win";
                }

                //checking if the player colided with the body of the snake
                for (int i = 0; i < playerBody.Count; i++)
                {
                    if (playerBody[0].IntersectsWith(playerBody[i]) && i > 1)
                    {
                        gameState = "player2Win";
                    }
                }
                for (int i = 0; i < player2Body.Count; i++)
                {
                    if (playerBody[0].IntersectsWith(player2Body[i]) && i > 1)
                    {
                        gameState = "player2Win";
                    }
                    else if (playerBody[0].IntersectsWith(player2Body[0]))
                    {
                        if (player1Score > player2Score)
                        {
                            gameState = "player1Win";
                        }
                        else if (player2Score > player1Score)
                        {
                            gameState = "player2Win";
                        }
                        else
                        {
                            gameState = "draw";
                        }
                    }
                }

                //player 2 code
                //check if a player has collided with an apple and giving them a point
                for (int i = 0; i < 20; i++)
                {
                    if (player2Body[0].IntersectsWith(apple))
                    {
                        if (i > 2)
                        {
                            i = 0;
                        }
                        randValue = randGen.Next(1, 581);
                        if (randValue % 20 == 0)
                        {
                            if (i > 2)
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
                                        i = 0;
                                    }
                                }

                                for (int j = 0; j < player2Body.Count; j++)
                                {
                                    if (appleX == player2Body[j].X && appleY == player2Body[j].Y)
                                    {
                                        appleX = 0;
                                        appleY = 0;
                                        i = 0;
                                    }
                                }
                                player2Score++;
                                apple = new Rectangle(appleX, appleY, 20, 20);
                                if (lastDirection2 == 1)
                                {
                                    Rectangle playerTail = new Rectangle(0, 0, 20, 20);
                                    player2Body.Add(playerTail);
                                    i = 0;
                                }
                                else if (lastDirection2 == 2)
                                {
                                    Rectangle playerTail = new Rectangle(0, 0, 20, 20);
                                    player2Body.Add(playerTail);
                                    i = 0;
                                }
                                else if (lastDirection2 == 3)
                                {
                                    Rectangle playerTail = new Rectangle(0, 0, 20, 20);
                                    player2Body.Add(playerTail);
                                    i = 0;
                                }
                                else if (lastDirection2 == 4)
                                {
                                    Rectangle playerTail = new Rectangle(0, 0, 20, 20);
                                    player2Body.Add(playerTail);
                                    i = 0;
                                }
                            }
                        }
                    }
                }

                //move the player if they change their direction of movement
                if (upDown == true && lastDirection2 != 3)
                {
                    //create new body part for head at 0
                    int Y = player2Body[0].Y - playerSpeed;
                    Rectangle player = new Rectangle(player2Body[0].X, Y, 20, 20);
                    player2Body.Insert(0, player);
                    if (player2Body.Count > 1)
                    {
                        player2Body.RemoveAt(player2Body.Count - 1);
                    }

                    lastDirection2 = 1;
                }
                if (leftDown == true && lastDirection2 != 4)
                {
                    //create new body part for head at 0
                    int X = player2Body[0].X - playerSpeed;
                    Rectangle player = new Rectangle(X, player2Body[0].Y, 20, 20);
                    player2Body.Insert(0, player);
                    if (player2Body.Count > 1)
                    {
                        player2Body.RemoveAt(player2Body.Count - 1);
                    }

                    lastDirection2 = 2;
                }
                if (downDown == true && lastDirection2 != 1)
                {
                    //create new body part for head at 0
                    int Y = player2Body[0].Y + playerSpeed;
                    Rectangle player = new Rectangle(player2Body[0].X, Y, 20, 20);
                    player2Body.Insert(0, player);
                    if (player2Body.Count > 1)
                    {
                        player2Body.RemoveAt(player2Body.Count - 1);
                    }

                    lastDirection2 = 3;
                }
                if (rightDown == true && lastDirection2 != 2)
                {
                    //create new body part for head at 0
                    int X = player2Body[0].X + playerSpeed;
                    Rectangle player = new Rectangle(X, player2Body[0].Y, 20, 20);
                    player2Body.Insert(0, player);
                    if (player2Body.Count > 1)
                    {
                        player2Body.RemoveAt(player2Body.Count - 1);
                    }
                    lastDirection2 = 4;
                }

                //checking if the player has collided with a wall
                if (player2Body[0].Y < 0)
                {
                    gameState = "player1Win";
                }
                else if (player2Body[0].X < 0)
                {
                    gameState = "player1Win";
                }
                else if (player2Body[0].X > this.Width - playerHead.Width)
                {
                    gameState = "player1Win";
                }
                else if (player2Body[0].Y > this.Height - playerHead.Height)
                {
                    gameState = "player1Win";
                }

                //checking if the player colided with the body of the snake
                for (int i = 0; i < player2Body.Count; i++)
                {
                    if (player2Body[0].IntersectsWith(player2Body[i]) && i > 1)
                    {
                        gameState = "player1Win";
                    }
                    else if (player2Body[0].IntersectsWith(playerBody[0]))
                    {
                        if (player1Score > player2Score)
                        {
                            gameState = "player1Win";
                        }
                        else if (player2Score > player1Score)
                        {
                            gameState = "player2Win";
                        }
                        else
                        {
                            gameState = "draw";
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
                titleLabel.Text = "Snake";
                subtitleLabel.Text = "Press space to play single player, press G to play 2 player or press escape to exit";
                scoreLabel.Text = "";
                scoreLabel2.Text = "";
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
                subtitleLabel.Text = "You won!\nPress space to play single player, press G to play 2 player or press escape to exit";
                scoreLabel.Text = "";
                scoreLabel2.Text = "";
            }
            else if (gameState == "lost1Player")
            {
                titleLabel.Text = "Snake";
                subtitleLabel.Text = $"You lost! You got a score of {player1Score}\nPress space to play single player, press G to play 2 player or press escape to exit";
                scoreLabel.Text = "";
                scoreLabel2.Text = "";
            }
            else if (gameState == "player1Win")
            {
                titleLabel.Text = "Snake";
                subtitleLabel.Text = $"Player 1 wins with a score of {player1Score}\nPress space to play single player, press G to play 2 player or press escape to exit";
                scoreLabel.Text = "";
                scoreLabel2.Text = "";
            }
            else if (gameState == "player2Win")
            {
                titleLabel.Text = "Snake";
                subtitleLabel.Text = $"Player 2 wins with a score of {player2Score}\nPress space to play single player, press G to play 2 player or press escape to exit";
                scoreLabel.Text = "";
                scoreLabel2.Text = "";
            }
            else if (gameState == "draw")
            {
                titleLabel.Text = "Snake";
                subtitleLabel.Text = $"Game was a draw :/\nPress space to play single player, press G to play 2 player or press escape to exit";
                scoreLabel.Text = "";
                scoreLabel2.Text = "";
            }
        }
    }
}