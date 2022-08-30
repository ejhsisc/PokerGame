using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary
{
    /// <summary>
    /// If two or more players hold a single pair, then highest pair wins
    /// </summary>
    public class OnePair : Rank
    {
        public OnePair(List<string> cards, int cardsRank) : base(cards, cardsRank) { }

        public override bool isRuleComplete()
        {
             return cards.GroupBy(x => x[0] ).Where(x=>x.Count()==2).Count()>=1;
        }

        public override int cardToScore()
        {
            cards = cards.OrderByDescending(x => mapCards[x[0]]).ToList();

            var PairsFound = cards.GroupBy(x => x[0])
                        .Where(x => x.Count() == 2).ToList().FirstOrDefault();

            var cardsLeft = cards.Except(PairsFound).ToList();

            cardsLeft = cardsLeft.OrderByDescending(x => mapCards[x[0]]).ToList();
            return score(cardsLeft);
        }

        public override int getRankLevel()
        {
            var PairsFound = cards.GroupBy(x => x[0])
                        .Where(x => x.Count() == 2).ToList().FirstOrDefault();

            return mapCards[PairsFound.FirstOrDefault()[0]];
        }
    }
}
