using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Models.Entities
{
    public class Language : BaseAuditableEntity
    {
        public string Name { get; set; }
        public IEnumerable<Term>? Terms { get; set; }
        
        public void Update(string name)
        {
            this.Name = name;
        }
    }

}
