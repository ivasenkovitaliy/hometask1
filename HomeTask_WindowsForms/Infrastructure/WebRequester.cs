using System.Net;
using System.Xml;
namespace HomeTask_WindowsForms.Infrastructure
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
            using (var reader = XmlReader.Create(response.GetResponseStream()))
                document.Load(reader);

            return document;
        }
    }
}
