using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingClient.Models;

namespace BowlingClient.Factory.FactoryModels
{
    public interface IMatch
    {
        public MatchDto StartMatch(int accountId, int bookingId);
        public string EndMatch();
        public string GetMatchRegler();

        public string CalculateWinner();

    }
}
