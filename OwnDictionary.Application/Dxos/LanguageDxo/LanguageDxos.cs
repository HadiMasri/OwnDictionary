using AutoMapper;
using OwnDictionary.Contracts.Dtos;
using OwnDictionary.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Application.Dxos
{
    public class LanguageDxos : ILanguageDxos
    {
        private readonly IMapper _mapper;
        public LanguageDxos()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Language, LanguageDto>();
            });
            _mapper = config.CreateMapper();
        }
        public LanguageDto MapTermDto(Language language)
        {
            return _mapper.Map<Language, LanguageDto>(language);
        }
        public List<LanguageDto> MapTermDtos(IEnumerable<Language> languages)
        {
            return _mapper.Map<List<LanguageDto>>(languages);
        }
    }
}
