using System.Net;
using System.Xml;

namespace EnglishAssistant.Infrastructure
{
    public interface IWebRequester<T>
    {
        T SendRequestAndGetResponse(string requestUrl, string body);
    }

    class XmlWebRequester : IWebRequester<XmlDocument>
    {
        public XmlDocument SendRequestAndGetResponse(string requestUrl, string body)
        {
            var request = WebRequest.Create(body);
            request.Method = "POST";
            request.ContentType = "text/xml; encoding='utf-8'";

            var document = new XmlDocument();
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseStream = response.GetResponseStream();
                if (responseStream == null)
                    return new XmlDocument();

                using (var reader = XmlReader.Create(responseStream))
                    document.Load(reader);
            }
            return document;
        }
    }
}
