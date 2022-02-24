
using Microsoft.EntityFrameworkCore;
using OwnDictionary.Data.Extentions;
using OwnDictionary.Models.Entities;

namespace OwnDictionary.Data
{
    public class OwnDictionaryDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Synonym> Synonyms { get; set; }
        public DbSet<Example> Examples { get; set; }

        public OwnDictionaryDbContext(DbContextOptions<OwnDictionaryDbContext> options)
           : base(options)
        {

        }

        public void SaveChangesAsync()
        {
            this.AddAuditInfo();
             base.SaveChanges();
        }
    }
}