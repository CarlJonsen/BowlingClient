using BowlingClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingClient.Factory.FactoryModels
{
    public class DartMatch : IMatch
    {

        public string CalculateWinner()
        {
            throw new NotImplementedException();
        }

        public string EndMatch()
        {
            Console.WriteLine("Dart match har avslutats.");
            return "Dart match har avslutats.";
        }

        public string GetMatchRegler()
        {
            Console.WriteLine("Dart regler : DartRegler");
            return "Dart regler : DartRegler";
        }

        MatchDto IMatch.StartMatch(int accountId, int bookingId)
        {
            Console.WriteLine("Dart match startar...");
            return new MatchDto { };
        }
    }
}
