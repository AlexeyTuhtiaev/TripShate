using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripShare.Back.Models;

namespace TripShare.Back.Controllers
{
    [Route("api/[controller]")]
    public class TripController : Controller
    {
        private Repository _repository;

        public TripController(Repository repo)
        {
            _repository = repo;
        }
       
        // GET api/values
        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            return _repository.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Trip Get(int id)
        {
           return _repository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Trip newTriptrip)
        {
            _repository.Add(newTriptrip);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Trip tripToUpdate)
        {
            _repository.Update(tripToUpdate);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
