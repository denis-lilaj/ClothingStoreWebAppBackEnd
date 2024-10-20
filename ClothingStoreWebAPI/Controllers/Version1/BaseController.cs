using Application;
using Application.Models;
using ClothingStoreWebAPI.Common;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreWebAPI.Controllers.Version1
{
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleErrorResponse(List<Error> errors)
        {
            var apiError = new ErrorResponse();

            if (errors.Any(e => e.Code == ErrorCodes.NotFound))
            {
                var error = errors.FirstOrDefault(e => e.Code == ErrorCodes.NotFound);
                apiError.StatusCode = (int)ErrorCodes.NotFound;
                apiError.StatusPhase = "Not Found";
                apiError.TimeStamp = DateTime.Now;
                apiError.Errors.Add(error.Message);

                return NotFound(apiError);
            }

            apiError.StatusCode = (int)ErrorCodes.ServerError;
            apiError.StatusPhase = "Internal Server Error";
            apiError.TimeStamp = DateTime.Now;
            apiError.Errors.Add("Unknown Error");
            return StatusCode(500, apiError);
        }

    }
}
   

