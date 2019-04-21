using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TripShare.Back.Models;
using TripShare.UI.Data;
using TripShare.UI.Services;

namespace TripShare.UI.Pages.Trips
{
    public class IndexModel : PageModel
    {
        private readonly IApiClient _Client;

        public IndexModel(IApiClient client)
        {
            _Client = client;
        }

        public IList<Trip> Trips { get;set; }

        public async Task OnGetAsync()
        {
            Trips = await _Client.GetTripsAsync();
        }
    }
}
