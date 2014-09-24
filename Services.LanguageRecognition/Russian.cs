using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LanguageRecognition
{
    class Russian: ILanguage
    {
        public string name = "Русский язык";
        public int points;
        private char[] specificSymbols = new char[] { 'ъ' };
        private char[] unusedSymbols = new char[] { '\'', 'і' };
        private char[] softVowels = new char[] { 'я', 'ё', 'ю', 'и', 'е' };
        private char[] doubleLetters = new char[] { 'з', 'с', 'ц', 'ш', 'ж', 'ч', 'л' };

        public Russian()
        {
            points = 0;
        }
        public override void FindFeatures(string text)
        {
            //int points = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'л' || text[i] == 'е' || text[i] == 'ф') points++;//преимущественно русские буквы
                if (i < text.Length - 1)
                {
                    if (text[i] == 'ч' || text[i] == 'р')
                    {
                        if (softVowels.Contains(text[i + 1])) points++;//text[i + 1] == 'я' || text[i + 1] == 'ё' || text[i + 1] == 'ю' || text[i + 1] == 'и' || text[i + 1] == 'е') points++;
                    }

                    if (text[i] == 'ш' || text[i] == 'ж')
                    {
                        if (text[i + 1] == 'и') points++;//жи ши
                    }
                }
                if (i < text.Length - 2)
                {
                    if (text[i] == 'ц')
                        if (text[i + 1] == ' ') points++;//твердость ц в окончании
                    if ((text[i] == 'о' || text[i] == 'е') && text[i + 1] == 'й' && text[i + 2] == ' ') points++;//окончания на -ой, -ей
                    if (doubleLetters.Contains(text[i])) points++;//text[i] == 'з' || text[i] == 'с' || text[i] == 'ц' || text[i] == 'ш' || text[i] == 'ж' || text[i] == 'ч' || text[i] == 'л')
                    {
                        if (text[i + 1] == 'ь' && (text[i + 2] == 'е' || text[i + 2] == 'я')) points++;//-сье -шье -чья
                    }
                }
            }
           // return points;
        }
    }
}
