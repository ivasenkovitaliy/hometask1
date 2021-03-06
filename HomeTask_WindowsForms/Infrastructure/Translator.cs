﻿using System;
using System.Xml;

namespace EnglishAssistant.Infrastructure
{
    public interface ITranslator
    {
        string GetTranslation(string word, string from, string to);
    }

    public class YandexTranslator: ITranslator
    {
        private readonly string _apiKey;
        private readonly IWebRequester<XmlDocument> _requester; 
        private const string RequestUrl = "https://translate.yandex.net/api/v1.5/tr/";

        public YandexTranslator(string apiKey, IWebRequester<XmlDocument> requester)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException("apiKey");
            if (requester == null)
                throw new ArgumentNullException("requester");

            _apiKey = apiKey;
            _requester = requester;
        }


        public string GetTranslation(string text, string from, string to)
        {
            var body = GetBodyForRequest(from, to, text);
            XmlDocument document;
            try
            {
                document = _requester.SendRequestAndGetResponse(RequestUrl, body);
            }
            catch
            {
                return string.Empty;
            }

            var xmlElement = document["Translation"];
            return xmlElement != null ? xmlElement.InnerText : string.Empty;
        }


        private string GetBodyForRequest(string from, string to, string text)
        {
            return RequestUrl + string.Format("translate?key={0}&lang={1}-{2}&text={3}", _apiKey, from, to, text);
        }
    }
}
