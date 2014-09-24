using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LanguageRecognition
{
    public class ILanguage
    {
        public string name;
        public int points;
        private char[] specificSymbols;
        private char[] unusedSymbols;
        private char[] vowels = new char[] { 'а', 'о', 'у', 'ы', 'э', 'я', 'ё', 'ю', 'и', 'е', 'і', 'ї', 'є' };
        public void CheckSymbols(string checkingText)
        {
            
            for (int i = 0; i < specificSymbols.Length; i++)
            {
                if (checkingText.Contains(specificSymbols[i])) points++;
            }
            for (int i = 0; i < unusedSymbols.Length; i++)
            {
                if (checkingText.Contains(unusedSymbols[i])) points--;
            }
             points *= 10;
        }
        public virtual void FindFeatures(string text)
        {
            
        }

        public bool IsWord(string text)
        {
            int vowalPersent = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (vowels.Contains(text[i]))
                {
                    vowalPersent++;
                }
            }
            float percent = text.Length / (float)vowalPersent;
            return !(percent > 0.9 || percent < 0.1);
        }
    }
}




//private char[] softVowels = new char[] {  'я', 'ё', 'ю', 'и', 'е', 'і'};
//private char[] consonants = new char[] { 'й', 'ц', 'к', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ъ', 'ф', 'в', 'п', 'р', 'л', 'д', 'ж', 'ч', 'с', 'м', 'т', 'ь', 'б', 'ў' };
//private char[] RussianFeatures = new char[] { 'ъ', 'Ъ' };
//private char[] noRussianFeatures = new char[] { '\'', 'і', 'І' };
//private char[] BelarusianFeatures = new char[] { 'ў', 'Ў' };
//private char[] noBelarusianFeatures = new char[] { 'щ', 'Щ', 'и', 'И' };
//private char[] UkrainianFeatures = new char[] { 'є', 'Є', 'Ї', 'ї' };
//private char[] noUkrainianFeatures = new char[] { 'э', 'Э', 'ы', 'Ы' };