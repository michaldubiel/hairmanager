using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using System.Security.Permissions;

namespace Hairdresser.Models
{
    public class HairService
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public double Payment { get; set; } 
        public string Description { get; set; }
        public string ClientName { get; set; }
        public int Type { get; set; }

        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
    }
}