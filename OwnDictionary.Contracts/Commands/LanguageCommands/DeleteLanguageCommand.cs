using OwnDictionary.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Contracts.Commands.LanguageCommands
{
    public class DeleteLanguageCommand : CommandBase<LanguageDto>
    {
        public Guid Id { get; set; }
    }
}
