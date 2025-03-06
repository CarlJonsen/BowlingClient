using BowlingClient.Factory.FactoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingClient.Factory
{
    public class MatchFactory
    {

        public enum MatchType
        {
            Bowling,
            Dart,
            PingPong
        }
        public IMatch CreateMatch(MatchType matchType)
        {
            switch (matchType)
            {
                case MatchType.Bowling:
                    return new BowlingMatch();
                case MatchType.Dart:
                    return new DartMatch();
                case MatchType.PingPong:
                    return new PingPongMatch();
                default:
                    throw new ArgumentException("Ogiltig matchtyp");
            }
        }
    }
}
