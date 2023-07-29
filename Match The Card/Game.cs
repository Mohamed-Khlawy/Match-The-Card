using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match_The_Card
{
    public partial class Game
    {
        public int NumberOfCards;
        public GameLevel GameLevel { get; set; }
        public void SetCardNumber(int numberOfCards)
        {
            if(numberOfCards == 50)
            {
                NumberOfCards = 50;
            }
            else if(numberOfCards == 100)
            {
                NumberOfCards = 100;
            }
        }
        public void SetLevel(GameLevel level)
        {
            if (level == GameLevel.Beginner)
            {
                GameLevel = GameLevel.Beginner;
            }
            else if(level == GameLevel.Challenger)
            {
                GameLevel = GameLevel.Challenger;
            }
            else if(level == GameLevel.Expert)
            {
                GameLevel = GameLevel.Expert;
            }
        }
        
    }
}
