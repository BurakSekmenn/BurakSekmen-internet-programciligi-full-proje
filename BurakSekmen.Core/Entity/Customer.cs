﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Core.Entity
{
    public class Customer:BaseEntity
    {
       public string ContactName { get; set; }
       public string? CompanyName { get; set; }
       public string Address { get; set; }
       public string City { get; set; }
       public string Country { get; set; }
       public string? Phone { get; set; }
       public string? Nots { get; set;}

    }
}
