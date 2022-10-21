using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency
{
    public class TravelAgencyContext : DbContext
    {

        public DbSet<TravelPackage> TravelPackages { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db_travel_agency;Integrated Security=True");
        }
    }
}
