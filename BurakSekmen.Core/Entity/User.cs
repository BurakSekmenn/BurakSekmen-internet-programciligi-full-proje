﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BurakSekmen.Core.Entity
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
