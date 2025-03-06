using BowlingClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingClient.Factory.FactoryModels
{
    public class BowlingMatch : IMatch
    {

        public string CalculateWinner()
        {
            throw new NotImplementedException();
        }

        public string EndMatch()
        {
            Console.WriteLine("Bowling match har avslutats.");
            return "Bowling match har avslutats.";
        }

        public string GetMatchRegler()
        {
            Console.WriteLine("Bowling regler : BowlingRegler, BowlingRegler, BowlingRegler, BowlingRegler, BowlingRegler ");
            return "Bowling regler : BowlingRegler, BowlingRegler, BowlingRegler, BowlingRegler, BowlingRegler ";
        }

        MatchDto IMatch.StartMatch(int accountId, int bookingId)
        {
            Console.WriteLine("Bowling match startar");
            Console.WriteLine("Välj ett bowling namn för din match: ");
            string bowlingMatchName = Console.ReadLine();

            int antalSpelare = 0;
            while (true)
            {
                Console.WriteLine("Välj hur många spelare som ska vara med (1-4): ");
                if (int.TryParse(Console.ReadLine(), out antalSpelare) && antalSpelare >= 1 && antalSpelare <= 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltigt antal spelare! Ange ett tal mellan 1 och 4.");
                }
            }

            Console.WriteLine($"Du har valt {antalSpelare} spelare.");

            List<string> playerNames = new List<string>();

            for (int i = 1; i <= antalSpelare; i++)
            {
                Console.WriteLine($"Ange namn för spelare {i}: ");
                string playerName = Console.ReadLine();
                playerNames.Add(playerName);
            }

            Console.WriteLine($"\nMatch: {bowlingMatchName}");
            Console.WriteLine("Spelare:");
            foreach (var playerName in playerNames)
            {
                Console.WriteLine($"- {playerName}");
            }

            return new MatchDto
            {
                MatchName = bowlingMatchName,
                AccountId = accountId,
                BookingSlotId = bookingId,
                PlayerNames = playerNames
            };
        }
    }
}
