using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripShare.Back.Data;
using TripShareDTO;
using Trip = TripShare.Back.Models.Trip;

namespace TripShare.Back.Controllers
{
    [Route("api/[controller]")]
    public class TripController : Controller
    {
        private TripContext _context;

        public TripController(TripContext context)
        {
            _context = context;
        }

        // GET api/Trips
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var trips = await _context.Trips
                .AsNoTracking()
                .Include(t => t.Segments)
                .Select(t =>
                    new TripWithSegments
                    {
                        Id = t.Id,
                        Name = t.Name,
                        StartDate = t.StartDate,
                        EndDate = t.EndDate,
                        Segments = t.Segments.ToList<Segment>()
                    })
                .ToListAsync();
            return Ok(trips);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TripWithSegments Get(int id)
        {
            return _context.Trips.Select(t =>
                    new TripWithSegments
                    {
                        Id = t.Id,
                        Name = t.Name,
                        StartDate = t.StartDate,
                        EndDate = t.EndDate,
                        Segments = t.Segments.ToList<Segment>()
                    })
                .SingleOrDefault(t => t.Id == id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Trip newTriptrip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Trips.Add(newTriptrip);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody]Trip tripToUpdate)
        {
            if (_context.Trips.Find(id) == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Trips.Update(tripToUpdate);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tripToDelete = _context.Trips.Find(id);
            if (tripToDelete == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(tripToDelete);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
