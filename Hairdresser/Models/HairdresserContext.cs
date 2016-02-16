using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hairdresser.Models
{
    public class HairdresserContext : DbContext
    {   
        public HairdresserContext() : base("name=HairdresserContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<Hairdresser.Models.HairService> HairServices { get; set; }

        public System.Data.Entity.DbSet<Hairdresser.Models.Worker> Workers { get; set; }
    }
}
