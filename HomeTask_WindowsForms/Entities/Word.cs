using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishAssistant.Entities
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
        public bool IsLearnedRussianByCheck { get; set; }
        public bool IsLearnedEnglishByCheck { get; set; }
        public bool IsLearnedRussianByTranslation { get; set; }
        public bool IsLearnedEnglishByTranslation { get; set; }

        public bool IsFullyLearned
        {
            get
            {
                return IsLearnedEnglishByCheck && IsLearnedEnglishByTranslation
                       && IsLearnedRussianByCheck && IsLearnedRussianByTranslation;
            }
        }


        public Word()
        {
        }

        public Word(int id, string original, string translate, string translateSecond, string translateThird, int categoryId, string category,
                    bool isLearnedEnglishByCheck, bool isLearnedRussianByCheck, bool isLearnedEnglishByTranslation, bool isLearnedRussianByTranslation)
        {
            Id = id;
            Original = original;
            Translate = translate;
            TranslateSecond = translateSecond;
            TranslateThird = translateThird;
            CategoryId = categoryId;
            Category = category;
            IsLearnedEnglishByCheck = isLearnedEnglishByCheck;
            IsLearnedRussianByCheck = isLearnedRussianByCheck;
            IsLearnedEnglishByTranslation = isLearnedEnglishByTranslation;
            IsLearnedRussianByTranslation = isLearnedRussianByTranslation;
        }

        public Word(string original, string translate, string translateSecond, string translateThird, int categoryId) :
            this(0, original, translate, translateSecond, translateThird, categoryId, string.Empty, false, false, false, false) { }

        public string GetRandomTranslate
        {
            get
            {
                var rndTranslate = new Random();
                var translatesList = new List<string> { Translate };

                if (!string.IsNullOrEmpty(TranslateSecond))
                    translatesList.Add(TranslateSecond);
                else if (!string.IsNullOrEmpty(TranslateThird))
                    translatesList.Add(TranslateSecond);

                return translatesList.ElementAt(rndTranslate.Next(0, translatesList.Count));
            }
        }
    }
}
