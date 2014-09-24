using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace test2nika.Models
{
    public class TextExpertise
    {
        
        
        private string TextValue;
        //private ILanguage primaryLanguage;
        //public ILanguage PrimaryLanguage
        //{
        //    get {return primaryLanguage;}
        //    set
        //    {
                
        //        primaryLanguage = value; }
        //}
        
        
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
            
            return null;
        }
    }
}