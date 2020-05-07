using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using theWorld.Models;

namespace theWorld.Controllers
{
    public class CountryController : ApiController
    {
        public IEnumerable<Country> Get()
        {
            return null;
        }
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("api/country/GetCountry/{name}")]
        public List<Country> GetCountry(string name)
        {
            Country c = new Country();
            return c.Read(name);
        }

        [HttpPut]
        [Route("api/country/update")]
        public void update([FromBody]Country country)
        {
            country.updateDB(country);
        }

        [HttpGet]
        [Route("api/country/GetContinent/{continent}")]
        public List<Country> GetContinent(string continent)
        {
            Country c = new Country();
            return c.getContinent(continent);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5 
        public void Put(int id, [FromBody]string value)
        { }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}