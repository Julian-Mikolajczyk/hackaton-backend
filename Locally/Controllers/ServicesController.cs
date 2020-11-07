using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Locally.Models;

namespace Locally.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly _2019SBDContext _context;

        public ServicesController(_2019SBDContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public ActionResult<IEnumerable<Service>> GetService(float LocationX, float LocationY)
        {
            return Ok(_context.Service.ToList().OrderBy(service => /*new { V = */distance(LocationX, LocationY, service.LocationX, service.LocationY, 'K') /*}*/));
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _context.Service.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        // PUT: api/Services/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, Service service)
        {
            if (id != service.Id)
            {
                return BadRequest();
            }

            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Services
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service)
        {
            _context.Service.Add(service);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServiceExists(service.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetService", new { id = service.Id }, service);
        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Service>> DeleteService(int id)
        {
            var service = await _context.Service.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Service.Remove(service);
            await _context.SaveChangesAsync();

            return service;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchService(int id, int userId, int toApprove)
        {

            var service = await _context.Service.FindAsync(id);

            if ((service).PreApprovedUserId == null && (service).UserOwner == userId)
            {
                service.PreApprovedUserId = toApprove;
            }
            if ((service).PreApprovedUserId != null && (service).UserOwner != userId)
            {
                service.UserContractor = userId;
            }
            if (service == null)
            {
                return NotFound();
            }
            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();


        }


        [HttpGet("{id}/review")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _context.Review.Where(review => review.ServiceId == id).FirstAsync();

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }


        [HttpPost("{id}/review")]
        public async Task<ActionResult<Service>> PostReview(Review review)
        {
            _context.Review.Add(review);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReviewExists(review.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReview", new { id = review.Id }, review);
        }
        [HttpPut("{id}/review")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return NoContent();
        }
        [HttpGet("{id}/messages")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages(int id)
        {
            return await _context.Message.Where(x => x.ServiceId == id).ToListAsync();
        }
        [HttpPost("{id}/messages")]
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
            _context.Message.Add(message);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MessageExists(message.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMessage", new { id = message.Id }, message);
        }




        private bool ServiceExists(int id)
        {
            return _context.Service.Any(e => e.Id == id);
        }
        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.Id == id);
        }
        private bool MessageExists(int id)
        {
            return _context.Message.Any(e => e.Id == id);
        }
        private double distance(float lat1, float lon1, float lat2, float lon2, char unit)
        {
            float theta = lon1 - lon2;
            float dist = (float)(Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta)));
            dist = (float)Math.Acos(dist);
            dist = rad2deg(dist);
            dist = (float)(dist * 60 * 1.1515);

            if (unit == 'K')
            {
                dist = (float)(dist * 1.609344);
            }
            else if (unit == 'N')
            {
                dist = (float)(dist * 0.8684);
            }

            return (dist);

        }
        private float deg2rad(float deg)
        {

            return (float)(deg * Math.PI / 180.0);

        }
        private float rad2deg(float rad)
        {

            return (float)(rad / Math.PI * 180.0);
        }
    }

}
