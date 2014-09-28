using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LanguageRecognition
{
    class Ukrainian:Language
    {
        public Ukrainian()
        {
            Points = 20;
            Name = "Украинский язык";
            SpecificSymbols = new char[] { 'є', 'ї' };
            UnusedSymbols = new char[] { 'э', 'ы' };
        }
        public override void FindFeatures(string text)
        {
            //int points = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'і' || text[i] == 'о') Points++;// преимущественно украинские буквы
                if (i < text.Length - 2)
                {
                    //украинские признаки
                    if (text[i] == 'ц')
                        if (text[i + 1] == 'ь' && text[i + 2] == ' ') Points++;//мягкость ць
                    if ((text[i] == 'о' || text[i] == 'е') && text[i + 1] == 'ю' && text[i + 2] == ' ') Points++;//окончания ою ею
                    if (text[i] == 'т' && text[i + 1] == 'и' && text[i + 2] == ' ') Points++;//окончания ти инфинитивов
                }
            }
            //return points;
        }
    }
}
