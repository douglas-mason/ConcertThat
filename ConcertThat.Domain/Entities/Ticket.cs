using System;

namespace ConcertThat.Domain.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public virtual Concert Concert { get; set; }
        public virtual Customer Customer { get; set; }
    }
}