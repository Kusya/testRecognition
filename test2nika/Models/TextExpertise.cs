using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test2nika.Models
{
    public class TextExpertise
    {
        
        
        private string TextValue;
        private Language primaryLanguage;
        public Language PrimaryLanguage
        {
            get {return primaryLanguage;}
            set
            {
                
                primaryLanguage = value; }
        }
        
        
        private char majorLetter;
        public char MajorLetter
        {
            get { return majorLetter; }
            set { majorLetter = value; }
        }

        private List<char> specificLetter;
        //public List<char> SpecificLetter
        //{
        //    get { return specificLetter; }
        //    set { specificLetter.Add(value); }
        //}

        private string LanguageVerification(string text)
        {
            text=text.ToLower();
            int[] languagePriority = new int[3];
            Features f = new Features();
            int vowal= f.VowalsContant(text);
            if (vowal*10 > 9 || vowal*10 < 1) return "такого слова несуществует в словаре. хотите добавить?";
            languagePriority[0] = f.CheckBelSymbols(text);
            languagePriority[1] = f.CheckRusSymbols(text);
            languagePriority[2] = f.CheckUkrSymbols(text);
            int[] temp = f.CheckLenguageFeatures(text,languagePriority);
            return null;
        }
    }
}