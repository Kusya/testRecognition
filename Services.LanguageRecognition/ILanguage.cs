using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LanguageRecognition
{
    class ILanguage
    {
        private char[] specificSymbols;
        private char[] unusedSymbols;
        private char[] vowels = new char[] { 'а', 'о', 'у', 'ы', 'э', 'я', 'ё', 'ю', 'и', 'е', 'і', 'ї', 'є' };
        public int CheckSymbols(string checkingText)
        {
            int temp = 0;
            for (int i = 0; i < specificSymbols.Length; i++)
            {
                if (checkingText.Contains(specificSymbols[i])) temp++;
            }
            for (int i = 0; i < unusedSymbols.Length; i++)
            {
                if (checkingText.Contains(unusedSymbols[i])) temp--;
            }
            return temp;
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