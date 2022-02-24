using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Models.Entities
{
    public class Synonym : BaseAuditableEntity
    {
        public string Name { get; set; }
        public Guid? TermId { get; set; }
    }
}
