using System;
using System.Collections.Generic;
using System.Linq;
using EnglishAssistant.DAL;
using EnglishAssistant.Entities;
using EnglishAssistant.Infrastructure;
using EnglishAssistant.Infrastructure.Extensions;

namespace EnglishAssistant.Services
{
    class TestService
    {
        private readonly LocalAppData _localData = LocalAppData.Instance;
        private readonly WordRepository _wordRepository = new WordRepository();

        public List<Word> GetWordsForTesting(TypeTest typeTest)
        {
            var wordsInUsedCategories = _localData.Categories.Where(x => x.IsUsed).SelectMany(x => _localData.Words.Where(w => w.CategoryId == x.CategoryId)).ToList();

            if (wordsInUsedCategories.Count < Settings.MinAllowedWordsForTest)
                throw new Exception("There are less then 5 words in selected categories. Please add more words or use more categories");

            var requiredWords = new List<Word>();

            while (requiredWords.Count < Settings.MinAllowedWordsForTest)
            {
                requiredWords = new List<Word>(wordsInUsedCategories);
                switch (typeTest)
                {
                    case TypeTest.EnglishCheck:
                        requiredWords.RemoveAll(x => x.IsLearnedEnglishByCheck);
                        break;
                    case TypeTest.EnglishTranslation:
                        requiredWords.RemoveAll(x => x.IsLearnedEnglishByTranslation);
                        break;
                    case TypeTest.RussianCheck:
                        requiredWords.RemoveAll(x => x.IsLearnedRussianByCheck);
                        break;
                    case TypeTest.RussianTranslation:
                        requiredWords.RemoveAll(x => x.IsLearnedRussianByTranslation);
                        break;
                }

                if (requiredWords.Count() < Settings.MinAllowedWordsForTest)
                {
                    switch (typeTest)
                    {
                        case TypeTest.EnglishCheck:
                            _wordRepository.ResetAllEnglishLearnedWordsByChecking();
                            break;
                        case TypeTest.EnglishTranslation:
                            _wordRepository.ResetAllEnglishLearnedWordsByTranslation();
                            break;
                        case TypeTest.RussianCheck:
                            _wordRepository.ResetAllRussianLearnedWordsByChecking();
                            break;
                        case TypeTest.RussianTranslation:
                            _wordRepository.ResetAllRussianLearnedWordsByTranslation();
                            break;
                    }

                    var allWords = _wordRepository.GetAllWords().ToList();

                    LocalAppData.Instance.Words = allWords;
                    wordsInUsedCategories = allWords;
                }

            }

            foreach (var word in requiredWords)
                word.Translate = word.GetRandomTranslate;

            requiredWords = requiredWords.Shuffle().Take(Settings.MinAllowedWordsForTest).ToList();

            return requiredWords;
        }

        public void SetWordIsLearned(TypeTest typeTest, int wordId)
        {
            var word = _localData.Words.First(x => x.Id == wordId);

            switch (typeTest)
            {
                case TypeTest.EnglishCheck:
                    word.IsLearnedEnglishByCheck = true;
                    break;
                case TypeTest.EnglishTranslation:
                    word.IsLearnedEnglishByTranslation = true;
                    break;
                case TypeTest.RussianCheck:
                    word.IsLearnedRussianByCheck = true;
                    break;
                case TypeTest.RussianTranslation:
                    word.IsLearnedRussianByTranslation = true;
                    break;
            }

            _wordRepository.UpdateWord(word);
        }
    }
}
