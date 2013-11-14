using System.Data.Entity.ModelConfiguration;
using ConcertThat.Domain.Entities;

namespace ConcertThat.Domain.Orm.Mappings
{
    public class TicketMap : EntityTypeConfiguration<Ticket>
    {
        public TicketMap()
        {
            HasKey(x => x.Id);
            HasRequired(x => x.Concert);
            HasRequired(x => x.Customer);
        }
    }
}