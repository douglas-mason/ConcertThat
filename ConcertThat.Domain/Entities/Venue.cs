using System.Collections.Generic;

namespace ConcertThat.Domain.Entities
{
    public class Venue
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual int Zip { get; set; }
        public virtual IEnumerable<Concert> ScheduledConcerts { get; set; }
    }
}