using OwnDictionary.Contracts.Dtos;
using OwnDictionary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Application.Dxos
{
    public interface ILanguageDxos
    {
        LanguageDto MapTermDto(Language language);
        List<LanguageDto> MapTermDtos(IEnumerable<Language> languages);
    }
}
