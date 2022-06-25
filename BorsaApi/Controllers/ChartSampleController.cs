using DataLayer;
using DataLayer.Entities;
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
    public class ChartSampleController : ControllerBase
    {
        BorsaDbContext _context;
        public ChartSampleController(BorsaDbContext context)
        {
            _context = context;
        }
        // GET: api/<ChartSampleController>
        [HttpGet]
        public IEnumerable<ChartTestLine> Get()
        {
            return _context.ChartTestLines.ToList();
        }

        // GET api/<ChartSampleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChartSampleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ChartSampleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChartSampleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
