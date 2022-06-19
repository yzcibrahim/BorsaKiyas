using CommonLib;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BorsaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExhangeController : ControllerBase
    {
        BorsaDbContext _context;
        public ExhangeController(BorsaDbContext context)
        {
            _context = context;

        }
        // GET: api/<ExhangeController>
        [HttpGet]
        public IEnumerable<ExchangeRate> Get()
        {
            //  return _context.Set<ExchangeRate>().ToList();
            return _context.ExchangeRates.ToList();
        }

        // GET api/<ExhangeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExhangeController>
        [HttpPost]
        public void Post([FromBody] ExchangeRate value)
        {
            _context.ExchangeRates.Add(value);
            _context.SaveChanges();
        }

        // PUT api/<ExhangeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExhangeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
