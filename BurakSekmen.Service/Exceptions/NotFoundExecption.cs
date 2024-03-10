using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Service.Exceptions
{
    public class NotFoundExecption:Exception
    {
        public NotFoundExecption(string message) : base(message)
        {

        }
    }
}
