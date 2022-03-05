using OwnDictionary.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Contracts.Commands.LanguageCommands
{
    public class UpdateLanguageCommand : CommandBase<LanguageDto>
    {
        public LanguageDto LanguageDto { get; set; }
    }
}
