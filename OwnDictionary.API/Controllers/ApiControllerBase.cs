using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace OwnDictionary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;

        private IActionResult StatusCodeAndMessage(HttpStatusCode statusCode, string message)
        {
            return StatusCode((int)statusCode, new string[] { message });
        }
        public ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> ExcuteRequest<T>(IRequest<T> request)
        {
            try
            {
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (ValidationException vex)
            {

                return StatusCodeAndMessage(HttpStatusCode.BadRequest, vex.Message);
            }
            catch (Exception ex)
            {
                return StatusCodeAndMessage(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}
