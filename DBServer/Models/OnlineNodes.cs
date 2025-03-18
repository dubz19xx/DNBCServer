using System.ComponentModel.DataAnnotations;

namespace DBServer.Models
{
    public class OnlineNodes
    {
        [Key]
        public string DNAddress { get; set; }

        public string IPAddress { get; set; }

        public int Port { get; set; }
    }
}
