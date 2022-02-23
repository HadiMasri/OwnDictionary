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
        public string Synonym { get; set; }
        public string Example { get; set; }


        public static TermDto MapToDto(Term t)
        {
            TermDto dto = new TermDto()
            {
                Id = t.Id,
                Word = t.Word,
                Description = t.Description,
                Synonym = t.Synonym,
                Example = t.Example
            };
            return dto;
        }
    }


}
