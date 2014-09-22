using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test2nika.Models
{
    public class Features
    {
        char[] RussianFeatures = new char[] { 'ъ', 'Ъ' };
        char[] noRussianFeatures = new char[] { '\'', 'і', 'І' };
        char[] BelarusianFeatures = new char[] { 'ў', 'Ў' };
        char[] noBelarusianFeatures = new char[] { 'щ', 'Щ', 'и', 'И' };
        char[] UkrainianFeatures = new char[] { 'є', 'Є', 'Ї', 'ї' };
        char[] noUkrainianFeatures = new char[] { 'э', 'Э', 'ы', 'Ы' };
        public bool checkBel(string checkingText)
        {
            int temp=0;
            for (int i = 0; i < BelarusianFeatures.Length; i++)
            {
                if (checkingText.Contains(BelarusianFeatures[i])) temp++;
            }
            for (int i = 0; i < noBelarusianFeatures.Length; i++)
            {
                if (checkingText.Contains(noBelarusianFeatures[i])) temp--;
            }
            if (temp > 0) return true;
            else return false;
        }
        public bool checkRus(string checkingText)
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
            if (temp > 0) return true;
            else return false;
        }

        public bool checkUkr(string checkingText)
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
            if (temp > 0) return true;
            else return false;
        }
    }
}