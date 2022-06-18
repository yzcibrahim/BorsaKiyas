using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Banka
    {
        public int Id { get; set; }
       
        public string Ad { get; set; }
        public string Url { get; set; }
    }
}
