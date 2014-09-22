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
                Features f = new Features();
                bool belarusian = f.checkBel(TextValue);
                bool russian = f.checkRus(TextValue);
                bool ukrainian = f.checkUkr(TextValue);
                primaryLanguage = value; }
        }
        private char majorSound;
        public char MajorSound
        {
            get { return majorSound; }
            set { majorSound = value; }
        }
        
        private char majorLetter;
        public char MajorLetter
        {
            get { return majorLetter; }
            set { majorLetter = value; }
        }

        private List<char> specificLetter;
        public List<char> SpecificLetter
        {
            get { return specificLetter; }
            set { specificLetter.Add(value); }
        }
    }
}