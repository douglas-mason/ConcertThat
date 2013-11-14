using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConcertThat.Models;
using ConcertThat.Services;

namespace ConcertThat.Controllers.Api
{
    public class ConcertsController : ApiController
    {
        private readonly ConcertService _concertService = new ConcertService();

        public HttpResponseMessage GetAvailability(int concertId)
        {
            try
            {
                int availableTickets = _concertService.GetTicketAvailability(concertId);
                return Request.CreateResponse(HttpStatusCode.OK, availableTickets);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }


        public HttpResponseMessage PostSellTicket(int concertId, int customerId)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                _concertService.SellTicket(concertId, customerId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        public HttpResponseMessage PostNewConcert(ConcertRequestModel concertRequest)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                _concertService.CreateConcert(concertRequest);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        public HttpResponseMessage PostScheduleConcert(int concertId, DateTime scheduledDate)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                _concertService.UpdateScheduleDateTime(concertId, scheduledDate);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        public HttpResponseMessage PostCancelConcert(int concertId)
        {
            try
            {
                _concertService.CancelConcert(concertId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}