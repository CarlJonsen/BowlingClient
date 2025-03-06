
using BowlingClient.Factory;
using BowlingClient.Factory.FactoryModels;
using BowlingClient.Models;
using BowlingClient.ModelsDto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BowlingClient.Manager
{
    public class MatchManager
    {
        private static string baseUrl = "https://localhost:7134";
        private readonly ApiClient _apiClient;
        private MatchFactory _matchFactory;
        private BookingManager _bookingManager;
        public MatchManager()
        {
            _apiClient = new ApiClient();
            _matchFactory = new MatchFactory();
            _bookingManager = new BookingManager();
        }

        public async Task BookNewMatchAsync(int accountId)
        {
            Console.Clear();
            await _bookingManager.GetAvailableBookingsAsync();
            Console.WriteLine("Vänligen välj ett Id: ");
            int bookingSlotId = int.Parse(Console.ReadLine());

            await _bookingManager.BookSlotAsync(bookingSlotId);
            Console.WriteLine($"Din tid är bokad:{bookingSlotId}.");
            Console.Clear();

            Console.Clear();
            Console.WriteLine("Välj matchtyp:");
            Console.WriteLine("1. Bowling");
            Console.WriteLine("2. Dart");
            Console.WriteLine("3. PingPong");

            if (int.TryParse(Console.ReadLine(), out int matchChoice) && matchChoice >= 1 && matchChoice <= 3)
            {
                MatchFactory.MatchType selectedMatchType = (MatchFactory.MatchType)(matchChoice - 1);
                IMatch match = _matchFactory.CreateMatch(selectedMatchType);


                MatchDto matchDto = match.StartMatch(accountId, bookingSlotId);

                Console.WriteLine("Klicka enter för att starta matchen.");
                Console.ReadLine();
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(".");
                    await Task.Delay(500);
                }

                string requestUrl = $"{baseUrl}/CreateMatch";
                var response = await _apiClient.PostAsync<MatchDto, MatchDto>(requestUrl, matchDto);
                Console.Clear();
                Console.WriteLine("Vinnaren av matchen är : " + response.WinnerName + "!");

            }
            else
            {
                Console.WriteLine("Ogiltigt val. Vänligen välj mellan 1 och 3.");
            }
        }

        public async Task GetMatchHistoryAsync(int accountId)
        {
            string requestUrl = $"{baseUrl}/Account/matchHistory?accountId={accountId}";
            var matchHistory = await _apiClient.GetAsync<MatchDto>(requestUrl);

            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                await Task.Delay(500);
            }

            if (matchHistory.Count > 0)
            {
                Console.WriteLine("Matchhistorik:\n");
                foreach (var match in matchHistory)
                {
                    Console.WriteLine($"Match: {match.MatchName}\nVinnare: {match.WinnerName}\nDatum: {match.BookingTime}");

                    if (match.PlayerNames != null && match.PlayerNames.Count > 0)
                    {
                        Console.WriteLine("Spelare:");
                        foreach (var player in match.PlayerNames)
                        {
                            Console.WriteLine($"- {player}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Inga spelare registrerade för denna match.");
                    }

                    Console.WriteLine("\n------------------------------------------------------------------------------------\n");
                }
            }
            else
            {
                Console.WriteLine("Ingen matchhistorik hittades för angivet konto.");
            }
        }
    }
}
