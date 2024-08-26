using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DevFreela.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        // Executado depois da requisição
        public void OnActionExecuted(ActionExecutedContext context)
        {
         
        }

        // Executado antes da requisição
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var messages = context.ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                dynamic response = new { errors = messages };

                context.Result = new BadRequestObjectResult(response);
            }

        }
    }
}
