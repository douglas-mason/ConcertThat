using System.Collections.Generic;

namespace ConcertThat.Domain.Entities
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public virtual IEnumerable<Concert> ScheduledConcerts { get; set; }
    }
}