namespace ConcertThat.Domain.Entities
{
    public class Concert
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual int AvailableTickets { get; set; }
        public virtual int TicketsSold { get; set; }
    }
}