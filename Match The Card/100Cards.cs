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
        GameLevel GameLevel;
        int currentPlayer = 1;
        int numberOfPlayers = 1; // Change this to 2 or 3 based on the number of players in the game.
        int[] playerScores = new int[3]; // Assuming the maximum number of players is 3.
        int firstButtonValue = -1; // Initialize with an invalid value.
        int matchedCount = 0; // To count the number of matched pairs.
        Button FirstButton;
        Button SecondButton;
        public _100Cards(int _NumberOfPlayers, GameLevel _gameLevel)
        {
            InitializeComponent();
            GameLevel = _gameLevel;
            numberOfPlayers = _NumberOfPlayers;
            CreateGamePanel(Game_Panel);
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
        private void Button_Create(int[] numbersArray, int index, Panel GamePanel, int row, int col)
        {
            Button button = new Button();
            button.Text = "";
            button.Tag = numbersArray[index].ToString();
            button.Width = 90;
            button.Height = 75;
            button.Font = new Font("Tahoma", 18, FontStyle.Bold); // Set the font for the button.
            button.Click += Button_Click; // Add a click event handler (if needed).

            // Add the button to the panel.
            GamePanel.Controls.Add(button);

            // Set the button position based on row and column.
            button.Left = col * button.Width;
            button.Top = row * button.Height;
        }
        private void CreateGamePanel(Panel GamePanel)
        {
            int[] numbersArray = GenerateIntArrayFrom1To50();

            // Clear the panel before adding new buttons (optional, depending on your use case).
            GamePanel.Controls.Clear();

            int rows = 10;
            int cols = 10;

            // Define the font you want to use for the buttons.
            Font buttonFont = new Font("Tahoma", 18, FontStyle.Bold);

            int index = 0;

            //Fill first 5 rows with 50 cards from 1 to 50
            for (int row = 0; row < rows/2; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    //int index = row * cols + col; // Calculate the index for the numbersArray.

                    if (index >= numbersArray.Length) // If we reach the end of numbersArray, break the loop.
                        break;

                    Button_Create(numbersArray,index, GamePanel, row, col);

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

                    Button_Create(numbersArray, index, GamePanel, row, col);

                    index--; // Move to the previous number in the numbersArray.
                }
            }
        }
        private void SwapBetween_ButtonText_And_ButtonTag(Button button)
        {
            //Swap the text between the Text and Tag properties to show/hide the content.
            string tempText = button.Text;
            button.Text = button.Tag.ToString();
            button.Tag = tempText;
        }
        private void RightMatch(int matchedCount, int[]playerScores,
            int currentPlayer, Button FirstButton, Button SecondButton)
        {
            //Match found
            matchedCount++;
            playerScores[currentPlayer - 1]++;
            FirstButton.Enabled = false;
            SecondButton.Enabled = false;
        }
        private void WrongMatch(Button FirstButton, Button SecondButton)
        {
            SwapBetween_ButtonText_And_ButtonTag(FirstButton);
            SwapBetween_ButtonText_And_ButtonTag(SecondButton);
            currentPlayer = (currentPlayer % numberOfPlayers) + 1;
        }
        private void Button_Click(object sender, EventArgs e)
        {
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
                    RightMatch(matchedCount, playerScores, currentPlayer, FirstButton, SecondButton);
                }
                else
                {
                    // No match. Clear the selection after a delay (to allow the player to see the second button).
                    Task.Delay(1000).ContinueWith(_ =>
                    {
                        WrongMatch(FirstButton, SecondButton);
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
                //Prepare values for the next turn
                firstButtonValue = -1;
            }
        }
    }
}
