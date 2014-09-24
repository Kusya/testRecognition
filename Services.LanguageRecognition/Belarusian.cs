﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LanguageRecognition
{
    class Belarusian:ILanguage
    {
        private char[] specificSymbols = new char[] { 'ў' };
        private char[] unusedSymbols = new char[] { 'щ', 'и' };
        private char[] mostBelLettere = new char[] { 'а', 'я', 'ц', 'ы' };
        private char[] hardVowels = new char[] { 'а', 'о', 'у', 'ы', 'э' };
        private char[] doubleLetters = new char[] { 'з', 'с', 'ц', 'ш', 'ж', 'ч', 'л' };
        public override int FindFeatures(string text,int temp)
        {
            //int temp = 0;
            if (text.Contains("дз") || text.Contains("дж")) temp += 10;
            for (int i = 0; i < text.Length; i++)
            {
                if (mostBelLettere.Contains(text[i])) temp++;//text[i] == 'а' || text[i] == 'я' || text[i] == 'ц' || text[i] == 'ы') temp++;//преимущественно белорусские буквы
                if (i < text.Length - 1)
                {
                    //белорусские признаки
                    if (text[i] == 'ч' || text[i] == 'р')
                        if (hardVowels.Contains(text[i + 1])) temp++;// == 'а' || text[i + 1] == 'о' || text[i + 1] == 'у' || text[i + 1] == 'ы' || text[i + 1] == 'э') temp++;//твердость ч и р                       
                    if ((text[i] == 'і' || text[i] == 'ы') && text[i + 1] == ' ') temp++;//окончания на и, ы
                    if (text[i] == 'ш' || text[i] == 'ж')
                        if (text[i + 1] == 'ы') temp++;//жы шы
                }
                if (i < text.Length - 2)
                {
                    //и еще немного руско-белоруских
                    if (doubleLetters.Contains(text[i])) temp++;// == 'з' || text[i] == 'с' || text[i] == 'ц' || text[i] == 'ш' || text[i] == 'ж' || text[i] == 'ч' || text[i] == 'л')
                    if (text[i + 1] == text[i]) temp++;//удвоенные согласные
                }
            }
            return temp;
        }
    }
}
