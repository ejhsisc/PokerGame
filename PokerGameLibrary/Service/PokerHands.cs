using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PokerGameLibrary.Settings;

namespace PokerGameLibrary
{
    public class PokerHands
    {
        public List<Player> winners = new List<Player>();
        public Player player = new Player();

        public PokerHands() { }
        public List<Rank> getRanks(List<string> cards)
        {
            // Add ranks to review for each hand starting from the highest
            return new List<Rank>
            {
                new Flush(cards,(int)CardRanks.Flush),
                new ThreeOfKind(cards,(int)CardRanks.ThreeOfAKind),
                new OnePair(cards,(int)CardRanks.OnePair),
                new HighCard(cards,(int)CardRanks.HighCard)
            };
        }

        /// <summary>
        /// get the maximum possible hand with the cards 
        /// </summary>
        /// <param name="player"></param>
        /// <returns>returns player with cards rank, level and score</returns>
        public Player getPokerHand(Player player)
        {
            List<Rank> ranks = getRanks(player.cards);

            //if its first hand set to max ranks and review all
            if(this.player.cardsRank==0)
                this.player.cardsRank = ranks.Count;

            player.cardsRank = ranks.Count;
            for (int i = 0; i < ranks.Count; i++)
            {
                //validate if the rule apply
                bool ruleComplete = ranks[i].isRuleComplete();
                if (ruleComplete)
                {
                    //if applies, set rank, level rank, and score
                    player.cardsRank = ranks[i].cardsRank;
                    player.cardsRankLevel = ranks[i].getRankLevel();
                    player.cardsScore = ranks[i].cardToScore();
                    break;
                }

                //evaluate previous player rank vs actual, if previous rank is bigger, break.
                if (ranks[i].cardsRank >= this.player.cardsRank )
                    break;
            }

            return player;
        }

        /// <summary>
        /// Evaluate each hand from the 2 players and returns the highest hand
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns>1 = player 1 wins</returns>
        /// <returns>2 = player 2 wins</returns>
        /// <returns>3 = draw </returns>
        public int evaluateHands(Player player1, Player player2)
        {
            //Evaluate if player 2 has a better hand
            if (player2.cardsRank < player1.cardsRank)
                return 2;
            //Evaluate if its the same card rank (flush, pair etc)
            else if (player2.cardsRank == player1.cardsRank)
            {
                //evaluate if player2 has highest pair, the rank level its the value with the pair or three of a kind
                if (player2.cardsRankLevel > player1.cardsRankLevel)
                    return 2;
                //evaluate if the have the same value with the pair
                else if (player2.cardsRankLevel == player1.cardsRankLevel)
                {
                    //if it's the same both win
                    if (player2.cardsScore == player1.cardsScore)
                        return 3;
                    //if player 2 has a better score then thats the best hand
                    else if (player2.cardsScore > player1.cardsScore)
                        return 2;
                }
            }

            // if no condition applys then player 1 has best hand
            return 1;
        }

        /// <summary>
        /// Review all the list of players
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public List<Player> reviewWinners(List<string> players)
        {

            Player nextPlayer;

            for (int i = 0; i < players.Count; i++)
            {
                //get player
                nextPlayer = new Player(players[i], i);

                //set max possible hand
                nextPlayer = getPokerHand(nextPlayer);

                //evaluate vs next player
                int result = evaluateHands(player, nextPlayer);

                if (result == 2)
                {
                    winners.Clear();
                    player = nextPlayer;
                    winners.Add(player);
                }else if (result==3)
                {
                    winners.Add(nextPlayer);
                }
            }

            return winners;
        }

    }

}
