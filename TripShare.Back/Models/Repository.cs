using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripShare.Back.Models
{
    public class Repository
    {
        private List<Trip> MyTrips = new List<Trip>
        {
            new Trip
            {
                Id = 1,
                Name = ".NET Summit",
                StartDate = new DateTime(2019, 5, 25),
                EndDate = new DateTime(2019, 5, 28)
            },
            new Trip
            {
                Id = 2,
                Name = "Relaxation Trip",
                StartDate = new DateTime(2019, 6, 15),
                EndDate = new DateTime(2019, 6, 28)
            },
            new Trip
            {
                Id = 3,
                Name = "Student Trip",
                StartDate = new DateTime(2019, 8, 05),
                EndDate = new DateTime(2019, 10, 29)
            }
        };

        public List<Trip> Get()
        {
            return MyTrips;
        }

        public Trip Get(int id)
        {
            return MyTrips.First(t => t.Id == id);
        }

        public void Add(Trip newTrip)
        {
            MyTrips.Add(newTrip);
        }

        public void Update(Trip tripToUpdate)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == tripToUpdate.Id));
            MyTrips.Add(tripToUpdate);
        }

        public void Delete(int id)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == id));
        }
    }
}
