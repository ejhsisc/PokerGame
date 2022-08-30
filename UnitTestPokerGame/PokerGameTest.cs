using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerGameLibrary;
using System;
using System.Collections.Generic;
using static PokerGameLibrary.Settings;

namespace UnitTestPokerGame
{
    [TestClass]
    public class PokerGameTest
    {

        [TestMethod]
        public void Flush()
        {
            var hand = new PokerHands();
            Player player = new Player();
            player.cards = new List<string>() { "KS", "QS", "8S", "6S", "6S" };
            player = hand.getPokerHand(player);


            //Expected
            int cardsRank = (int)CardRanks.Flush;
            int cardsScore = 399093;

            Assert.AreEqual(cardsRank, player.cardsRank);
            Assert.AreEqual(cardsScore, player.cardsScore);
        }

        [TestMethod]
        public void ThreeofKind()
        {
            var hand = new PokerHands();
            Player player = new Player();
            player.cards = new List<string>() { "KS", "QS", "6H", "6S", "6S" };
            player = hand.getPokerHand(player);


            //Expected
            int cardsRank = (int)CardRanks.ThreeOfAKind;
            int cardsScore = 181;
            int cardsRankLevel = 6;

            Assert.AreEqual(cardsRank, player.cardsRank);
            Assert.AreEqual(cardsRankLevel, player.cardsRankLevel);
            Assert.AreEqual(cardsScore, player.cardsScore);
        }

        [TestMethod]
        public void OnePair()
        {
            var hand = new PokerHands();
            Player player = new Player();
            player.cards = new List<string>() { "KS", "6H", "6S", "8H", "8S" };
            player = hand.getPokerHand(player);


            //Expected
            int cardsRank = (int)CardRanks.OnePair;
            int cardsRankLevel = 6;
            int cardsScore = 2281;

            Assert.AreEqual(cardsRank, player.cardsRank);
            Assert.AreEqual(cardsRankLevel, player.cardsRankLevel);
            Assert.AreEqual(cardsScore, player.cardsScore);
        }


        [TestMethod]
        public void HighCard()
        {
            var hand = new PokerHands();
            Player player = new Player();
            player.cards = new List<string>()
            {
                "KS", "QH", "8S", "6S", "5S"
            };
            player = hand.getPokerHand(player);


            //Expected
            int cardsRank = (int)CardRanks.HighCard;
            int cardsScore = 399092;

            Assert.AreEqual(cardsRank, player.cardsRank);
            Assert.AreEqual(cardsScore, player.cardsScore);

        }

        [TestMethod]
        public void EvaluateFlushVSThreeOfKind()
        {
            var hand = new PokerHands();
            Player player1 = new Player();
            player1.cards = new List<string>() { "KS", "QS", "8S", "6S", "6S" };
            player1 = hand.getPokerHand(player1);

            Player player2 = new Player();
            player2.cards = new List<string>() { "KS", "QS", "6H", "6S", "6S" };
            player2 = hand.getPokerHand(player2);

            //Wins Flush = to player1 = 1
            int result = hand.evaluateHands(player1, player2);

            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void EvaluateFlushVSPair()
        {
            var hand = new PokerHands();
            Player player1 = new Player();
            player1.cards = new List<string>() { "KS", "QS", "8S", "6S", "6S" };
            player1 = hand.getPokerHand(player1);

            Player player2 = new Player();
            player2.cards = new List<string>() { "KS", "KS", "6H", "6S", "6C" };
            player2 = hand.getPokerHand(player2);

            //Wins Flush = to player1 = 1
            int result = hand.evaluateHands(player1, player2);

            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void EvaluateThreeOfKindVSPair()
        {
            var hand = new PokerHands();
            Player player1 = new Player();
            player1.cards = new List<string>() { "6S", "QS", "8S", "6S", "6S" };
            player1 = hand.getPokerHand(player1);

            Player player2 = new Player();
            player2.cards = new List<string>() { "KS", "QS", "AH", "AS", "6S" };
            player2 = hand.getPokerHand(player2);

            //Wins Three = to player1 = 1
            int result = hand.evaluateHands(player1, player2);

            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void EvaluatePairVSPair()
        {
            var hand = new PokerHands();
            Player player1 = new Player("Jen: 5C, 7D, 9H, 9S, QS", 0);
            player1 = hand.getPokerHand(player1);

            Player player2 = new Player("Bob: 2H, 2C, 5S, 10C, AH", 1);
            player2 = hand.getPokerHand(player2);


            //Wins player1 = 1
            int result = hand.evaluateHands(player1, player2);

            Assert.AreEqual(1, result);
        }
   
    }
}
