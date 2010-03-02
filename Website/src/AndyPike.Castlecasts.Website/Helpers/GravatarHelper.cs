using System.Collections;
using AndyPike.Castlecasts.Website.Extensions;
using Castle.MonoRail.Framework.Helpers;
using Castle.MonoRail.Framework.Internal;

namespace AndyPike.Castlecasts.Website.Helpers
{
    public class GravatarHelper : AbstractHelper
    {
        private const string IMAGE_TAG_FORMAT = "<img src=\"{0}\" align=\"absmiddle\" alt=\"Gravatar\" />";
        private const string PROTOCOL = "http";
        private const string DOMAIN = "www.gravatar.com";
        private const string PATH = "avatar";
        private const string EXTENSION = "jpg";

        public string Url(string email)
        {
            email = email.ToLower().Trim();

            string emailAsMd5 = email.ToMD5();

            return string.Format("{0}://{1}/{2}/{3}.{4}", PROTOCOL, DOMAIN, PATH, emailAsMd5, EXTENSION).ToLower();
        }

        public string Url(string email, IDictionary parameters)
        {
            string url = Url(email);
            string queryString = CommonUtils.BuildQueryString(ServerUtility, parameters, false);

            return string.Concat(url, "?", queryString);
        }

        public string Image(string email)
        {
            return string.Format(IMAGE_TAG_FORMAT, Url(email));
        }

        public string Image(string email, IDictionary parameters)
        {
            return string.Format(IMAGE_TAG_FORMAT, Url(email, parameters));
        }

        public string Image(string email, int size, string rating, string defaultUrl)
        {
            return Image(email, new Hashtable {
                                                 { "size", size }, 
                                                 { "default", defaultUrl }, 
                                                 { "rating", rating }
                                              });
        }
    }

}
