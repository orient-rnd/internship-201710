﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interns2.AppServices.API.Models
{
    public class GetListFilmRequest
    {
        public int Quantity { get; set; } = 100;

        public bool? IsNewest { get; set; }

        public bool? IsHighestRate { get; set; }

    }
}
