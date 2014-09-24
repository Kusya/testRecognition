using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LanguageRecognition
{
    class test
    {
        private void Main()
        {
            string text = "dfadf";
            Russian r = new Russian();
            int i = r.CheckSymbols(text);
            //i += r.FindFeatures(text,);            
        }
    }
}
