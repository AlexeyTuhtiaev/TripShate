using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripShareDTO
{
    public class TripWithSegments : Trip
    {
        public ICollection<Segment> Segments { get; set; }
    }
}
