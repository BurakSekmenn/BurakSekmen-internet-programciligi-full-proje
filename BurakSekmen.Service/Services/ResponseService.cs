using BurakSekmen.Core.Enums;
using BurakSekmen.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Service.Services
{
    public class ResponseService : IResponseService
    {
        public ResponseAjax HandleError(string message)
        {
            return new ResponseAjax(false, message);
        }

        public ResponseAjax HandleSuccess(string message)
        {
            return new ResponseAjax(true, message);
        }

        public ResponseAjax HandleSuccessData(string message, object data = null)
        {
            return new ResponseAjax(true, message, data);
        }
    }
}
