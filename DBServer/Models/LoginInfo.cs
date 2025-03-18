using System.ComponentModel.DataAnnotations;

namespace DBServer.Models
{
    public class LoginInfo
    {
        [Key]
        public string Username { get; set; }

        public string DNAddress { get; set; }

        public string EmailId { get; set; }

        public string Password { get; set; }
    }
}
