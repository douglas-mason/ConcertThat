using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ConcertThat.Domain.Entities;
using ConcertThat.Domain.Orm;

namespace ConcertThat.Controllers.Api
{
    public class TicketsController : ApiController
    {
        private ConcertThatDbContext db = new ConcertThatDbContext();

        // GET api/Tickets
        public IEnumerable<Ticket> GetTickets()
        {
            return db.Tickets.AsEnumerable();
        }

        // GET api/Tickets/5
        public Ticket GetTicket(Guid id)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return ticket;
        }

        // PUT api/Tickets/5
        public HttpResponseMessage PutTicket(Guid id, Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != ticket.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(ticket).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Tickets
        public HttpResponseMessage PostTicket(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, ticket);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = ticket.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Tickets/5
        public HttpResponseMessage DeleteTicket(Guid id)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Tickets.Remove(ticket);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ticket);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}