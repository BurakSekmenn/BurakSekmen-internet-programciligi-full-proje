using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Core.Entity
{
    public class AddRoleModel
    {

        public string Email { get; set; }
 
        public string Password { get; set; }
      
        public string Role { get; set; }
    }
}
