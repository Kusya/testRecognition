using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test2nika.Models
{
    public class TextExpertise
    {
        
        
        private string TextValue;
        private ILanguage primaryLanguage;
        public ILanguage PrimaryLanguage
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
        public int VowalsContant(string text)
        {
            int vowalPersent = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text.Contains(text[i])) vowalPersent++;
            }
            vowalPersent = text.Length / vowalPersent;
            return vowalPersent;
        }
        public abstract int FindFeatures(string text);
        private string LanguageVerification(string text)
        {
            text=text.ToLower();
            int[] languagePriority = new int[3];
            int vowal= VowalsContant(text);
            if (vowal*10 > 9 || vowal*10 < 1) return "такого слова несуществует в словаре. хотите добавить?";
            
            //int[] temp = f.CheckLenguageFeatures(text,languagePriority);
            return null;
        }
    }
}