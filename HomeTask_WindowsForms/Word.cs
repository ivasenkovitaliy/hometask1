using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_WindowsForms
{
    public class Word
    {
        public string _translate { get; private set; }
        public string _category { get; private set; }
        public string _original { get; private set; }
        
        public Word()
        {
            
        }

        public Word(string original, string translate, string category)
        {
            Random rndTranslate = new Random();
            this._original = original;
            this._translate = translate;
            this._category = category;

            // here we getting one of translaeting values if ther'e more then one
            var tempWordsFromTranslate = this._translate.Split('_');
            if (tempWordsFromTranslate.Length > 1)
                this._translate = tempWordsFromTranslate[rndTranslate.Next(tempWordsFromTranslate.Length)];
        }
    }
}
