using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConcertThat.Domain.Entities;
using ConcertThat.Domain.Orm;
using ConcertThat.Models;
using ConcertThat.Services;

namespace ConcertThat.Controllers
{
    public class ConcertsController : Controller
    {
        private ConcertThatDbContext _db = new ConcertThatDbContext();
        private ConcertService _concertService = new ConcertService();

        public ActionResult CreateConcert(ConcertRequestModel concertRequest)
        {
            if (!ModelState.IsValid)
                return View();
            _concertService.CreateConcert(concertRequest);
            return View("Index");
        }
        public ActionResult ConcertDetails(int concertId)
        {
            var concert = _db.Concerts.Find(concertId);
            var model = AutoMapper.Mapper.Map<ConcertRequestModel>(concert);
            model.AvailableTickets = _concertService.GetTicketAvailability(concertId);
            return View(model);
        }
    }
}
