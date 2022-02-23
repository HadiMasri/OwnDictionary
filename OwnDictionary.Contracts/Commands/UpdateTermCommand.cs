using OwnDictionary.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Contracts.Commands
{
    public class UpdateTermCommand : CommandBase<TermDto>
    {
        public TermDto TermDto { get; set; }
    }
}
