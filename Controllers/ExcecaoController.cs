using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMYSQL.Controllers
{
    [ApiExplorerSettings(IgnoreApi =true)]//<-ignorando a API existente
    public class ExcecaoController : ControllerBase
    {
        [Route("/error")]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(detail: exceptionHandlerFeature.Error.StackTrace,
                                title: exceptionHandlerFeature.Error.Message);
        }
    }
}
