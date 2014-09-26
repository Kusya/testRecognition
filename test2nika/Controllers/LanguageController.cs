using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Services.LanguageRecognition;

namespace test2nika.Controllers
{
    public class LanguageController : ApiController
    {
        private string Value { get; set; }
        // GET api/language
        public IEnumerable<string> Get()
        {
           
            return new string[] { "value1", "value2" };
        }

        // GET api/language/5
        public string Get(int data)
        {
            LanguageExpertise first = new LanguageExpertise();

            string languages = first.DetectLanguage(Value);
            return languages;
            //return "value";
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
