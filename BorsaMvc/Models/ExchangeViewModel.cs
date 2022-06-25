using CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BorsaMvc.Models
{
    public class ExchangeViewModel
    {
        public List<ExchangeRate> exchangeRates{ get; set; }

        public List<BankaViewModel> bankas { get; set; }
    }
}
