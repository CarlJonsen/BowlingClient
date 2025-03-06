using BowlingClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingClient.Factory.FactoryModels
{
    public class PingPongMatch : IMatch
    {

        public string CalculateWinner()
        {
            throw new NotImplementedException();
        }

        public string EndMatch()
        {
            Console.WriteLine("PingPong match har avslutats");
            return "PingPong match har avslutats.";
        }

        public string GetMatchRegler()
        {
            Console.WriteLine("PingPong regler : PingPong regler");
            return "PingPong regler : PingPong regler";
        }

        MatchDto IMatch.StartMatch(int accountId, int bookingId)
        {
            Console.WriteLine("PingPong match startar...");
            return new MatchDto { };
        }
    }
}
