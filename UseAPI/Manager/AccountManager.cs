using BowlingClient.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using BowlingClient.Models;

namespace BowlingClient.Manager
{
    public class AccountManager
    {
        private static string baseUrl = "https://localhost:7134/Account/";
        private readonly ApiClient _apiClient;
        public AccountManager()
        {
            _apiClient = new ApiClient();
        }

        public async Task<AccountDto> StartMatchChoiceAsync(string choice)
        {
            switch (choice)
            {
                case "1":
                    return await CreateNewAccountAsync();

                case "2":
                    return await LogInAccountAsync();

                default:
                    Console.WriteLine("Ogiltigt val. Vänligen ange 1 eller 2.");
                    return new AccountDto { Message = "Ogiltigt val. Försök igen." };
            }
        }

        public async Task<AccountDto> LogInAccountAsync()
        {
            Console.WriteLine("Vänligen ange användarnamn: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Vänligen ange lösenord: ");
            string password = Console.ReadLine();

            var account = new AccountDto { Username = userName, Password = password };
            string requestUrl = baseUrl + "login";
            return await _apiClient.PostAsync<AccountDto, AccountDto>(requestUrl, account);
        }

        public async Task<AccountDto> CreateNewAccountAsync()
        {
            Console.WriteLine("Användarnamn: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Lösenord: ");
            string password = Console.ReadLine();

            var newAccount = new AccountDto { Username = userName, Password = password };
            string requestUrl = baseUrl + "create";
            return await _apiClient.PostAsync<AccountDto, AccountDto>(requestUrl, newAccount);
        }
    }
}
