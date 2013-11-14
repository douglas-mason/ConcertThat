using System.Data.Entity.ModelConfiguration;
using ConcertThat.Domain.Entities;

namespace ConcertThat.Domain.Orm.Mappings
{
    public class ConcertMap : EntityTypeConfiguration<Concert>
    {
        public ConcertMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Title);
            Property(x => x.AvailableTickets);
            Property(x => x.TicketsSold);
            HasRequired(x => x.Venue);
        }
    }
}