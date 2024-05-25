using BurakSekmen.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Core.Services
{
    public interface IResponseService
    {
        ResponseAjax HandleSuccess(string message);
        ResponseAjax HandleSuccessData(string message, object data = null);
        ResponseAjax HandleError(string message);
    }
}
