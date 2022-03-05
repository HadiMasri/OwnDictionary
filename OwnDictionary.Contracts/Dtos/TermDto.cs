using OwnDictionary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Contracts.Dtos
{
    public class TermDto
    {
        public Guid Id { get; set; }
        public string Word { get; set; }
        public string Description { get; set; }
        public Guid LanguageId { get; set; }
        public IEnumerable<Synonym> Synonyms { get; set; }
        public IEnumerable<Example> Examples { get; set; }


        public static TermDto MapToDto(Term t)
        {
            TermDto dto = new TermDto()
            {
                Id = t.Id,
                Word = t.Word,
                Description = t.Description,
                Synonyms = t.Synonyms,
                Examples = t.Examples
            };
            return dto;
        }
    }


}
