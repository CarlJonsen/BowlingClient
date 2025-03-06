using BowlingClient.Manager;
using BowlingClient.ModelsDto;

namespace UseAPI
{
    internal class Program
    {

        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            AccountManager accountManager = new AccountManager();
            MatchManager matchManager = new MatchManager();
            AccountDto loggedInAccount = null;
            bool isLoggedIn = false;

            while (!isLoggedIn)
            {
                Console.Clear();
                Console.WriteLine("1. Skapa konto");
                Console.WriteLine("2. Logga in");
                Console.WriteLine("3. Avsluta");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    loggedInAccount = await accountManager.CreateNewAccountAsync();
                }
                else if (choice == "2")
                {
                    loggedInAccount = await accountManager.LogInAccountAsync();
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Avslutar programmet...");
                    return;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    continue;
                }

                if (loggedInAccount != null && !string.IsNullOrEmpty(loggedInAccount.Username))
                {
                    isLoggedIn = true;
                    Console.Clear();
                    Console.WriteLine($"Hej och välkommen {loggedInAccount.Username}! {loggedInAccount.Message}");
                }
                else
                {
                    Console.WriteLine("Inloggningen misslyckades eller kontot kunde inte skapas. Försök igen.");
                    Console.WriteLine("Tryck på valfri tangent för att försöka igen...");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Boka ny match");
                Console.WriteLine("2. Se historik");
                Console.Write("Välj ett alternativ (1 eller 2): ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    await matchManager.BookNewMatchAsync(loggedInAccount.Id);
                    break;
                }
                else if (choice == "2")
                {
                    await matchManager.GetMatchHistoryAsync(loggedInAccount.Id);
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen. Endast 1 eller 2 är tillåtet.");
                    Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                    Console.ReadKey();
                }
            }
        }

    }

}
