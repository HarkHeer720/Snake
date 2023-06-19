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
using System.IO;

namespace Snake
{
    public partial class mainScreen : Form
    {
        //creating lists
        List<Rectangle> playerBody = new List<Rectangle>();
        List<Rectangle> player2Body = new List<Rectangle>();
        List<String> playerNames = new List<string>();
        List<String> playerScores = new List<string>();

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
        int frameCounter = 0;
        int frameCounter2 = 0;

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
        Pen purplePen = new Pen(Color.Magenta);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush limeGreenBrush = new SolidBrush(Color.LimeGreen);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        public mainScreen()
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
                        }
                        appleY = randValue;
                        apple = new Rectangle(appleX, appleY, 20, 20);
                        i = 10000;
                    }
                }
            }

            List<string> tempList = new List<string>();

            tempList = File.ReadAllLines("leaderboard.txt").ToList();

            for (int i = 0; i < tempList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    playerNames.Add(tempList[i]);
                }
                else if (i % 2 != 0)
                {
                    playerScores.Add(tempList[i]);
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
                    if (lastDirection != 3)
                    {
                        wDown = true;
                        aDown = false;
                        sDown = false;
                        dDown = false;
                    }
                    break;
                case Keys.A:
                    if (lastDirection != 4)
                    {
                        wDown = false;
                        aDown = true;
                        sDown = false;
                        dDown = false;
                    }
                    break;
                case Keys.S:
                    if (lastDirection != 1)
                    {
                        wDown = false;
                        aDown = false;
                        sDown = true;
                        dDown = false;
                    }
                    break;
                case Keys.D:
                    if (lastDirection != 2)
                    {
                        wDown = false;
                        aDown = false;
                        sDown = false;
                        dDown = true;
                    }
                    break;
                case Keys.Up:
                    if (lastDirection2 != 3)
                    {
                        upDown = true;
                        leftDown = false;
                        downDown = false;
                        rightDown = false;
                    }
                    break;
                case Keys.Left:
                    if (lastDirection2 != 4)
                    {
                        upDown = false;
                        leftDown = true;
                        downDown = false;
                        rightDown = false;
                    }
                    break;
                case Keys.Down:
                    if (lastDirection2 != 1)
                    {
                        upDown = false;
                        leftDown = false;
                        downDown = true;
                        rightDown = false;
                    }
                    break;
                case Keys.Right:
                    if (lastDirection2 != 2)
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

        private void leaderboardButton_Click(object sender, EventArgs e)
        {
            if (usernameInput.Text == "")
            {
                usernameInput.Text = "Please put a valid input";
            }
            else
            {
                gameState = "beforeLeaderboard";

                playerNames.Add(usernameInput.Text);
                playerScores.Add(Convert.ToString(player1Score));

                List<string> tempList = new List<string>();

                for (int i = 0; i < playerNames.Count; i++)
                {
                    tempList.Add(playerNames[i]);
                    tempList.Add(playerScores[i]);
                }

                File.WriteAllLines("leaderboard.txt", tempList);

                usernameInput.Clear();
            }
        }

        private void displayLeaderboard_Click(object sender, EventArgs e)
        {
            gameState = "leaderboard";
            List<string> tempList = new List<string>();

            for (int i = 0; i < playerScores.Count; i++)
            {
                int baller = Convert.ToInt32(playerScores[i]);
                for (int j = 0; j < playerScores.Count; j++)
                {
                    if (baller < Convert.ToInt32(playerScores[j]))
                    {
                        tempList.Insert(0, playerScores[j]);
                        tempList.Insert(0, playerNames[j]);
                        playerNames.RemoveAt(j);
                        playerScores.RemoveAt(j);
                    }
                }
            }

            for (int i = 0; i < tempList.Count;i++)
            {
                if (i == 0)
                {
                    leaderboardLabel.Text += $"1. {tempList[i]}";
                }
                else if (i == 1)
                {
                    leaderboardLabel.Text += $"  {tempList[i]}";
                }
                else if (i == 2)
                {
                    leaderboardLabel.Text += $"\n2. {tempList[i]}";
                }
                else if (i == 3)
                {
                    leaderboardLabel.Text += $"  {tempList[i]}";
                }
                else if (i == 4)
                {
                    leaderboardLabel.Text += $"\n3. {tempList[i]}";
                }
                else if (i == 5)
                {
                    leaderboardLabel.Text += $"  {tempList[i]}";
                }
                else if (i == 6)
                {
                    leaderboardLabel.Text += $"\n4. {tempList[i]}";
                }
                else if (i == 7)
                {
                    leaderboardLabel.Text += $"  {tempList[i]}";
                }
                else if (i == 8)
                {
                    leaderboardLabel.Text += $"\n5. {tempList[i]}";
                }
                else if (i == 9)
                {
                    leaderboardLabel.Text += $"  {tempList[i]}";
                }
                else if (i == 10)
                {
                    leaderboardLabel.Text += $"\n6. {tempList[i]}";
                }
                else if (i == 11)
                {
                    leaderboardLabel.Text += $"  {tempList[i]}";
                }
                else if (i == 12)
                {
                    leaderboardLabel.Text += $"\n7. {tempList[i]}";
                }
                else if (i == 13)
                {
                    leaderboardLabel.Text += $"  {tempList[i]}";
                }
                else if (i == 14)
                {
                    leaderboardLabel.Text += $"\n8. {tempList[i]}";
                }
                else if (i == 15)
                {
                    leaderboardLabel.Text += $"  {tempList[i]}";
                }
                else if (i == 16)
                {
                    leaderboardLabel.Text += $"\n9. {tempList[i]}";
                }
                else if (i == 17)
                {
                    leaderboardLabel.Text += $"  {tempList[i]}";
                }
                else if (i == 18)
                {
                    leaderboardLabel.Text += $"\n10. {tempList[i]}";
                }
                else if (i == 19)
                {
                    leaderboardLabel.Text += $"  {tempList[i]}";
                }
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (gameState == "1Player")
            {
                player1();
            }

            else if (gameState == "2Player")
            {
                // player 1 code
                player1();

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
                                    Rectangle playerTail = new Rectangle(-20, 0, 20, 20);
                                    player2Body.Add(playerTail);
                                    i = 0;
                                }
                                else if (lastDirection2 == 2)
                                {
                                    Rectangle playerTail = new Rectangle(-20, 0, 20, 20);
                                    player2Body.Add(playerTail);
                                    i = 0;
                                }
                                else if (lastDirection2 == 3)
                                {
                                    Rectangle playerTail = new Rectangle(-20, 0, 20, 20);
                                    player2Body.Add(playerTail);
                                    i = 0;
                                }
                                else if (lastDirection2 == 4)
                                {
                                    Rectangle playerTail = new Rectangle(-20, 0, 20, 20);
                                    player2Body.Add(playerTail);
                                    i = 0;
                                }
                            }
                        }
                    }
                }

                if (frameCounter2 % 5 == 0)
                {
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
                }

                //checking if the player has collided with a wall
                if (player2Body[0].Y < 0)
                {
                    gameState = "player1Win";
                    gameTimer.Enabled = false;
                }
                else if (player2Body[0].X < 0)
                {
                    gameState = "player1Win";
                    gameTimer.Enabled = false;
                }
                else if (player2Body[0].X > this.Width - playerHead.Width)
                {
                    gameState = "player1Win";
                    gameTimer.Enabled = false;
                }
                else if (player2Body[0].Y > this.Height - playerHead.Height)
                {
                    gameState = "player1Win";
                    gameTimer.Enabled = false;
                }

                //checking if the player colided with the body of the snake
                for (int i = 0; i < player2Body.Count; i++)
                {
                    if (player2Body[0].IntersectsWith(player2Body[i]) && i > 1)
                    {
                        gameState = "player1Win";
                        gameTimer.Enabled = false;
                    }
                    else if (player2Body[0].IntersectsWith(playerBody[0]))
                    {
                        if (player1Score > player2Score)
                        {
                            gameState = "player1Win";
                            gameTimer.Enabled = false;
                        }
                        else if (player2Score > player1Score)
                        {
                            gameState = "player2Win";
                            gameTimer.Enabled = false;
                        }
                        else
                        {
                            gameState = "draw";
                            gameTimer.Enabled = false;
                        }
                    }
                }
                frameCounter2++;
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

                e.Graphics.DrawRectangle(purplePen, 0, 0, 599, 399);
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

                leaderboardButton.Visible = false;
                usernameInput.Visible = false;
            }
            else if (gameState == "2Player")
            {
                titleLabel.Text = "";
                subtitleLabel.Text = "";
                scoreLabel.Text = $"{player1Score}";
                scoreLabel2.Text = $"{player2Score}";

                e.Graphics.DrawRectangle(purplePen, 0, 0, 599, 399);
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

                leaderboardButton.Visible = false;
                usernameInput.Visible = false;
            }
            else if (gameState == "won1Player")
            {
                titleLabel.Text = "Snake";
                subtitleLabel.Text = "You won!\nPress space to play single player, press G to play 2 player or press escape to exit";
                scoreLabel.Text = "";
                scoreLabel2.Text = "";

                leaderboardButton.Visible = true;
                usernameInput.Visible = true;
            }
            else if (gameState == "lost1Player")
            {
                titleLabel.Text = "Snake";
                subtitleLabel.Text = $"You lost! You got a score of {player1Score}\nPress space to play single player, press G to play 2 player or press escape to exit";
                scoreLabel.Text = "";
                scoreLabel2.Text = "";

                leaderboardButton.Visible = true;
                usernameInput.Visible = true;
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
            else if (gameState == "beforeLeaderboard")
            {
                titleLabel.Visible = true;
                subtitleLabel.Visible = true;
                scoreLabel.Visible = false;
                scoreLabel2.Visible = false;
                leaderboardLabel.Visible = false;
                leaderboardButton.Visible = false;
                displayLeaderboardButton.Visible = true;
            }
            else if (gameState == "leaderboard")
            {
                usernameInput.Visible = false;
                titleLabel.Visible = false;
                subtitleLabel.Visible = false;
                scoreLabel.Visible = false;
                scoreLabel2.Visible = false;
                leaderboardButton.Visible = false;
                displayLeaderboardButton.Visible = false;
                leaderboardLabel.Visible = true;
            }
        }

        public void player1()
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
                                Rectangle playerTail = new Rectangle(-20, 0, 20, 20);
                                playerBody.Add(playerTail);
                                i = 0;
                            }
                            else if (lastDirection == 2)
                            {
                                Rectangle playerTail = new Rectangle(-20, 0, 20, 20);
                                playerBody.Add(playerTail);
                                i = 0;
                            }
                            else if (lastDirection == 3)
                            {
                                Rectangle playerTail = new Rectangle(-20, 0, 20, 20);
                                playerBody.Add(playerTail);
                                i = 0;
                            }
                            else if (lastDirection == 4)
                            {
                                Rectangle playerTail = new Rectangle(-20, 0, 20, 20);
                                playerBody.Add(playerTail);
                                i = 0;
                            }
                        }
                    }
                }
            }
            if (frameCounter % 5 == 0)
            {
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
            }

            //checking if the player has collided with a wall
            if (playerBody[0].Y < 0)
            {
                gameState = "lost1Player";
                gameTimer.Enabled = false;
            }
            else if (playerBody[0].X < 0)
            {
                gameState = "lost1Player";
                gameTimer.Enabled = false;
            }
            else if (playerBody[0].X > this.Width - playerHead.Width)
            {
                gameState = "lost1Player";
                gameTimer.Enabled = false;
            }
            else if (playerBody[0].Y > this.Height - playerHead.Height)
            {
                gameState = "lost1Player";
                gameTimer.Enabled = false;
            }

            //checking if the player colided with the body of the snake
            for (int i = 0; i < playerBody.Count; i++)
            {
                if (playerBody[0].IntersectsWith(playerBody[i]) && i > 1)
                {
                    gameState = "lost1Player";
                    gameTimer.Enabled = false;
                }
            }

            //checking if the player won
            if (player1Score == 600)
            {
                gameState = "won1Player";
                gameTimer.Enabled = false;
            }
            frameCounter++;
        }
    }
}