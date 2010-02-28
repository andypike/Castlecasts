using Castle.MonoRail.Framework.Helpers;
using Microsoft.Security.Application;

namespace AndyPike.Castlecasts.Website.Helpers
{
    public class AntiXssHelper : AbstractHelper
    {
        public string H(string input)
        {
            return Html(input);
        }

        public string Html(string input)
        {
            return AntiXss.HtmlEncode(input);
        }

        public string Url(string input)
        {
            return AntiXss.UrlEncode(input);
        }

        public string JS(string input)
        {
            return AntiXss.JavaScriptEncode(input);
        }

        public string VB(string input)
        {
            return AntiXss.VisualBasicScriptEncode(input);
        }

        public string Xml(string input)
        {
            return AntiXss.XmlEncode(input);
        }

        public string HtmlAtt(string input)
        {
            return AntiXss.HtmlAttributeEncode(input);
        }

        public string XmlAtt(string input)
        {
            return AntiXss.XmlAttributeEncode(input);
        }
    }
}