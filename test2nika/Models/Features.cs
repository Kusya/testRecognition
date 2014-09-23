using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test2nika.Models
{
    public class Features
    {
        private char[] vowels = new char[] { 'а', 'о', 'у', 'ы', 'э', 'я', 'ё', 'ю', 'и', 'е', 'і', 'ї', 'є' };
        //private char[] softVowels = new char[] {  'я', 'ё', 'ю', 'и', 'е', 'і'};
        //private char[] consonants = new char[] { 'й', 'ц', 'к', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ъ', 'ф', 'в', 'п', 'р', 'л', 'д', 'ж', 'ч', 'с', 'м', 'т', 'ь', 'б', 'ў' };
        private char[] RussianFeatures = new char[] { 'ъ', 'Ъ' };
        private char[] noRussianFeatures = new char[] { '\'', 'і', 'І' };
        private char[] BelarusianFeatures = new char[] { 'ў', 'Ў' };
        private char[] noBelarusianFeatures = new char[] { 'щ', 'Щ', 'и', 'И' };
        private char[] UkrainianFeatures = new char[] { 'є', 'Є', 'Ї', 'ї' };
        private char[] noUkrainianFeatures = new char[] { 'э', 'Э', 'ы', 'Ы' };
        private int[] features;
        public  Features()
        {
            features = new int[3];
        }
        public int CheckBelSymbols(string checkingText)
        {
            int temp=0;
            for (int i = 0; i < BelarusianFeatures.Length; i++)
            {
                if (checkingText.Contains(BelarusianFeatures[i])) temp++;
            }
            if(checkingText.Contains("дз")||checkingText.Contains("дж")) temp++;
            
            for (int i = 0; i < noBelarusianFeatures.Length; i++)
            {
                if (checkingText.Contains(noBelarusianFeatures[i])) temp--;
            }
             return temp;
        }
        public int[] CheckLenguageFeatures(string text,int[] features)
        {
            
            for(int i=0; i<text.Length; i++)
            {
                if (text[i] == 'а' || text[i] == 'я' || text[i] == 'ц'  || text[i] == 'ы') features[0]++;//преимущественно белорусские буквы
                else if (text[i] == 'і' || text[i] == 'о') features[2]++;// украинские буквы
                else if (text[i] == 'л' || text[i] == 'е' || text[i] == 'ф') features[1]++;//русские буквы
                if (i < text.Length - 1)
                {
                    //белорусские признаки
                    if (text[i] == 'ч' || text[i] == 'р')
                    {
                        if (text[i + 1] == 'а' || text[i + 1] == 'о' || text[i + 1] == 'у' || text[i + 1] == 'ы' || text[i + 1] == 'э') features[0]++;//твердость ч и р
                        else if (text[i + 1] == 'я' || text[i + 1] == 'ё' || text[i + 1] == 'ю' || text[i + 1] == 'и' || text[i + 1] == 'е') features[1]++;
                    }
                    if ((text[i] == 'і' || text[i] == 'ы') && text[i + 1] == ' ') features[0]++;//окончания на и, ы
                    if (text[i] == 'ш' || text[i] == 'ж')
                    {
                        if (text[i + 1] == 'ы') features[0]++;//жы шы
                        else if (text[i + 1] == 'и') features[1]++;//rus
                    }
                }
                if (i < text.Length - 2)
                {
                    //украинские признаки
                    if (text[i] == 'ц')
                    {
                        if (text[i + 1] == 'ь' && text[i + 2] == ' ') features[2]++;//мягкость ць
                        else if (text[i + 1] == ' ') features[1]++;//рус
                    }
                    if ((text[i] == 'о' || text[i] == 'е') && text[i + 1] == 'ю' && text[i + 2] == ' ') features[2]++;//окончания ою ею
                    if (text[i] == 'т' && text[i + 1] == 'и' && text[i + 2] == ' ') features[2]++;//окончания ти инфинитивов
                    //и еще немного руско-белоруских
                    if (text[i] == 'з' || text[i] == 'с' || text[i] == 'ц' || text[i] == 'ш' || text[i] == 'ж' || text[i] == 'ч' || text[i] == 'л')
                    {
                        if (text[i + 1] == text[i]) features[0]++;//удвоенные согласные
                        else if (text[i + 1] == 'ь' && (text[i + 2] == 'е' || text[i + 2] == 'я')) features[1]++;//rus
                    }
                }                                   
            }
            //features{bel, rus, ukr};
            return features;
        }
        public int CheckRusSymbols(string checkingText)
        {
            int temp = 0;
            for (int i = 0; i < RussianFeatures.Length; i++)
            {
                if (checkingText.Contains(RussianFeatures[i])) temp++;
            }
            for (int i = 0; i < noRussianFeatures.Length; i++)
            {
                if (checkingText.Contains(noRussianFeatures[i])) temp--;
            }
            return temp;
        }

        public int CheckUkrSymbols(string checkingText)
        {
            int temp = 0;
            for (int i = 0; i < UkrainianFeatures.Length; i++)
            {
                if (checkingText.Contains(UkrainianFeatures[i])) temp++;
            }
            for (int i = 0; i < noUkrainianFeatures.Length; i++)
            {
                if (checkingText.Contains(noUkrainianFeatures[i])) temp--;
            }
            return temp;
        }
         
        public int VowalsContant(string text)
        {
            int vowalPersent = 0;
            for(int i=0; i< text.Length; i++)
            {
                if(text.Contains(text[i])) vowalPersent++;
            }
            vowalPersent = text.Length / vowalPersent;
            return vowalPersent;
        }
    }
}