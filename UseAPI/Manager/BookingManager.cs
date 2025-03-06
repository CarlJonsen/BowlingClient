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
    public class BookingManager
    {
        private static string baseUrl = "https://localhost:7134";
        private readonly ApiClient _apiClient;
        public BookingManager()
        {
            _apiClient = new ApiClient();
        }

        public async Task<List<BookingSlotDto>> GetAvailableBookingsAsync()
        {
            string requestUrl = baseUrl + "/availableBookings";
            var result = await _apiClient.GetAsync<BookingSlotDto>(requestUrl);

            if (result.Count == 0)
            {
                Console.WriteLine("Inga lediga bokningar hittades.");
            }
            else
            {
                Console.WriteLine($"Hittade {result.Count} lediga bokningar.");
                foreach (var booking in result)
                {
                    Console.WriteLine($"Id: {booking.Id}\nBana: {booking.LaneName}\nTid: {booking.BookingTime}\n");
                }
            }

            return result;
        }

        public async Task<BookingSlotDto> BookSlotAsync(int chosenId)
        {
            BookingSlotDto bookingSlotDto = new BookingSlotDto();
            bookingSlotDto.Id = chosenId;

            string requestUrl = baseUrl + "/bookSlot";
            return await _apiClient.PostAsync<BookingSlotDto, BookingSlotDto>(requestUrl, bookingSlotDto);
        }
    }
}
