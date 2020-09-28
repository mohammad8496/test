using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace TestUtils.Utils
{
    /// <summary>
    /// Used to Automatically Validats all models before Action Executing
    /// </summary>
    public class ValidationActionFilter : ActionFilterAttribute
    {
        private ILogger<ValidationActionFilter> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public ValidationActionFilter(ILogger<ValidationActionFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Called by ASP Engine before Action Executing
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var modelState = context.ModelState;
            _logger.LogTrace("Checking Model Validation of {Model}", modelState);

            if (!context.ModelState.IsValid)
            {
                var result = new BadRequestObjectResult(context.ModelState);
                context.Result = result;
                _logger.LogDebug("Model is invalid: {Model}, error: {error}", modelState, result.Value);
            }
        }
    }
}
