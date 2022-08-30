using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary
{
    /// <summary>
    /// If more than one player holds three of a kind, then the higher value of the cards used to make the three of kind determines the winner.
    /// </summary>
    public class ThreeOfKind : Rank
    {
        public ThreeOfKind(List<string> cards, int cardsRank) : base(cards, cardsRank) { }

        public override bool isRuleComplete()
        {
             return cards.GroupBy(
                x => x[0]
                ).ToList().Where(x=>x.Count()==3).Count()==1;

        }

        public override int cardToScore()
        {
            cards = cards.OrderByDescending(x => mapCards[x[0]]).ToList();

            var HandFound = cards.GroupBy(x => x[0])
                        .Where(x => x.Count() == 3).ToList().FirstOrDefault();

            var cardsLeft = cards.Except(HandFound).ToList();

            return score(cardsLeft);
        }

        public override int getRankLevel()
        {
            var HandFound = cards.GroupBy(x => x[0])
                        .Where(x => x.Count() == 3).ToList().FirstOrDefault();

            return mapCards[HandFound.FirstOrDefault()[0]];
        }
    }
}
