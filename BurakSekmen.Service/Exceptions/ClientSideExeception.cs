using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Service.Exceptions
{
    public class ClientSideExeception:Exception
    {
        public ClientSideExeception(string message) : base(message)
        {

        }
    }
}
