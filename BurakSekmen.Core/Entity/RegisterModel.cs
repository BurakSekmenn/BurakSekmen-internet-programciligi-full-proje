using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Core.Entity
{
    public class RegisterModel
    {
        //Configuration
        [Key] // Birincil anahtar olarak belirlenen özellik
        public int Id { get; set; }
        public string FirstName { get; set; }
   
        public string LastName { get; set; }
   
        public string UserName { get; set; }
   
        public string Email { get; set; }
     
        public string Password { get; set; }
    }
}
