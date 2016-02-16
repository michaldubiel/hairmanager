using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hairdresser.Models
{
    public class HairServiceDetailsDTO
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public double Payment { get; set; }
        public string ClientName { get; set; }
        public string WorkerName { get; set; }
        public DateTime Date { get; set; }
        //public TimeSpan Duration { get; set; }
        public DateTime StartTime { get; set; }
        public string Description { get; set; }
    }
}