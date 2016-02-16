using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hairdresser.Models
{
    public class HairServiceDTO
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int WorkerId { get; set; }
        public DateTime Date { get; set; }
        public double Payment { get; set; }
        //public TimeSpan Duration { get; set; }
    }
}