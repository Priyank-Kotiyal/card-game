using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Player
    {
        public string PlayerName { get; set; }

        public List<int> DrawPile { get; set; }

        public List<int> DiscardPile { get; set; }

        public void SetPlayer(string name, List<int> drwaPile, List<int> dicardPile)
        {
            PlayerName = name;
            DrawPile = drwaPile;
            DiscardPile = dicardPile;
        }
    }
}
