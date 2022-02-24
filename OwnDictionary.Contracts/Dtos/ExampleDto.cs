using OwnDictionary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Contracts.Dtos
{
    public class ExampleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static ExampleDto MapToDto(Example x)
        {
            ExampleDto dto = new ExampleDto()
            {
                Name = x.Name,
            };
            return dto;
        }
    }
}
