using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HairSchedule.Models;

namespace HairSchedule.Controllers
{
    public class HairServicesController : ApiController
    {
        HairService[] services = new HairService[]
        {
            new HairService
            {
                Id = 1,
                WorkerId = 1,
                ClientName = "Anna Smith",
                Type = 1,
                Date = DateTime.Today,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                Description = "hs1"
            },
            new HairService {
                Id = 2,
                WorkerId = 1,
                ClientName = "Anna Smith",
                Type = 1,
                Date = DateTime.Today,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                Description = "hs2"
            },
            new HairService {
                Id = 3,
                WorkerId = 1,
                ClientName = "Anna Smith",
                Type = 1,
                Date = DateTime.Today,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                Description = "hs3"
            }
        };

        public IEnumerable<HairService> GetAllProducts()
        {
            return services;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var service = services.FirstOrDefault((p) => p.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }
    }
}
