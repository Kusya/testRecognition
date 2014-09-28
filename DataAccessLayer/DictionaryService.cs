using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DictionaryService
    {
        private readonly DataBaseContext db = new DataBaseContext();

        public DictionaryModel GetLanguage(string text)
        {
            return db.DictionaryModels.FirstOrDefault(d => d.Word == text);
        }

        public void AddWord(string word, string language)
        {
            var dictionary = new DictionaryModel()
            {
                Language = language,
                Word = word
            };
            db.DictionaryModels.Add(dictionary);
            db.SaveChanges();
        }


    }
}
