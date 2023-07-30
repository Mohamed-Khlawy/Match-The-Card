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
        Button FirstButton;
        Button SecondButton;
        Random random = new Random();
        int timerValue = 0;
        bool isDelaying = false;
        bool isTimerStoped = false;
        bool isTimerHidden = false;
        public _100Cards(int _NumberOfPlayers, GameLevel _gameLevel)
        {
            InitializeComponent();
            gameLevel = _gameLevel;
            numberOfPlayers = _NumberOfPlayers;
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
            Game_Timer.Start();
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
        }
        private void WrongMatch()
        {
            SwapBetween_ButtonText_And_ButtonTag(FirstButton);
            SwapBetween_ButtonText_And_ButtonTag(SecondButton);
            currentPlayer = (currentPlayer % numberOfPlayers) + 1;
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
            if (matchedCount == 50)
            {
                Game_Timer.Stop();
            }
        }
        private void Game_Timer_Tick(object sender, EventArgs e)
        {
            timerValue++;
            //Update lbl_Timer
            int hours = timerValue / 3600;
            int minutes = (timerValue % 3600) / 60;
            int seconds = timerValue % 60;
            lbl_Timer.Text = "Timer: " + $"{hours:D2}:{minutes:D2}:{seconds:D2}";
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
    }
}
