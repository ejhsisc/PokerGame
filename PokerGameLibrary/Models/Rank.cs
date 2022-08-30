using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary
{
    /// <summary>
    /// Class to inherit with ranks
    /// </summary>
    public abstract class Rank
    {
        public List<string> cards = null;

        public int cardsRank { get; set; }
      
        /// <summary>
        /// Mapper, cards to numbers
        /// </summary>
        public readonly IDictionary<char, int> mapCards = new Dictionary<char, int> {
            {'2',2}, {'3',3}, {'4',4}, {'5',5}, {'6',6}, {'7',7}, {'8',8}, {'9',9}, {'T',10}, {'J',11}, {'Q',12}, {'K',13}, {'A',14}
        };

        /// <summary>
        /// initialize
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="cardsRank"></param>
        public Rank(List<string> cards, int cardsRank)
        {
            this.cards = cards;
            this.cardsRank = cardsRank;
        }

        /// <summary>
        /// get rank level, Number for the three of a Kind or pair.
        /// </summary>
        /// <returns></returns>
        public virtual int getRankLevel()
        {
            return 0;
        }

        /// <summary>
        /// score
        /// </summary>
        /// <returns></returns>
        public virtual int cardToScore()
        {
            return score(cards);
        }

        /// <summary>
        /// Score given to cards, to identify winner when is the same card rank or level rank. 
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public virtual int score(List<string> cards)
        {
            cards = cards.OrderByDescending(x => mapCards[x[0]]).ToList();

            return cards.Select((x, ind) => 
            mapCards[x[0]] * Convert.ToInt32(Math.Pow(13,(cards.Count-1)-ind))).Sum();
        }

        /// <summary>
        /// Identify if the rank apply
        /// </summary>
        /// <returns></returns>
        public abstract bool isRuleComplete();

    }
}
