using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LanguageRecognition
{
    class LanguageExpertise
    {
        public int[] Main(string text)
        {
            text = text.ToLower();
            int[] languagePriority = new int[3];
            ILanguage l = null;
            int vowal = l.VowalsContant(text);
            if (vowal * 10 > 9 || vowal * 10 < 1) return null;
            System.Collections.Generic.List<ILanguage> languages = new System.Collections.Generic.List<ILanguage>();
            languages.Add(new Belarusian());
            languages.Add(new Russian());
            languages.Add(new Ukrainian());
            int i = 0;
            foreach (ILanguage s in languages)
            {
                languagePriority[i]= s.CheckSymbols(text);
                i++;
            }
            if (languagePriority.Contains(10) || languagePriority.Contains(20))
            {
                int count = languagePriority.Sum();
                for (int j = 0; j < 3; j++)
                {
                    languagePriority[j] = (languagePriority[j] / count) * 100;
                }
                return languagePriority;
            }
            else
            {
                foreach (ILanguage s in languages)
                {
                    languagePriority[i] = s.FindFeatures(text, languagePriority[i]);
                    i++;
                }
                //if(languagePriority.Contains(0)) то поиск по словарю
                int count = languagePriority.Sum();
                for (int j = 0; j < 3; j++)
                {
                    languagePriority[j] = (languagePriority[j] / count) * 100;
                }
                return languagePriority;
            }
            //int[] temp = f.CheckLenguageFeatures(text,languagePriority);
            return null;
        }
        

    }
}
