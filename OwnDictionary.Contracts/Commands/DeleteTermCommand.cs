using OwnDictionary.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Contracts.Commands
{
    public class DeleteTermCommand : CommandBase<TermDto>
    {
        public Guid Id { get; set; }
    }
}
