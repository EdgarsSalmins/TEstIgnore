using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightPlanner.Core.Models
{
    public class Airport : Entity
    {
        public string City { get; set; }
        public string Country { get; set; }
        [JsonPropertyName("airport")]
        public string AirportCode { get; set; }
    }
}
