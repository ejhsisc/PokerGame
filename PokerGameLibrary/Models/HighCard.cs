using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary
{
    /// <summary>
    /// When no player has even a pair, then the highest card wins
    /// </summary>
    public class HighCard : Rank
    {

        public HighCard(List<string> cards, int cardsRank) : base(cards, cardsRank) { }
        public override bool isRuleComplete()
        {
            return true;
        }
    }
}
