using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class ExchangeRate
    {
        public int Id { get; set; }
        public int BankaId { get; set; }
        public double Alis { get; set; }
        public double Satis { get; set; }

        public DateTime Tarih { get; set; }
    }
}
