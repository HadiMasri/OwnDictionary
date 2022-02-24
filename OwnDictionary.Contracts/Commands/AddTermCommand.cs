using FluentValidation;
using OwnDictionary.Contracts.Dtos;
using OwnDictionary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Contracts.Commands
{
    public class AddBookCommandValidator : AbstractValidator<AddTermCommand>
    {
        public AddBookCommandValidator()
        {
            //Include(baseRequestValidators);
            RuleFor(x => x.Word).NotEmpty();
        }
    }

    public class AddTermCommand : CommandBase<TermDto>
    {
        public string Word { get; set; }
        public string Description { get; set; }
        public IEnumerable<Synonym> Synonym { get; set; }
        public IEnumerable<Example> Examples { get; set; }
    }
}
