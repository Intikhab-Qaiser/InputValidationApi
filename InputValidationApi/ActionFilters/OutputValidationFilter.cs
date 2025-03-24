using InputValidationApi.Validators;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace InputValidationApi.ActionFilters
{
    public class OutputValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var dto = objectResult.Value;
                var validator = new UserDtoValidator();
                var result = validator.Validate((Dtos.UserDto)dto);

                if (!result.IsValid)
                {
                    context.Result = new ObjectResult("Invalid output")
                    {
                        StatusCode = 500
                    };
                }
            }
        }

        /// <summary>
        /// // Generic response
        /// </summary>
        /// <param name="context"></param>
        //public void OnActionExecuted(ActionExecutedContext context)
        //{
        //    if (context.Result is ObjectResult objectResult)
        //    {
        //        var dto = objectResult.Value;
        //        var validator = new UserDtoValidator();
        //        var result = validator.Validate((Dtos.UserDto)dto);
        //        if (!result.IsValid)
        //        {
        //            context.Result = new ObjectResult("Invalid output")
        //            {
        //                StatusCode = 500
        //            };
        //        }
        //    }
        //}

        public void OnActionExecuting(ActionExecutingContext context) { }
    }
}
