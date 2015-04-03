using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeTask_WindowsForms.Entities
{
    public class Word
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Translate { get; set; }
        public string TranslateSecond { get; set; }
        public string TranslateThird { get; set; }
        public string Category { get; set; }
        public string Original { get; set; }

        public bool IsLearnedRussian { get; set; }

        public bool IsLearnedEnglish { get; set; }
        
        public Word()
        {
        }
      
        public Word(int id, string original, string translate, string translateSecond, string translateThird, int categoryId, string category, bool isLearnedEnglish, bool isLearnedRussian)
        {
            this.Id = id;
            this.Original = original;
            this.Translate = translate;
            this.TranslateSecond = translateSecond;
            this.TranslateThird = translateThird;
            this.CategoryId = categoryId;
            this.Category = category;
            this.IsLearnedEnglish = isLearnedEnglish;
            this.IsLearnedRussian = isLearnedRussian;
        }

        public Word(string original, string translate, string translateSecond, string translateThird, int categoryId) : this(0, original, translate, translateSecond, translateThird, categoryId, string.Empty, false, false) { }

        public string GetRandomTranslate
        {
            get {
                var rndTranslate = new Random();
                var translatesList = new List<string>();

                translatesList.Add(this.Translate);

                if (!string.IsNullOrEmpty(TranslateSecond))
                    translatesList.Add(this.TranslateSecond);
                else if (!string.IsNullOrEmpty(TranslateThird))
                    translatesList.Add(this.TranslateSecond);

                return translatesList.ElementAt(rndTranslate.Next(0, translatesList.Count));
            }
        }
    }
}
