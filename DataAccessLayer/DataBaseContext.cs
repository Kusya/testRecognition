using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
            : base("LanguageDictionary")
    {
    }
        public DbSet<DictionaryModel> DictionaryModels { get; set; } 
    }
}
