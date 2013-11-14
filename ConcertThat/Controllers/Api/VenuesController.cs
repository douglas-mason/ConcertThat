using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConcertThat.Domain.Entities;
using ConcertThat.Domain.Orm;

namespace ConcertThat.Controllers.Api
{
    public class VenuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Venue> Get()
        {
            var db = new ConcertThatDbContext();
            var model = db.Venues;
            return model;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}