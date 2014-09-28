using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LanguageRecognition
{
    public class Language
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int Percent { get; set; }
        public char[] SpecificSymbols { get; set; }
        public char[] UnusedSymbols { get; set; }


        public void CheckSymbols(string checkingText)
        {
            
            foreach (char symbol in SpecificSymbols)
            {
                if (checkingText.Contains(symbol))
                {
                    Points+=10;
                }
            }
            foreach (char symbol in UnusedSymbols)
            {
                if (checkingText.Contains(symbol))
                {
                    Points-=10;
                }
            }
        }
        public virtual void FindFeatures(string text)
        {}
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