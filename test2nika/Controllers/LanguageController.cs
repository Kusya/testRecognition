using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Services.LanguageRecognition;
using test2nika.Models;
using DataAccessLayer;

namespace test2nika.Controllers
{
    public class LanguageController : ApiController
    {
        
        // GET api/language
        private DictionaryService _dictionaryService = new DictionaryService();

        public IEnumerable<LanguageDto> GetLanguage(string text) //IEnumerable<string>
        {
            if (string.IsNullOrEmpty(text) || text.Length < 3)
            {
                return null;
            }
            var dictionary = _dictionaryService.GetLanguage(text);
            if (dictionary == null)
            {

                var first = new LanguageExpertise();
                IEnumerable<Language> languages = first.DetectLanguage(text);
                
                var language = languages.OrderByDescending(x => x.Percent).First();


                _dictionaryService.AddWord(text, language.Name);
                return languages.Select(l => new LanguageDto {Name = l.Name, Percentage = l.Percent}).ToList();
            }
            else
            {
                return new List<LanguageDto>()
                {
                    new LanguageDto()
                    {
                        Name = dictionary.Language,
                        Percentage = 100
                    }
                };
            }
        }

        // GET api/language/5
        public string Get(int data)
        {
            return "value";
        }

        // POST api/language
        public void Post([FromBody]string value)
        {
        }

        // PUT api/language/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/language/5
        public void Delete(int id)
        {
        }
    }
}
