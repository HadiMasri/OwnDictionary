using MediatR;
using Microsoft.AspNetCore.Mvc;
using OwnDictionary.Contracts.Commands;
using OwnDictionary.Contracts.Dtos;
using OwnDictionary.Contracts.Queries;

namespace OwnDictionary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermController : ApiControllerBase
    {
        public TermController(IMediator mediator)
          : base(mediator)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post(AddTermCommand cmd)
        {
            if (cmd == null) return BadRequest();

            return await ExcuteRequest(cmd);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExcuteRequest(new GetAllTermsQuery());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await ExcuteRequest(new GetTermQuery { Id = id });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await ExcuteRequest(new DeleteTermCommand { Id = id });

        }

        [HttpPut]
        public async Task<IActionResult> Update(TermDto termDto)
        {
            return await ExcuteRequest(new UpdateTermCommand { TermDto = termDto });
        }
    }
}
