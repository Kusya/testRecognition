using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LanguageRecognition
{
    public class LanguageExpertise
    {

        private readonly char[] vowels = { 'а', 'о', 'у', 'ы', 'э', 'я', 'ё', 'ю', 'и', 'е', 'і', 'ї', 'є' };

        private readonly List<Language> languages = new List<Language> { new Belarusian(), new Russian(), new Ukrainian() };

        private int summPoints;
        private int Maximum { get; set; }

        public IEnumerable<Language> DetectLanguage(string text)
        {
            text = text.ToLower();
            var languagePriority = new int[3];

            if (!IsWord(text)) return null;
            CalculatePoints(text);
            foreach (Language language in languages)
            {
                language.Percent = (language.Points*100) / summPoints;
            }
            return languages;
        }

        private void CalculatePoints(string text)
        {            
            foreach (Language s in languages)
            {
                s.CheckSymbols(text);
                s.FindFeatures(text);
                summPoints += s.Points;
            }
        }    
        private bool IsWord(string text)
        {
            int vowalPersent = text.Count(t => vowels.Contains(t));
            float percent = (float)vowalPersent / text.Length;
            return !(percent > 0.9 || percent < 0.1);
        }
    }
    
}
