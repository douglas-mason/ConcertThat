using System;

namespace ConcertThat.Domain.Entities
{
    public class Ticket
    {
        public virtual Guid Id { get; set; }
        public virtual Concert Concert { get; set; }
        public virtual int CustomerId { get; set; }
    }
}