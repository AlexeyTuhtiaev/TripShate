using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TripShare.Back.Models;

namespace TripShare.Back.Data
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) : base(options)
        {

        }

        public TripContext()
        {
        }
        public DbSet<Trip> Trips { get; set; }



        public static void SeedDate(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<TripContext>();

                context.Database.EnsureCreated();

                if (context.Trips.Any())
                {
                    return;
                }

                context.Trips.AddRange
                (
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
                );
                context.SaveChanges();
            }
        }
    }
}
