using System;
using System.Security.AccessControl;
using System.Security.Permissions;

namespace HairSchedule.Models
{
    public class HairService
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string ClientName { get; set; }
        public int Type { get; set; }         
    }
}