using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CommonLib
{
    public class BorsaResponse
    {
        public List<string> ErrorMessages { get; set; } = new List<string>();

        public StatusCodeResult Res { get; set; }

    }
}
