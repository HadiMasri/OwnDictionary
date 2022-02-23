using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Models.Entities
{
    public class Term : BaseAuditableEntity
    {
        public string Word { get; set; }
        public string Description { get; set; }
        public string Synonym { get; set; }
        public string Example { get; set; }

        public void Update(string word, string description, string synonym, string example)
        {
            this.Word = word;
            this.Description = description;
            this.Synonym = synonym;
            this.Example = example;
        }
    }
}
