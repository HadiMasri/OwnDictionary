using OwnDictionary.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Contracts.Commands.LanguageDictionaryCommands
{
    public class AddLanguageCommand : CommandBase<LanguageDto>
    {
        public string Name { get; set; }
    }
}
