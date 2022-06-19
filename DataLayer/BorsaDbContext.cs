using CommonLib;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BorsaDbContext:DbContext
    {
        public BorsaDbContext(DbContextOptions <BorsaDbContext> options):base(options)
        {

        }

        public DbSet<Banka> Bankalar { get; set; }

        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}
