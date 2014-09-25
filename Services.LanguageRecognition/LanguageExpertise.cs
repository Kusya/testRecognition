using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LanguageRecognition
{
    public class LanguageExpertise
    {
        public string DetectLanguage(string text)
        {
            text = text.ToLower();
            var languagePriority = new int[3];
            var l = new ILanguage();
            bool word = l.IsWord(text);
            if (!word) return null;
            var languages = new List<ILanguage>
            {
                new Belarusian(),
                new Russian(),
                new Ukrainian()
            };
            int max = -20;
            string lang = null;
            foreach (ILanguage s in languages)
            {
                s.CheckSymbols(text);
                if (s.Points > max)
                {
                    max = s.Points;
                    lang = s.Name;
                }
            }
            if (max>10)
            {
                return lang;
            }
            else
            {
                //if(languagePriority.Contains(0)) то поиск по словарю
                foreach (ILanguage s in languages)
                {
                    s.FindFeatures(text);
                    if (s.Points > max)
                    {
                        max = s.Points;
                        lang = s.Name;
                    }
                }
            }
            return lang;
        }
    }
}
