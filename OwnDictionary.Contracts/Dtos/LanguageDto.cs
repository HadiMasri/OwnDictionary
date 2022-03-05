using OwnDictionary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Contracts.Dtos
{
    public class LanguageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Term>? Terms { get; set; }

        public static LanguageDto MapToDto(Language x)
        {
            LanguageDto dto = new LanguageDto()
            {
                Name = x.Name,
            };
            return dto;
        }
    }
}
