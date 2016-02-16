using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml.Linq;
using Hairdresser.Models;

namespace Hairdresser.Controllers
{
    public class HairServicesController : ApiController
    {
        private HairdresserContext db = new HairdresserContext();

        // GET: api/HairServices
        public IQueryable<HairServiceDTO> GetHairServices()
        {
            var services = from b in db.HairServices
                        select new HairServiceDTO()
                        {
                            Id = b.Id,
                            ClientName = b.ClientName,
                            Date = b.Date,
                            Payment = b.Payment,
                            //Duration = b.EndTime-b.StartTime,
                            WorkerId = b.WorkerId
                        };   
            return services;
        }

        // GET: api/HairServices/5
        [ResponseType(typeof(HairServiceDetailsDTO))]
        public async Task<IHttpActionResult> GetHairService(int id)
        {    
            var hairService = await db.HairServices.Include(b => b.Worker).Select(b =>
                new HairServiceDetailsDTO()
                {
                    Id = b.Id,
                    Type = b.Type,
                    ClientName = b.ClientName,
                    Date = b.Date,
                    WorkerName = b.Worker.FirstName + " " + b.Worker.LastName,
                    StartTime = b.StartTime,
                    Payment = b.Payment,
                    //Duration = b.EndTime - b.StartTime,
                    Description = b.Description
                }).SingleOrDefaultAsync(b => b.Id == id);

            if (hairService == null)
            {
                return NotFound();
            }

            return Ok(hairService);
        }

        // PUT: api/HairServices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHairService(int id, HairService hairService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hairService.Id)
            {
                return BadRequest();
            }

            db.Entry(hairService).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HairServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/HairServices
        [ResponseType(typeof(HairService))]
        public async Task<IHttpActionResult> PostHairService(HairService hairService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HairServices.Add(hairService);
            await db.SaveChangesAsync();

            db.Entry(hairService).Reference(x => x.Worker).Load();

            var dto = new HairServiceDTO()
            {
                Id = hairService.Id,
                Date = hairService.Date,
                Payment = hairService.Payment,
                //Duration = hairService.EndTime - hairService.StartTime,
                ClientName = hairService.ClientName,
                WorkerId = hairService.WorkerId
            };

            return CreatedAtRoute("DefaultApi", new { id = hairService.Id }, dto);
        }

        // DELETE: api/HairServices/5
        [ResponseType(typeof(HairService))]
        public async Task<IHttpActionResult> DeleteHairService(int id)
        {
            HairService hairService = await db.HairServices.FindAsync(id);
            if (hairService == null)
            {
                return NotFound();
            }

            db.HairServices.Remove(hairService);
            await db.SaveChangesAsync();

            return Ok(hairService);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HairServiceExists(int id)
        {
            return db.HairServices.Count(e => e.Id == id) > 0;
        }
    }
}