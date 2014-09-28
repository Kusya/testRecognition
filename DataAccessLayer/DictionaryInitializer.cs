using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class DictionaryInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            GetCategories().ForEach(c => context.DictionaryModels.Add(c));
        }

        private static List<DictionaryModel> GetCategories()
        {
            var categories = new List<DictionaryModel> {
                new DictionaryModel
                {
                    DictionaryId = 1,
                    Word = "работа",
                    Language = "Russian"
                },
                new DictionaryModel
                {
                    DictionaryId = 2,
                    Word = "праца",
                    Language = "Belarusian"
                },
                new DictionaryModel
                {
                    DictionaryId = 3,
                    Word = "здохнути",
                    Language = "Ukranian"
                }
            };
            return categories;
        }
    }
}
