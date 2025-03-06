using BowlingClient.Models;

namespace BowlingClient.ModelsDto
{
    public class AccountDto : ErrorResponeDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
