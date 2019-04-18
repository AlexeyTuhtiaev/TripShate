using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripShare.Back.Models
{
    public class TripWithSegments :TripShareDTO.Trip
    {
        public ICollection<Segment> Segments { get; set; }
    }
}
