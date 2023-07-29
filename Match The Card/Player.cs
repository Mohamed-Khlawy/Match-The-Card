using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match_The_Card
{
    internal class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public bool Turn { get; set; }  //true = PlayerTurn, false = NotPlayerTurn
        public Player() 
        {
            
        }
    }
}
