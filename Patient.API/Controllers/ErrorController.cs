using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Patient.API.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        //[Route("/detailed-Error-For-Dev")]
        //public IActionResult ErrorLocalDevelopment(
        //    [FromServices] IHostingEnvironment webHostEnvironment)
        //{
        //    if (!webHostEnvironment.IsDevelopment())
        //    {
        //        throw new InvalidOperationException(
        //            "This shouldn't be invoked in non-development environments.");
        //    }

        //    var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        //    var ex = feature?.Error;

        //    var problemDetails = new ProblemDetails
        //    {
        //        Status = (int)HttpStatusCode.InternalServerError,
        //        Instance = feature?.Path,
        //        Title = ex.GetType().Name,
        //        Detail = ex.StackTrace,
        //    };

        //    return StatusCode(problemDetails.Status.Value, problemDetails);
        //}

        [Route("/error")]
        public ActionResult Get(
            [FromServices] IHostingEnvironment webHostEnvironment)
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;
            var isDev = webHostEnvironment.IsDevelopment();
            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = feature?.Path,
                Title = isDev ? $"{ex.GetType().Name}: {ex.Message}" : "An error occurred.",
                Detail = isDev ? ex.StackTrace : null,
            };

            return StatusCode(problemDetails.Status.Value, problemDetails);
        }
    }
}
