using OwnDictionary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Contracts.Dtos
{
    public class SynonymDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static SynonymDto MapToDto(Synonym s)
        {
            SynonymDto dto = new SynonymDto()
            {
                Name = s.Name,
            };
            return dto;
        }
    }
}
