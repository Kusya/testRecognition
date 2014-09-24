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
            ILanguage l = null;
            bool word = l.IsWord(text);
            if (!word) return null;
            var languages = new List<ILanguage>
            {
                new Belarusian(),
                new Russian(),
                new Ukrainian()
            };
            int i = 0;
            foreach (ILanguage s in languages)
            {
                s.CheckSymbols(text);
            }
            if (languagePriority.Contains(10) || languagePriority.Contains(20))
            {
                return "язык";
            }
            else
            {
                foreach (ILanguage s in languages)
                {
                    s.FindFeatures(text);
                    
                }
                //if(languagePriority.Contains(0)) то поиск по словарю
                int count = languagePriority.Sum();
                //for (int j = 0; j < 3; j++)
                //{
                //    languagePriority[j] = (languagePriority[j] / count) * 100;
                //}
                //return languagePriority;
            }
            int max = 0,j=0;
            for (i = 0; i < 3; i++)
            {
                if (languagePriority[i] > max)
                {
                    max = languagePriority[i];
                    j = i;
                }
            }
            return "языки";
        }
        

    }
}
