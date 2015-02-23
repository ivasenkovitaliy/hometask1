﻿using System;

namespace HomeTask_WindowsForms
{
    public class Word
    {
        public int Id { get; set; }
        public string Translate { get; set; }
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

        public Word GetWordWithRandomTranslate()
        {
            Word wordWithRandomTranslate = new Word();

            wordWithRandomTranslate.Original = this.Original;
            wordWithRandomTranslate.Category = this.Category;
            
            Random rndTranslate = new Random();
            
            var tempWordsFromTranslate = this.Translate.Split('_');
            
            if (tempWordsFromTranslate.Length > 1)
            {
                wordWithRandomTranslate.Translate=tempWordsFromTranslate[rndTranslate.Next(tempWordsFromTranslate.Length)];
                return wordWithRandomTranslate;
            }
            wordWithRandomTranslate.Translate = this.Translate;
            return wordWithRandomTranslate;
        }

        public string[] GetAllTranslatesOfWord()
        {
            return this.Translate.Split('_');
        }
    }
}
