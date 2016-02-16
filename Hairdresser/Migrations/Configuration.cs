using Hairdresser.Models;

namespace Hairdresser.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Hairdresser.Models.HairdresserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Hairdresser.Models.HairdresserContext context)
        {
            context.Workers.AddOrUpdate(x => x.Id,
                new Worker()
                {
                    Id = 1,
                    FirstName = "Katie",
                    LastName = "Poulsen"
                },
                new Worker()
                {
                    Id = 2,
                    FirstName = "Katie",
                    LastName = "Poulsen"
                },
                new Worker()
                {
                    Id = 3,
                    FirstName = "Katie",
                    LastName = "Poulsen"
                }
            );

            context.HairServices.AddOrUpdate(x => x.Id,
                new HairService
                {
                    WorkerId = 1,
                    ClientName = "Anna Smith",
                    Type = 1,
                    Date = DateTime.Today,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddHours(1),
                    Description = "hs1"
                },
                new HairService
                {
                    WorkerId = 2,
                    ClientName = "Anna Smith",
                    Type = 1,
                    Date = DateTime.Today,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddHours(1),
                    Description = "hs2"
                },
                new HairService
                {
                    WorkerId = 3,
                    ClientName = "Anna Smith",
                    Type = 1,
                    Date = DateTime.Today,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddHours(1),
                    Description = "hs3"
                });

            
        }
    }
}
