using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match_The_Card
{
    public partial class _100Cards : Form
    {
        GameLevel gameLevel;
        int currentPlayer = 1;
        int numberOfPlayers = 1; // Change this to 2 or 3 based on the number of players in the game.
        int[] playerScores = new int[3]; // Assuming the maximum number of players is 3.
        int firstButtonValue = -1; // Initialize with an invalid value.
        int matchedCount = 0; // To count the number of matched pairs.
        int rightChoose = 0;  //To calculate number of wrong chooses
        int wrongChoose = 0;  //To calculate number of right chooses
        Button FirstButton;
        Button SecondButton;
        Random random = new Random();
        int timerValue = 0;
        bool isDelaying = false;
        bool isTimerStoped = false;
        bool isTimerHidden = false;
        bool isGamePaused = false;
        string Player1name = "";
        string Player2name = "";
        string Player3name = "";
        public _100Cards(int _NumberOfPlayers, GameLevel _gameLevel,
            string _Player1Name = ".", string _Player2Name = ".", string _Player3Name = ".")
        {
            InitializeComponent();
            gameLevel = _gameLevel;
            numberOfPlayers = _NumberOfPlayers;
            //Level checks
            if (gameLevel == GameLevel.Beginner)
            {
                BeginnerVersion_CreateGamePanel();
            }
            else if (gameLevel == GameLevel.Challenger)
            {
                ChallengerVersion_CreateGamePanel();
            }
            else if (gameLevel == GameLevel.Expert)
            {
                ExpertVersion_CreateGamePanel();
            }

            //Assign player names
            if (_Player1Name == "." || _Player1Name == "")
                _Player1Name = "Player 1";
            if (_Player2Name == "." || _Player2Name == "")
                _Player2Name = "Player 2";
            if (_Player3Name == "." || _Player3Name == "")
                _Player3Name = "Player 3";
            Player1name = _Player1Name;
            Player2name = _Player2Name;
            Player3name = _Player3Name;

            Game_Timer.Start();
            Summary.Enabled = false;
        }
        private int[] GenerateIntArrayFrom1To50()
        {
            int[] result = new int[50];

            for (int i = 0; i < 50; i++)
            {
                result[i] = i + 1;
            }

            return result;
        }
        private void Button_Create(int[] numbersArray, int index, int row, int col)
        { 
            //For Beginner and Challenger Versions Only (Not Expert Version)
            Button button = new Button();
            button.Text = "";
            button.Tag = numbersArray[index].ToString();
            button.Width = 90;
            button.Height = 75;
            button.Font = new Font("Tahoma", 18, FontStyle.Bold); // Set the font for the button.
            button.ForeColor = Color.White;
            button.Click += Button_Click; // Add a click event handler (if needed).

            // Add the button to the panel.
            Game_Panel.Controls.Add(button);

            // Set the button position based on row and column.
            button.Left = col * button.Width;
            button.Top = row * button.Height;
        }
        private void Button_Create(int row, int col)
        {
            //For Expert Version Only
            Button button = new Button();
            button.Width = 90;
            button.Height = 75;
            button.Font = new Font("Tahoma", 18, FontStyle.Bold); // Set the font for the button.
            button.ForeColor = Color.White;
            button.Click += Button_Click; // Add a click event handler (if needed).

            // Add the button to the panel.
            Game_Panel.Controls.Add(button);

            // Set the button position based on row and column.
            button.Left = col * button.Width;
            button.Top = row * button.Height;
        }
        private void ShuffleArray(int[] array) //To shuffe the 1 to 50 array for Expert Version 
        {
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                int value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
        }
        private void BeginnerVersion_CreateGamePanel()
        {
            int[] numbersArray = GenerateIntArrayFrom1To50();

            // Clear the panel before adding new buttons (optional, depending on your use case).
            Game_Panel.Controls.Clear();
            
            int rows = 10;
            int cols = 10;

            int index = 0;

            //Fill first 5 rows with 50 cards from 1 to 50
            for (int row = 0; row < rows/2; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (index >= numbersArray.Length) // If we reach the end of numbersArray, break the loop.
                        break;

                    Button_Create(numbersArray,index, row, col);

                    index++; // Move to the next number in the numbersArray.
                }
            }

            index--;  //To Start the next two nested loops with 50 and go down

            //Fill second 5 rows with 50 cards from 1to 50
            for (int row = 5; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (index < 0) // If we reach the start of numbersArray, break the loop.
                        break;

                    Button_Create(numbersArray, index, row, col);

                    index--; // Move to the previous number in the numbersArray.
                }
            }

            //Delete the numbersArray
            numbersArray = null;
        }
        private void ChallengerVersion_CreateGamePanel()
        {
            int[] numbersArray = GenerateIntArrayFrom1To50();

            // Clear the panel before adding new buttons (optional, depending on your use case).
            Game_Panel.Controls.Clear();

            int rows = 10;
            int cols = 10;

            int index = 0;

            // Fill first 50 cards
            for (int col = 0; col < cols; col++)
            {
                if (col == 0 || col % 2 == 0)
                {
                    for (int row = 0; row < rows/2; row++)
                    {
                        if (index >= numbersArray.Length) // If we reach the end of numbersArray, break the loop.
                            break;

                        Button_Create(numbersArray, index, row, col);

                        index++;
                    }
                }
                else
                {
                    for (int row = 9; row >= rows / 2; row--)
                    {
                        if (index >= numbersArray.Length) // If we reach the end of numbersArray, break the loop.
                            break;

                        Button_Create(numbersArray, index, row, col);

                        index++;
                    }
                }
            }

            index--;   //To Start the next two nested loops with 50 and go down

            //Fill second 50 cards
            for (int col = 0; col < cols; col++)
            {
                if (col == 0 || col % 2 == 0)
                {
                    for (int row = 9; row >= rows / 2; row--)
                    {
                        if (index < 0) // If we reach the start of numbersArray, break the loop.
                            break;

                        Button_Create(numbersArray,index, row, col);

                        index--;
                    }
                }
                else
                {
                    for (int row = 0; row < rows / 2; row++)
                    {
                        if (index < 0) // If we reach the start of numbersArray, break the loop.
                            break;

                        Button_Create(numbersArray, index, row, col);

                        index--;
                    }
                }
            }

            //Delete the numbersArray
            numbersArray = null;
        }
        private void ExpertVersion_CreateGamePanel()
        {
            List<Button> GamePanelButtons = new List<Button>();
            int[] numbersArray = GenerateIntArrayFrom1To50();
            ShuffleArray(numbersArray);

            // Clear the panel before adding new buttons (optional, depending on your use case).
            Game_Panel.Controls.Clear();

            int rows = 10;
            int cols = 10;

            //Fill the Game_panel with empty buttons
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Button_Create(row, col);
                }
            }

            //Add the GamePanelButtons to the list
            foreach (Control control in Game_Panel.Controls)
            {
                if (control is Button button)
                {
                    GamePanelButtons.Add(button);
                }
            }

            //Assign tags for each button to be ready for playing
            for (int i = 0; i < 50; i++)
            {
                //Choose 2 random buttons from the GamePanelButtons by the list
                int RandomIndex1 = random.Next(GamePanelButtons.Count);
                Button RandomButton1 = GamePanelButtons[RandomIndex1];
                GamePanelButtons.Remove(RandomButton1);

                int RandomIndex2 = random.Next(GamePanelButtons.Count);
                Button RandomButton2 = GamePanelButtons[RandomIndex2];
                GamePanelButtons.Remove(RandomButton2);

                //Assign values for these 2 random buttons with value in the numbersArray after shuffling
                RandomButton1.Text = "";
                RandomButton1.Tag = numbersArray[i].ToString();
                RandomButton2.Text = "";
                RandomButton2.Tag = numbersArray[i].ToString();
            }

            //Delete the numbersArray
            numbersArray = null;
        }
        private void SwapBetween_ButtonText_And_ButtonTag(Button button)
        {
            //Swap the text between the Text and Tag properties to show/hide the content.
            string tempText = button.Text;
            button.Text = button.Tag.ToString();
            button.Tag = tempText;
        }
        private void RightMatch()
        {
            //Match found
            matchedCount++;
            playerScores[currentPlayer - 1]++;
            FirstButton.Enabled = false;
            SecondButton.Enabled = false;
            rightChoose++;
            Update_Points_Panel();
        }
        private void WrongMatch()
        {
            //Wrong Match
            SwapBetween_ButtonText_And_ButtonTag(FirstButton);
            SwapBetween_ButtonText_And_ButtonTag(SecondButton);
            currentPlayer = (currentPlayer % numberOfPlayers) + 1;
            wrongChoose++;
            Update_Points_Panel();

        }
        private void Button_Click(object sender, EventArgs e)
        {
            //To ignore any clicks during delay time
            if (isDelaying)
                return;
            Button clickedButton = (Button)sender;
            if (clickedButton.Tag.ToString() == "")
                return;
            SwapBetween_ButtonText_And_ButtonTag(clickedButton);
            int buttonValue = int.Parse(clickedButton.Text);
            if (firstButtonValue == -1)
            {
                //First button clicked
                firstButtonValue = buttonValue;
                FirstButton = (Button)sender;
            }
            else
            {
                //Second button clicked
                SecondButton = (Button)sender;
                if(firstButtonValue == buttonValue)
                {
                    //Right Match
                    RightMatch();
                }
                else
                {
                    isDelaying = true;
                    // No match. Clear the selection after a delay (to allow the player to see the second button).
                    Task.Delay(1000).ContinueWith(_ =>
                    {
                        WrongMatch();
                        isDelaying = false;
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
                //Prepare values for the next turn
                firstButtonValue = -1;
            }
            //To update points with each click
            if (matchedCount == 50)
            {
                Game_Timer.Stop();
                Summary.Enabled = true;
                Game_Summary();
            }
        }
        private void Game_Timer_Tick(object sender, EventArgs e)
        {
            timerValue++;
            //Update lbl_Timer
            int hours = timerValue / 3600;
            int minutes = (timerValue % 3600) / 60;
            int seconds = timerValue % 60;
            lbl_Timer.Text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }
        private void Resume_Pause_Timer_Timer_Click(object sender, EventArgs e)
        {
            if(!isTimerStoped)
            {
                Game_Timer.Stop();
                Resume_Pause_Timer.Text = "Resume Timer";
                isTimerStoped = true;
            }
            else
            {
                Game_Timer.Start();
                Resume_Pause_Timer.Text = "Pause Timer";
                isTimerStoped = false;
            }
        }
        private void Hide_Appear_Timer_Click(object sender, EventArgs e)
        {
            if (!isTimerHidden)
            {
                lbl_Timer.Visible = false;
                Hide_Appear_Timer.Text = "Appear Timer";
                isTimerHidden = true;
            }
            else
            {
                lbl_Timer.Visible = true;
                Hide_Appear_Timer.Text = "Hide Timer";
                isTimerHidden = false;
            }
        }
        private void Update_Points_Panel()
        {
            //Player names and points
            if (numberOfPlayers == 1)
            {
                Player1Name.Text = Player1name + " : ";
                Player1Points.Text = playerScores[0].ToString() + " Points";
                Player2Name.Visible = false;
                Player2Points.Visible = false;
                Player3Name.Visible = false;
                Player3Points.Visible = false;
            }
            else if (numberOfPlayers == 2)
            {
                Player1Name.Text = Player1name + " : ";
                Player2Name.Text = Player2name + " : ";
                Player1Points.Text = playerScores[0].ToString() + " Points";
                Player2Points.Text = playerScores[1].ToString() + " Points";
                Player3Name.Visible = false;
                Player3Points.Visible = false;
            }
            else if (numberOfPlayers == 3)
            {
                Player1Name.Text = Player1name + " : ";
                Player2Name.Text = Player2name + " : ";
                Player3Name.Text = Player3name + " : ";
                Player1Points.Text = playerScores[0].ToString() + " Points";
                Player2Points.Text = playerScores[1].ToString() + " Points";
                Player3Points.Text = playerScores[2].ToString() + " Points";
            }

            //Matched cards
            lbl_Matched_Cards.Text = matchedCount.ToString() + " / 50";

            //Current player turn
            if (currentPlayer == 1)
                lbl_Player_Turn.Text = Player1name + "'s" + " Turn";
            else if(currentPlayer == 2)
                lbl_Player_Turn.Text = Player2name + "'s" + " Turn";
            else
                lbl_Player_Turn.Text = Player3name + "'s" + " Turn";
        }
        private void _100Cards_Load(object sender, EventArgs e)
        {
            Update_Points_Panel();
        }
        private void Game_Summary()
        {
            if (numberOfPlayers == 1)
            {
                DialogResult summary = MessageBox.Show($"Your time is: {lbl_Timer.Text} \n" +
                    $"Your points are: {playerScores[0]} \n" +
                    $"Number of Right Chooses are: {rightChoose} \n" +
                    $"Number of Wrong Chooses are: {wrongChoose} \n"
                    ,
                 "Match The Card Summary", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (summary == DialogResult.OK)
                {
                    New.PerformClick();
                }
            }
            else if(numberOfPlayers == 2)
            {
                DialogResult summary = MessageBox.Show($"Your time is: {lbl_Timer.Text} \n" +
                    $"{Player1Name.Text} points are: {playerScores[0]} \n" +
                    $"{Player2Name.Text} points are: {playerScores[1]} \n" +
                    $"Number of Right Chooses are: {rightChoose} \n" +
                    $"Number of Wrong Chooses are: {wrongChoose} \n"
                    ,
                 "Match The Card Summary", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (summary == DialogResult.OK)
                {
                    New.PerformClick();
                }
            }
            else if (numberOfPlayers == 3)
            {
                DialogResult summary = MessageBox.Show($"Your time is: {lbl_Timer.Text} \n" +
                    $"{Player1Name.Text} points are: {playerScores[0]} \n" +
                    $"{Player2Name.Text} points are: {playerScores[1]} \n" +
                    $"{Player3Name.Text} points are: {playerScores[2]} \n" +
                    $"Number of Right Chooses are: {rightChoose} \n" +
                    $"Number of Wrong Chooses are: {wrongChoose} \n"
                    ,
                 "Match The Card Summary", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (summary == DialogResult.OK)
                {
                    New.PerformClick();
                }
            }
        }
        private void ResetGameTimer()
        {
            Game_Timer.Stop();
            timerValue = 0;
            //Game_Timer.Start();
        }
        private void New_Click(object sender, EventArgs e)
        {
            DialogResult New = MessageBox.Show("Are you sure you want to start new game?",
                     "Match The Card Result", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (New == DialogResult.OK)
            {
                //Reset Game_Panel with specific level 
                if (gameLevel == GameLevel.Beginner)
                {
                    BeginnerVersion_CreateGamePanel();
                }
                else if (gameLevel == GameLevel.Challenger)
                {
                    ChallengerVersion_CreateGamePanel();
                }
                else if (gameLevel == GameLevel.Expert)
                {
                    ExpertVersion_CreateGamePanel();
                }

                //Reset the timer
                ResetGameTimer();

                //Reintialize some variables for new game
                currentPlayer = 1;
                matchedCount = 0;
                firstButtonValue = -1;
                rightChoose = 0;
                wrongChoose = 0;
                isDelaying = false;
                isTimerStoped = true;
                isTimerHidden = true;

                //Reset playerScores Array
                for (int i = 0; i < 3; i++)
                {
                    playerScores[i] = 0;
                }

                //Reset some panels data
                Resume_Pause_Timer_Timer_Click(sender, e);
                Hide_Appear_Timer_Click(sender, e);
                Update_Points_Panel();
            }
        }
        private void Resume_Pause_Click(object sender, EventArgs e)
        {
            if (!isGamePaused)
            {
                Game_Timer.Stop();
                foreach (Control control in Game_Panel.Controls)
                {
                    if (control.Text == "")
                    {
                        control.Enabled = false;
                    }
                }
                isGamePaused = true;
            }
            else
            {
                Game_Timer.Start();
                foreach (Control control in Game_Panel.Controls)
                {
                    if (control.Text == "")
                    {
                        control.Enabled = true;
                    }
                }
                isGamePaused = false;
            }
        }
        private void Summary_Click(object sender, EventArgs e)
        {
            Game_Summary();
        }
        private void Close_Click(object sender, EventArgs e)
        {
            DialogResult close = MessageBox.Show("Are you sure you want to close the game and back to welcome page?",
                     "Match The Card Result", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (close == DialogResult.OK)
            {
                //Welcome_Page welcome_Page = new Welcome_Page();
                //welcome_Page.Show();
                this.Close();
            }
        }
        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.SteelBlue;
        }
        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.DeepSkyBlue;
        }

        private void _100Cards_FormClosing(object sender, FormClosingEventArgs e)
        {
            Welcome_Page welcome_Page = new Welcome_Page();
            welcome_Page.Show();
        }

        private void pageColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog.Color;
                menuItems.BackColor = colorDialog.Color;
            }
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.ForeColor = colorDialog.Color;
                foreach(Control control in Game_Panel.Controls)
                {
                    control.ForeColor = colorDialog.Color;
                }
                foreach (Control control in Timer_Panel.Controls)
                {
                    control.ForeColor = colorDialog.Color;
                }
                foreach (Control control in Points_Panel.Controls)
                {
                    control.ForeColor = colorDialog.Color;
                }
                foreach (Control control in Buttons_Panel.Controls)
                {
                    control.ForeColor = colorDialog.Color;
                }
            }
        }

        private void darkGrayModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //To avoid choose it again
            darkGrayModeToolStripMenuItem.Enabled = false;
            whiteModeToolStripMenuItem.Enabled = true;

            //Form Colors
            this.BackColor = Color.DimGray;
            this.ForeColor = Color.Black;
            this.menuItems.BackColor = Color.DimGray;
            this.menuItems.ForeColor = Color.Black;

            //ForeColor of the form controls
            this.ForeColor = Color.Black;
            foreach (Control control in Game_Panel.Controls)
            {
                control.ForeColor = Color.Black;
            }
            foreach (Control control in Timer_Panel.Controls)
            {
                control.ForeColor = Color.Black;
            }
            foreach (Control control in Points_Panel.Controls)
            {
                control.ForeColor = Color.Black;
            }
            foreach (Control control in Buttons_Panel.Controls)
            {
                control.ForeColor = Color.Black;
            }

            //Backcolor of the form controls
            this.BackColor = Color.LightGray;
            foreach (Control control in Game_Panel.Controls)
            {
                control.BackColor = Color.DarkGray;
            }
            foreach (Control control in Timer_Panel.Controls)
            {
                control.BackColor = Color.LightGray;
            }
            foreach (Control control in Points_Panel.Controls)
            {
                control.BackColor = Color.LightGray;
            }
            foreach (Control control in Buttons_Panel.Controls)
            {
                control.BackColor = Color.LightGray;
            }
        }

        private void whiteModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //To avoid choose it again
            darkGrayModeToolStripMenuItem.Enabled = true;
            whiteModeToolStripMenuItem.Enabled = false;

            //Form Colors
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.menuItems.BackColor = Color.White;
            this.menuItems.ForeColor = Color.Black;

            //ForeColor of the form controls
            this.ForeColor = Color.Black;
            foreach (Control control in Game_Panel.Controls)
            {
                control.ForeColor = Color.Black;
            }
            foreach (Control control in Timer_Panel.Controls)
            {
                control.ForeColor = Color.Black;
            }
            foreach (Control control in Points_Panel.Controls)
            {
                control.ForeColor = Color.Black;
            }
            foreach (Control control in Buttons_Panel.Controls)
            {
                control.ForeColor = Color.Black;
            }

            //Backcolor of the form controls
            this.BackColor = Color.White;
            foreach (Control control in Game_Panel.Controls)
            {
                control.BackColor = Color.DarkGray;
            }
            foreach (Control control in Timer_Panel.Controls)
            {
                control.BackColor = Color.White;
            }
            foreach (Control control in Points_Panel.Controls)
            {
                control.BackColor = Color.White;
            }
            foreach (Control control in Buttons_Panel.Controls)
            {
                control.BackColor = Color.White;
            }
        }
    }
}
