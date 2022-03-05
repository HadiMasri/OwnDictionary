using MediatR;
using Microsoft.AspNetCore.Mvc;
using OwnDictionary.Contracts.Commands.LanguageCommands;
using OwnDictionary.Contracts.Commands.LanguageDictionaryCommands;
using OwnDictionary.Contracts.Dtos;
using OwnDictionary.Contracts.Queries.LanguageQueries;

namespace OwnDictionary.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ApiControllerBase
    {
        public LanguageController(IMediator mediator)
        : base(mediator)
        {

        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExcuteRequest(new GetAllLanguagesQuery());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await ExcuteRequest(new GetLanguageQuery { Id = id });

        }

        [HttpPost]
        public async Task<IActionResult> Post(AddLanguageCommand cmd)
        {
            if (cmd == null) return BadRequest();

            return await ExcuteRequest(cmd);
        }

        [HttpPut]
        public async Task<IActionResult> Update(LanguageDto languageDto)
        {
            return await ExcuteRequest(new UpdateLanguageCommand { LanguageDto = languageDto });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await ExcuteRequest(new DeleteLanguageCommand { Id = id });

        }
    }
}
