using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary
{
    /// <summary>
    /// A flush is any hand with five cards of the same suit
    /// </summary>
    public class Flush : Rank
    {

        public Flush(List<string> cards,int cardsRank) :base(cards, cardsRank) {}

        public override bool isRuleComplete()
        {
            return cards.GroupBy(x => x[1]).ToList().Count == 1;
        }
        
    }
}
