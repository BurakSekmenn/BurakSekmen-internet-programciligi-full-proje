using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Core.Enums
{
    public class ResponseAjax
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ResponseAjax(bool success, string message, object data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        // Başarılı yanıt kısayolu
        public static ResponseAjax SuccessResponse(string message)
        {
            return new ResponseAjax(true, message);
        }

        // Başarılı yanıt kısayolu
        public static ResponseAjax SuccessResponseData(string message, object data = null)
        {
            return new ResponseAjax(true, message, data);
        }

        // Hata yanıtı kısayolu
        public static ResponseAjax ErrorResponse(string message)
        {
            return new ResponseAjax(false, message);
        }
    }
}
