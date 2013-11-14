using System.Data.Entity.ModelConfiguration;
using ConcertThat.Domain.Entities;

namespace ConcertThat.Domain.Orm.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            HasKey(x => x.Id);
            Property(x => x.FirstName);
            Property(x => x.LastName);
        }
    }
}