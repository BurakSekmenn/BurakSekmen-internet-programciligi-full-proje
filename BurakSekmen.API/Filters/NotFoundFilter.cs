using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BurakSekmen.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }



        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
           var idvalue = context.ActionArguments.Values.FirstOrDefault();

           if (idvalue == null)
           {
               await next.Invoke();
               return;
           }
           var id = (int)idvalue;

           var anyEntity = await _service.AnyAsync(x => x.Id == id);


           if (anyEntity)
           {
                await next.Invoke();
                return;
           }

           context.Result = new NotFoundObjectResult(CustomeResponseDto<NoContentDto>.Fail($"{typeof(T).Name}({id}) Not Found", 404));


           throw new NotImplementedException();


        }


    }
}
