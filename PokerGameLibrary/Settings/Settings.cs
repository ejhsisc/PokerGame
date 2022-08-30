using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary
{
    public class Settings
    {
        /// <summary>
        /// set ranks on cards
        /// </summary>
        public enum CardRanks
        {
            Flush = 1,
            ThreeOfAKind = 2,
            OnePair = 3,
            HighCard = 4
        }
    }
}
