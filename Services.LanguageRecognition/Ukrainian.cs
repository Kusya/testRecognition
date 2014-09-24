using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LanguageRecognition
{
    class Ukrainian:ILanguage
    {
        private char[] specificSymbols = new char[] { 'є', 'ї' };
        private char[] unusedSymbols = new char[] { 'э', 'ы' };

        public override int FindFeatures(string text, int temp)
        {
            //int temp = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'і' || text[i] == 'о') temp++;// преимущественно украинские буквы
                if (i < text.Length - 2)
                {
                    //украинские признаки
                    if (text[i] == 'ц')
                        if (text[i + 1] == 'ь' && text[i + 2] == ' ') temp++;//мягкость ць
                    if ((text[i] == 'о' || text[i] == 'е') && text[i + 1] == 'ю' && text[i + 2] == ' ') temp++;//окончания ою ею
                    if (text[i] == 'т' && text[i + 1] == 'и' && text[i + 2] == ' ') temp++;//окончания ти инфинитивов
                }
            }
            return temp;
        }
    }
}
