﻿using BurakSekmen.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Core.Repository
{
    public interface IUserRepository 
    {
        Task<string> RegisterAsync(RegisterModel model);
        Task<AuthenticationModel> GetTokenAsync(Token model);

        Task<string> AddRoleAsync(AddRoleModel model);
       
    }
}
