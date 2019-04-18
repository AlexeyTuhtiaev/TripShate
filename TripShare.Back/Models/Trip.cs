using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripShare.Back.Models
{
    public class Trip : TripShareDTO.Trip
    {
        public virtual ICollection<Segment> Segments { get; set; }
    }
}
