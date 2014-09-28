using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LanguageRecognition
{
    class Belarusian:Language
    {
        private char[] mostBelLettere = new char[] { 'а', 'я', 'ц', 'ы' };
        private char[] hardVowels = new char[] { 'а', 'о', 'у', 'ы', 'э' };
        private char[] doubleLetters = new char[] { 'з', 'с', 'ц', 'ш', 'ж', 'ч', 'л' };

        public Belarusian()
        {
            Points = 20;
            Name = "Белорусский язык";
            SpecificSymbols = new [] { 'ў' };
            UnusedSymbols = new [] { 'щ', 'и' };
        }
        public override void FindFeatures(string text)
        {
            //int points = 0;
            if (text.Contains("дз") || text.Contains("дж")) Points += 10;
            for (int i = 0; i < text.Length; i++)
            {
                if (mostBelLettere.Contains(text[i])) Points++;//text[i] == 'а' || text[i] == 'я' || text[i] == 'ц' || text[i] == 'ы') points++;//преимущественно белорусские буквы
                if (i < text.Length - 1)
                {
                    //белорусские признаки
                    if (text[i] == 'ч' || text[i] == 'р')
                        if (hardVowels.Contains(text[i + 1])) Points++;// == 'а' || text[i + 1] == 'о' || text[i + 1] == 'у' || text[i + 1] == 'ы' || text[i + 1] == 'э') points++;//твердость ч и р                       
                    if ((text[i] == 'і' || text[i] == 'ы') && text[i + 1] == ' ') Points++;//окончания на и, ы
                    if (text[i] == 'ш' || text[i] == 'ж')
                        if (text[i + 1] == 'ы') Points++;//жы шы
                }
                if (i < text.Length - 2)
                {
                    //и еще немного руско-белоруских
                    if (doubleLetters.Contains(text[i])) Points++;// == 'з' || text[i] == 'с' || text[i] == 'ц' || text[i] == 'ш' || text[i] == 'ж' || text[i] == 'ч' || text[i] == 'л')
                    if (text[i + 1] == text[i]) Points++;//удвоенные согласные
                }
            }
            //return points;
        }
    }
}
