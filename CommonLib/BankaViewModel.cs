
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommonLib
{
    public class BankaViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Ad { get; set; }

        [Required]
        //[UrlValidation]
        [Url]
        public string Url { get; set; }
    }
}
