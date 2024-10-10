using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerPlatform.Application.Dtos.Chat
{
    public class KeyChatViewModel
    {
        public int HubChatId { get; set; }
        public int FreelancerA { get; set; }
        public string LastNameA { get; set; }
        public string FirstNameA { get; set; }
        public int FreelancerB { get; set; }
        public string LastNameB { get; set; }
        public string FirstNameB { get; set; }
    }
}
