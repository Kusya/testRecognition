using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Services.LanguageRecognition;
using test2nika.Models;

namespace test2nika.Controllers
{
    public class LanguageController : ApiController
    {
        private string Value { get; set; }
        // GET api/language
        public IEnumerable<LanguageDto> GetLynx(string text) //IEnumerable<string>
        {
            var first = new LanguageExpertise();
            IEnumerable<Language> languages = first.DetectLanguage(text);
            return languages.Select(l => new LanguageDto {Name = l.Name, Percentage = l.Percent}).ToList();
        }

        // GET api/language/5
        public string Get(int data)
        {
            return "value";
        }

        // POST api/language
        public void Post([FromBody]string value)
        {
            this.Value = value;
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
