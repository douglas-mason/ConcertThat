using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ConcertThat.Domain.Entities;
using ConcertThat.Domain.Orm;

namespace ConcertThat.Models
{
    public class ConcertRequestModel
    {
        private ConcertThatDbContext db = new ConcertThatDbContext();

        [Required, Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Date")]
        public DateTime? Date { get; set; }
        [Required, Display(Name = "Ticket Capacity")]
        public int TicketCapacity { get; set; }
        public int? AvailableTickets { get; set; }
        public int? VenueId { get; set; }
        [Display(Name = "Available Venues")]
        public IEnumerable<Venue> AvailableVenues
        {
            get
            {
                return db.Venues.ToList();
            }
        }
    }
}