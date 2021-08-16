using System;
using FlightPlanner.Core.Interfaces;

namespace FlightPlanner.Core.Models
{
    public class Flight : Entity
    {
        public string Carrier { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public virtual Airport From { get; set; }

        public virtual Airport To { get; set; }
    }
}
