namespace Match_The_Card
{
    partial class _100Cards
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_100Cards));
            this.Game_Panel = new System.Windows.Forms.Panel();
            this.Timer_Panel = new System.Windows.Forms.Panel();
            this.Resume_Pause_Timer = new System.Windows.Forms.Button();
            this.Hide_Appear_Timer = new System.Windows.Forms.Button();
            this.lbl_Timer = new System.Windows.Forms.Label();
            this.Points_Panel = new System.Windows.Forms.Panel();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl_Player_Turn = new System.Windows.Forms.Label();
            this.lbl_Right_Cards = new System.Windows.Forms.Label();
            this.Player3Points = new System.Windows.Forms.Label();
            this.Player2Points = new System.Windows.Forms.Label();
            this.Player1Points = new System.Windows.Forms.Label();
            this.Player3Name = new System.Windows.Forms.Label();
            this.Player2Name = new System.Windows.Forms.Label();
            this.Player1Name = new System.Windows.Forms.Label();
            this.Buttons_Panel = new System.Windows.Forms.Panel();
            this.New = new System.Windows.Forms.Button();
            this.Resume_Pause = new System.Windows.Forms.Button();
            this.Summary = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.Game_Timer = new System.Windows.Forms.Timer(this.components);
            this.Timer_Panel.SuspendLayout();
            this.Points_Panel.SuspendLayout();
            this.Buttons_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Game_Panel
            // 
            this.Game_Panel.Location = new System.Drawing.Point(3, 12);
            this.Game_Panel.Name = "Game_Panel";
            this.Game_Panel.Size = new System.Drawing.Size(1056, 957);
            this.Game_Panel.TabIndex = 0;
            // 
            // Timer_Panel
            // 
            this.Timer_Panel.Controls.Add(this.Resume_Pause_Timer);
            this.Timer_Panel.Controls.Add(this.Hide_Appear_Timer);
            this.Timer_Panel.Controls.Add(this.lbl_Timer);
            this.Timer_Panel.Location = new System.Drawing.Point(1065, 12);
            this.Timer_Panel.Name = "Timer_Panel";
            this.Timer_Panel.Size = new System.Drawing.Size(714, 206);
            this.Timer_Panel.TabIndex = 1;
            // 
            // Resume_Pause_Timer
            // 
            this.Resume_Pause_Timer.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Resume_Pause_Timer.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resume_Pause_Timer.ForeColor = System.Drawing.Color.White;
            this.Resume_Pause_Timer.Location = new System.Drawing.Point(428, 104);
            this.Resume_Pause_Timer.Name = "Resume_Pause_Timer";
            this.Resume_Pause_Timer.Size = new System.Drawing.Size(255, 80);
            this.Resume_Pause_Timer.TabIndex = 27;
            this.Resume_Pause_Timer.Text = "Pause Timer";
            this.Resume_Pause_Timer.UseVisualStyleBackColor = false;
            this.Resume_Pause_Timer.Click += new System.EventHandler(this.Resume_Pause_Timer_Timer_Click);
            // 
            // Hide_Appear_Timer
            // 
            this.Hide_Appear_Timer.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Hide_Appear_Timer.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hide_Appear_Timer.ForeColor = System.Drawing.Color.White;
            this.Hide_Appear_Timer.Location = new System.Drawing.Point(31, 104);
            this.Hide_Appear_Timer.Name = "Hide_Appear_Timer";
            this.Hide_Appear_Timer.Size = new System.Drawing.Size(255, 80);
            this.Hide_Appear_Timer.TabIndex = 26;
            this.Hide_Appear_Timer.Text = "Hide Timer";
            this.Hide_Appear_Timer.UseVisualStyleBackColor = false;
            this.Hide_Appear_Timer.Click += new System.EventHandler(this.Hide_Appear_Timer_Click);
            // 
            // lbl_Timer
            // 
            this.lbl_Timer.Font = new System.Drawing.Font("Tahoma", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Timer.ForeColor = System.Drawing.Color.White;
            this.lbl_Timer.Location = new System.Drawing.Point(179, 16);
            this.lbl_Timer.Name = "lbl_Timer";
            this.lbl_Timer.Size = new System.Drawing.Size(445, 65);
            this.lbl_Timer.TabIndex = 25;
            this.lbl_Timer.Text = "Timer: ";
            // 
            // Points_Panel
            // 
            this.Points_Panel.Controls.Add(this.lbl2);
            this.Points_Panel.Controls.Add(this.lbl1);
            this.Points_Panel.Controls.Add(this.lbl_Player_Turn);
            this.Points_Panel.Controls.Add(this.lbl_Right_Cards);
            this.Points_Panel.Controls.Add(this.Player3Points);
            this.Points_Panel.Controls.Add(this.Player2Points);
            this.Points_Panel.Controls.Add(this.Player1Points);
            this.Points_Panel.Controls.Add(this.Player3Name);
            this.Points_Panel.Controls.Add(this.Player2Name);
            this.Points_Panel.Controls.Add(this.Player1Name);
            this.Points_Panel.Location = new System.Drawing.Point(1065, 224);
            this.Points_Panel.Name = "Points_Panel";
            this.Points_Panel.Size = new System.Drawing.Size(714, 433);
            this.Points_Panel.TabIndex = 1;
            // 
            // lbl2
            // 
            this.lbl2.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.White;
            this.lbl2.Location = new System.Drawing.Point(458, 303);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(238, 50);
            this.lbl2.TabIndex = 34;
            this.lbl2.Text = "Player Turn";
            // 
            // lbl1
            // 
            this.lbl1.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.White;
            this.lbl1.Location = new System.Drawing.Point(26, 303);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(240, 50);
            this.lbl1.TabIndex = 33;
            this.lbl1.Text = "Right Cards";
            // 
            // lbl_Player_Turn
            // 
            this.lbl_Player_Turn.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Player_Turn.ForeColor = System.Drawing.Color.White;
            this.lbl_Player_Turn.Location = new System.Drawing.Point(493, 365);
            this.lbl_Player_Turn.Name = "lbl_Player_Turn";
            this.lbl_Player_Turn.Size = new System.Drawing.Size(163, 50);
            this.lbl_Player_Turn.TabIndex = 32;
            // 
            // lbl_Right_Cards
            // 
            this.lbl_Right_Cards.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Right_Cards.ForeColor = System.Drawing.Color.White;
            this.lbl_Right_Cards.Location = new System.Drawing.Point(68, 365);
            this.lbl_Right_Cards.Name = "lbl_Right_Cards";
            this.lbl_Right_Cards.Size = new System.Drawing.Size(163, 50);
            this.lbl_Right_Cards.TabIndex = 31;
            // 
            // Player3Points
            // 
            this.Player3Points.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player3Points.ForeColor = System.Drawing.Color.White;
            this.Player3Points.Location = new System.Drawing.Point(222, 202);
            this.Player3Points.Name = "Player3Points";
            this.Player3Points.Size = new System.Drawing.Size(256, 50);
            this.Player3Points.TabIndex = 30;
            this.Player3Points.Text = "Points";
            // 
            // Player2Points
            // 
            this.Player2Points.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2Points.ForeColor = System.Drawing.Color.White;
            this.Player2Points.Location = new System.Drawing.Point(222, 119);
            this.Player2Points.Name = "Player2Points";
            this.Player2Points.Size = new System.Drawing.Size(256, 50);
            this.Player2Points.TabIndex = 29;
            this.Player2Points.Text = "Points";
            // 
            // Player1Points
            // 
            this.Player1Points.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1Points.ForeColor = System.Drawing.Color.White;
            this.Player1Points.Location = new System.Drawing.Point(222, 36);
            this.Player1Points.Name = "Player1Points";
            this.Player1Points.Size = new System.Drawing.Size(256, 50);
            this.Player1Points.TabIndex = 28;
            this.Player1Points.Text = "Points";
            // 
            // Player3Name
            // 
            this.Player3Name.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player3Name.ForeColor = System.Drawing.Color.White;
            this.Player3Name.Location = new System.Drawing.Point(26, 202);
            this.Player3Name.Name = "Player3Name";
            this.Player3Name.Size = new System.Drawing.Size(163, 50);
            this.Player3Name.TabIndex = 27;
            this.Player3Name.Text = "Player3";
            // 
            // Player2Name
            // 
            this.Player2Name.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2Name.ForeColor = System.Drawing.Color.White;
            this.Player2Name.Location = new System.Drawing.Point(26, 119);
            this.Player2Name.Name = "Player2Name";
            this.Player2Name.Size = new System.Drawing.Size(163, 50);
            this.Player2Name.TabIndex = 26;
            this.Player2Name.Text = "Player2";
            // 
            // Player1Name
            // 
            this.Player1Name.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1Name.ForeColor = System.Drawing.Color.White;
            this.Player1Name.Location = new System.Drawing.Point(26, 36);
            this.Player1Name.Name = "Player1Name";
            this.Player1Name.Size = new System.Drawing.Size(163, 50);
            this.Player1Name.TabIndex = 25;
            this.Player1Name.Text = "Player1";
            // 
            // Buttons_Panel
            // 
            this.Buttons_Panel.Controls.Add(this.New);
            this.Buttons_Panel.Controls.Add(this.Resume_Pause);
            this.Buttons_Panel.Controls.Add(this.Summary);
            this.Buttons_Panel.Controls.Add(this.Close);
            this.Buttons_Panel.Location = new System.Drawing.Point(1065, 663);
            this.Buttons_Panel.Name = "Buttons_Panel";
            this.Buttons_Panel.Size = new System.Drawing.Size(714, 306);
            this.Buttons_Panel.TabIndex = 1;
            // 
            // New
            // 
            this.New.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.New.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.New.ForeColor = System.Drawing.Color.White;
            this.New.Location = new System.Drawing.Point(31, 25);
            this.New.Name = "New";
            this.New.Size = new System.Drawing.Size(250, 92);
            this.New.TabIndex = 34;
            this.New.Text = "New Game";
            this.New.UseVisualStyleBackColor = false;
            // 
            // Resume_Pause
            // 
            this.Resume_Pause.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Resume_Pause.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resume_Pause.ForeColor = System.Drawing.Color.White;
            this.Resume_Pause.Location = new System.Drawing.Point(446, 25);
            this.Resume_Pause.Name = "Resume_Pause";
            this.Resume_Pause.Size = new System.Drawing.Size(250, 92);
            this.Resume_Pause.TabIndex = 33;
            this.Resume_Pause.Text = "Resume/Pause";
            this.Resume_Pause.UseVisualStyleBackColor = false;
            // 
            // Summary
            // 
            this.Summary.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Summary.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Summary.ForeColor = System.Drawing.Color.White;
            this.Summary.Location = new System.Drawing.Point(31, 179);
            this.Summary.Name = "Summary";
            this.Summary.Size = new System.Drawing.Size(250, 92);
            this.Summary.TabIndex = 32;
            this.Summary.Text = "Game Summary";
            this.Summary.UseVisualStyleBackColor = false;
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Close.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.ForeColor = System.Drawing.Color.White;
            this.Close.Location = new System.Drawing.Point(446, 179);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(250, 92);
            this.Close.TabIndex = 31;
            this.Close.Text = "Close Game";
            this.Close.UseVisualStyleBackColor = false;
            // 
            // Game_Timer
            // 
            this.Game_Timer.Interval = 1000;
            this.Game_Timer.Tick += new System.EventHandler(this.Game_Timer_Tick);
            // 
            // _100Cards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1832, 981);
            this.Controls.Add(this.Buttons_Panel);
            this.Controls.Add(this.Points_Panel);
            this.Controls.Add(this.Timer_Panel);
            this.Controls.Add(this.Game_Panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1850, 1028);
            this.Name = "_100Cards";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "100Cards_Game Version";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Timer_Panel.ResumeLayout(false);
            this.Points_Panel.ResumeLayout(false);
            this.Buttons_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Game_Panel;
        private System.Windows.Forms.Panel Timer_Panel;
        private System.Windows.Forms.Panel Points_Panel;
        private System.Windows.Forms.Panel Buttons_Panel;
        private System.Windows.Forms.Label lbl_Timer;
        private System.Windows.Forms.Button Resume_Pause_Timer;
        private System.Windows.Forms.Button Hide_Appear_Timer;
        private System.Windows.Forms.Label Player1Name;
        private System.Windows.Forms.Label Player3Name;
        private System.Windows.Forms.Label Player2Name;
        private System.Windows.Forms.Label Player3Points;
        private System.Windows.Forms.Label Player2Points;
        private System.Windows.Forms.Label Player1Points;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl_Player_Turn;
        private System.Windows.Forms.Label lbl_Right_Cards;
        private System.Windows.Forms.Button New;
        private System.Windows.Forms.Button Resume_Pause;
        private System.Windows.Forms.Button Summary;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Timer Game_Timer;
    }
}