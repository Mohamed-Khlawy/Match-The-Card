using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match_The_Card
{
    public partial class _100Cards : Form
    {
        public GameLevel GameLevel { get; set; }
        public _100Cards()
        {
            InitializeComponent();
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
        private void CreateGamePanel(Panel GamePanel)
        {
            int[] numbersArray = GenerateIntArrayFrom1To50();

            // Clear the panel before adding new buttons (optional, depending on your use case).
            GamePanel.Controls.Clear();

            int rows = 10;
            int cols = 10;

            // Define the font you want to use for the buttons.
            Font buttonFont = new Font("Tahoma", 18, FontStyle.Bold);

            //Fill first 5 rows with 50 cards from 1 to 50
            for (int row = 0; row < rows/2; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int index = row * cols + col; // Calculate the index for the numbersArray.

                    if (index >= numbersArray.Length) // If we reach the end of numbersArray, break the loop.
                        break;

                    Button button = new Button();
                    button.Text = "";
                    button.Tag = numbersArray[index].ToString();
                    button.Width = 90;
                    button.Height = 75;
                    button.Font = buttonFont; // Set the font for the button.
                    button.Click += Button_Click; // Add a click event handler (if needed).

                    // Add the button to the panel.
                    GamePanel.Controls.Add(button);

                    // Set the button position based on row and column.
                    button.Left = col * button.Width;
                    button.Top = row * button.Height;
                }
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            // Swap the text between the Text and Tag properties to show/hide the content.
            string tempText = button.Text;
            button.Text = button.Tag.ToString();
            button.Tag = tempText;
        }
    }
}
