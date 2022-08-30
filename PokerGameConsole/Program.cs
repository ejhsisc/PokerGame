using PokerGameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameConsole
{
    class Program
    {
        public static List<string> players = new List<string>();
        public Program()
        {

            players.Add("Joe: 2S, 6C, 6S, 6H, AS");
            players.Add("Bob: 5S, 5S, 5C, KH, KS");
            players.Add("Sally: AC, KC, 3C, QC, 8C");
        
            players.Add("Joe: QD, 8D, KD, 7D, 3D");
            players.Add("Bob: AS, QS, 8S, 6S, 4S");
            players.Add("Sally: 4S, 4H, 3H, QC, 8C");

        }
        static void Main(string[] args)
        {

            //try
            //{
                new Program();
                PokerHands PlayerHands = new PokerHands();
                PlayerHands.reviewWinners(players);
            //}
            //catch (Exception e)
            //{

            //    throw new Exception();
            //}
        }
    }
}
