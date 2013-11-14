using AutoMapper;
using ConcertThat.Domain.Entities;
using ConcertThat.Domain.Orm;
using ConcertThat.Models;

namespace ConcertThat.Mappings
{
    public class ConcertMapping : Profile
    {
        public Venue ResolveVenue(int venueId)
        {
            var db = new ConcertThatDbContext();
            return db.Venues.Find(venueId);
        }

        protected override void Configure()
        {
            CreateMap<ConcertRequestModel, Concert>()
                .ForMember(c => c.Venue, o => o.MapFrom(crm => ResolveVenue(crm.VenueId.Value)));
            CreateMap<Concert, ConcertRequestModel>()
                .ForMember(crm => crm.AvailableTickets, o => o.Ignore())
                .ForMember(crm => crm.AvailableVenues, o => o.Ignore())
                .ForMember(crm => crm.VenueId, o => o.MapFrom(c => c.Venue.Id));
        }
    }
}