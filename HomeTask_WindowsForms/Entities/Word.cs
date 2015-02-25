using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeTask_WindowsForms
{
    public class Word
    {
        public int Id { get; set; }
        public string Translate { get; set; }
        public string TranslateSecond { get; set; }
        public string TranslateThird { get; set; }
        public string Category { get; set; }
        public string Original { get; set; }
        
        public Word()
        {
        }
        
        public Word(int id, string original, string translate, string category)
        {
            this.Id = id;
            this.Original = original;
            this.Translate = translate;
            this.Category = category;
        }
        public Word(int id, string original, string translate, string translateSecond, string translateThird, string category)
        {
            this.Id = id;
            this.Original = original;
            this.Translate = translate;
            this.TranslateSecond = translateSecond;
            this.TranslateThird = translateThird;
            this.Category = category;
        }
        public Word(string original, string translate, string translateSecond, string translateThird)
        {
            this.Original = original;
            this.Translate = translate;
            this.TranslateSecond = translateSecond;
            this.TranslateThird = translateThird;
        }
        public Word GetWordWithRandomTranslate()
        {
            Random rndTranslate = new Random();
            var translatesList = new List<string>();

            translatesList.Add(this.Translate);
            if ( !this.TranslateSecond.Equals(string.Empty) )
                translatesList.Add(this.TranslateSecond);
            else if ( !this.TranslateThird.Equals(string.Empty) )
                translatesList.Add(this.TranslateSecond);
            
            this.Translate = translatesList.ElementAt(rndTranslate.Next(0, translatesList.Count));
            
            return this;
        }
    }
}
