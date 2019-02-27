using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseTesting
{
    public class User
    {
        public Guid id { get; set; }
        public Location Location { get; set; }
        public DateTime RegisterTime { get; set; }
        public string DeviceId { get; set; }
        public DateTime LastActivity { get; set; }
        public bool IsBanned { get; set; }
        public string PhoneNumber { get; set; }

    }
    public class Location
    {
        public string Lat { get; set; }
        public string Lan { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
