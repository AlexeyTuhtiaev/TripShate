﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TripShare.Back.Models;
using TripShare.UI.Data;

namespace TripShare.UI.Pages.Trips
{
    public class DetailsModel : PageModel
    {
        private readonly TripShare.UI.Data.ApplicationDbContext _context;

        public DetailsModel(TripShare.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Trip Trip { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trip = await _context.Trip.SingleOrDefaultAsync(m => m.Id == id);

            if (Trip == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}