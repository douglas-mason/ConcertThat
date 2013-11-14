using System;
using System.Linq;
using AutoMapper;
using ConcertThat.Domain.Entities;
using ConcertThat.Domain.Orm;
using ConcertThat.Models;

namespace ConcertThat.Services
{
    public class ConcertService
    {
        private readonly ConcertThatDbContext _db = new ConcertThatDbContext();

        public void CreateConcert(ConcertRequestModel concertRequest)
        {
            try
            {
                var concertToCreate = Mapper.Map<Concert>(concertRequest);
                _db.Concerts.Add(concertToCreate);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error creating new concert", e);
            }
        }
        public int GetTicketAvailability(int concertId)
        {
            // Calling count should be optimized as EF will query SQL Server like Count(*)
            // rather than get all elements and then count them.
            var numberOfTicketsAvailable = _db.Concerts.Find(concertId).TicketsSold.Count();
            return numberOfTicketsAvailable;
        }
        public void SellTicket(int concertId, int customerId)
        {
            try
            {
                var concert = _db.Concerts.Find(concertId);
                var isTicketAvailableToPurchase = (concert.TicketCapacity - concert.TicketsSold.Count()) > 0;
                if (isTicketAvailableToPurchase)
                {
                    _db.Tickets.Add(new Ticket
                                       {
                                           Concert = concert,
                                           Customer = _db.Customers.Find(customerId)
                                       });
                    _db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Error selling ticket for concert id: {0}", concertId), e);
            }
        }
        public void CancelConcert(int concertId)
        {
            try
            {
                var concert = _db.Concerts.Find(concertId);
                concert.Canceled = true;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Error canceling concert id: {0}", concertId), e);
            }
        }
        public void UpdateScheduleDateTime(int concertId, DateTime newDate)
        {
            try
            {
                var concert = _db.Concerts.Find(concertId);
                concert.Date = newDate;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Error updateing date and time for concert id: {0}", concertId), e);
            }
        }
    }
}