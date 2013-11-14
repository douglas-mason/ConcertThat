using System.Data.Entity;
using ConcertThat.Domain.Entities;

namespace ConcertThat.Domain.Orm
{
    public class ConcertThatDbContext : DbContext
    {
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}