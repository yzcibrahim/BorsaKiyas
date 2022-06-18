using CommonLib;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BorsaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankaController : ControllerBase
    {
        private readonly BorsaDbContext _context;
        public BankaController(BorsaDbContext context)
        {
            _context = context;
        }

        // GET: api/<BankaController>
        [HttpGet]
        public IEnumerable<Banka> Get()
        {
            return _context.Bankalar.ToList();
        }

        // GET api/<BankaController>/5
        [HttpGet("{id}")]
        public Banka Get(int id)
        {
            return _context.Find<Banka>(id); 
        }

        // POST api/<BankaController>
        [HttpPost]
        public BorsaResponse Post([FromBody] Banka value)
        {
            
            if(String.IsNullOrWhiteSpace(value.Ad))
            {
                BorsaResponse resp = new BorsaResponse();

                resp.ErrorMessages.Add("Ad boş olamaz!");
                resp.Res = new BadRequestResult();
                return resp;
            }

            if (value.Id <= 0)
            {
                _context.Bankalar.Add(value);
            }
            else
            {
                _context.Bankalar.Attach(value);
                _context.Entry<Banka>(value).State = EntityState.Modified;
            }
                _context.SaveChanges();
            return new BorsaResponse() { Res = new OkResult() };
        }

        // PUT api/<BankaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //_context.Bankalar
        }

        // DELETE api/<BankaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var silinecek = _context.Find<Banka>(id);
            _context.Bankalar.Remove(silinecek);
            _context.SaveChanges();
        }
    }
}
