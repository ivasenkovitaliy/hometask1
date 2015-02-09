using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_WindowsForms
{
    public class Word
    {
        private int _id;
        private string _original, _translate, _category;

        public string GetTranslate()
        {
            return _translate;
        }

        public string GetCategory()
        {
            return _category;
        }
        public string GetOriginal()
        {
            return _original;
        }


        public Word()
        {
            

        }

        public Word(int id, string original, string translate, string category)
        {
            Random _rndTranslate = new Random();

            this._id = id;
            this._original = original;
            this._translate = translate;
            this._category = category;

            // here will check "multi-field" "translate"
            var tempWordsFromTranslate = this._translate.Split('_');
            if (tempWordsFromTranslate.Length > 1)
                this._translate = tempWordsFromTranslate[_rndTranslate.Next(tempWordsFromTranslate.Length)];
            
                
        }
    }
     
}
