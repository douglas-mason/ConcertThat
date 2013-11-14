using System.Data.Entity.ModelConfiguration;
using System.Linq;
using ConcertThat.Domain.Entities;

namespace ConcertThat.Domain.Orm.Mappings
{
    public class VenueMap : EntityTypeConfiguration<Venue>
    {
        public VenueMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Name);
            Property(x => x.Street);
            Property(x => x.City);
            Property(x => x.State);
            Property(x => x.Zip);
            HasMany(x => x.ScheduledConcerts.ToList());
        }
    }
}