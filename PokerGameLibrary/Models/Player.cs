using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static PokerGameLibrary.Settings;

namespace PokerGameLibrary
{
    public class Player
    {
        public int idPlayer { get; set; }
        public string playerName { get; set; }
        public List<string> cards { get; set; }
        public int cardsRank { get; set; }
        public int cardsRankLevel { get; set; }
        public int cardsScore{ get; set; }
        public CardRanks cardsRankName
        {
            get
            {
                return (CardRanks)cardsRank;
            }
        }

        public Player(){}
        public Player(string player,int i)
        {

            idPlayer = i;

            //Replace empty spaces
            player=Regex.Replace(player, @"\s+", "");

            //Replace the number 10 for T to have always 2 positions
            player=Regex.Replace(player, "10", "T");

            //Split name and cards
            var array = player.Split(':');
            playerName = array[0].ToString().Trim();

            //Regex cards format
            //string input = @"11C,7D,9H,9S,QS";
            string pattern = @"^([\b([2-9]|[TAKQJ])([HSCD])(,([\b([2-9]|[TAKQJ])([HSCD])){4}$";
            Match m = Regex.Match(array[1], pattern);
            if(m.Success==false)
                throw new Exception();

            cards = array[1].Split(',').ToList();

            //Validate number of cards
            if (cards?.Count() != 5)
            {
                throw new Exception();
            }
          
        }
    }
}
