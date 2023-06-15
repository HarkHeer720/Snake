namespace Snake
{
    partial class mainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scoreLabel2 = new System.Windows.Forms.Label();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.leaderboardButton = new System.Windows.Forms.Button();
            this.leaderboardLabel = new System.Windows.Forms.Label();
            this.displayLeaderboardButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 125;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Green;
            this.titleLabel.Location = new System.Drawing.Point(12, 155);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(576, 39);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Snake";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subtitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.ForeColor = System.Drawing.Color.Transparent;
            this.subtitleLabel.Location = new System.Drawing.Point(12, 203);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(576, 93);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Press space to play or press escape to exit";
            this.subtitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(537, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(0, 25);
            this.scoreLabel.TabIndex = 2;
            // 
            // scoreLabel2
            // 
            this.scoreLabel2.AutoSize = true;
            this.scoreLabel2.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel2.ForeColor = System.Drawing.Color.White;
            this.scoreLabel2.Location = new System.Drawing.Point(19, 9);
            this.scoreLabel2.Name = "scoreLabel2";
            this.scoreLabel2.Size = new System.Drawing.Size(0, 25);
            this.scoreLabel2.TabIndex = 3;
            // 
            // usernameInput
            // 
            this.usernameInput.Location = new System.Drawing.Point(69, 299);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(190, 20);
            this.usernameInput.TabIndex = 4;
            this.usernameInput.Visible = false;
            // 
            // leaderboardButton
            // 
            this.leaderboardButton.Location = new System.Drawing.Point(69, 351);
            this.leaderboardButton.Name = "leaderboardButton";
            this.leaderboardButton.Size = new System.Drawing.Size(468, 23);
            this.leaderboardButton.TabIndex = 6;
            this.leaderboardButton.Text = "Baller";
            this.leaderboardButton.UseVisualStyleBackColor = true;
            this.leaderboardButton.Visible = false;
            this.leaderboardButton.Click += new System.EventHandler(this.leaderboardButton_Click);
            // 
            // leaderboardLabel
            // 
            this.leaderboardLabel.BackColor = System.Drawing.Color.Transparent;
            this.leaderboardLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboardLabel.ForeColor = System.Drawing.Color.White;
            this.leaderboardLabel.Location = new System.Drawing.Point(12, 9);
            this.leaderboardLabel.Name = "leaderboardLabel";
            this.leaderboardLabel.Size = new System.Drawing.Size(576, 382);
            this.leaderboardLabel.TabIndex = 7;
            this.leaderboardLabel.Visible = false;
            // 
            // displayLeaderboardButton
            // 
            this.displayLeaderboardButton.Location = new System.Drawing.Point(69, 351);
            this.displayLeaderboardButton.Name = "displayLeaderboardButton";
            this.displayLeaderboardButton.Size = new System.Drawing.Size(468, 23);
            this.displayLeaderboardButton.TabIndex = 8;
            this.displayLeaderboardButton.Text = "Display leaderboard";
            this.displayLeaderboardButton.UseMnemonic = false;
            this.displayLeaderboardButton.UseVisualStyleBackColor = true;
            this.displayLeaderboardButton.Visible = false;
            this.displayLeaderboardButton.Click += new System.EventHandler(this.displayLeaderboard_Click);
            // 
            // mainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.displayLeaderboardButton);
            this.Controls.Add(this.leaderboardButton);
            this.Controls.Add(this.usernameInput);
            this.Controls.Add(this.scoreLabel2);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.leaderboardLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mainScreen";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label scoreLabel2;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.Button leaderboardButton;
        private System.Windows.Forms.Label leaderboardLabel;
        private System.Windows.Forms.Button displayLeaderboardButton;
    }
}

