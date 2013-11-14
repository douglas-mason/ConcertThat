using System.Data.Entity.ModelConfiguration;
using System.Linq;
using ConcertThat.Domain.Entities;

namespace ConcertThat.Domain.Orm.Mappings
{
    public class ConcertMap : EntityTypeConfiguration<Concert>
    {
        public ConcertMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Title);
            Property(x => x.Date);
            Property(x => x.TicketCapacity);
            HasMany(x => x.TicketsSold.ToList());
            HasRequired(x => x.Venue);
        }
    }
}