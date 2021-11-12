using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Configs
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiryPeriod { get; set; } 
    }
}
