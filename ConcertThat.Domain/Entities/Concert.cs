using System;
using System.Collections.Generic;

namespace ConcertThat.Domain.Entities
{
    public class Concert
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int TicketCapacity { get; set; }
        public bool? Canceled { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual IEnumerable<Ticket> TicketsSold { get; set; }
    }
}