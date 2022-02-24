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
        public IEnumerable<Synonym>? Synonyms { get; set; }
        public IEnumerable<Example> Examples { get; set; }

        public void Update(string word, string description, IEnumerable<Synonym> synonyms, IEnumerable<Example> examples)
        {
            this.Word = word;
            this.Description = description;
            this.Synonyms = synonyms;
            this.Examples = examples;
        }
    }
}
