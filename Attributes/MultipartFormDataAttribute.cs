using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace navdata.attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MultipartFormDataAttribute : ActionFilterAttribute {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var request = context.HttpContext.Request;

            if (request.HasFormContentType && request.ContentType.StartsWith("multipart/form-data", StringComparison.OrdinalIgnoreCase)){
                return;
            }

            context.Result = new StatusCodeResult(StatusCodes.Status415UnsupportedMediaType);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            
        }
    }
    
}