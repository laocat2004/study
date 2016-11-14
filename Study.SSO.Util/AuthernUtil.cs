using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Study.SSO.Util
{
    public class AuthernUtil
    {
        /// <summary>
        /// 生成令牌
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static string CreateToken(DateTime timestamp)
        {
            StringBuilder securityKey = new StringBuilder(MD5Encypt(timestamp.ToString("yyyy")));
            securityKey.Append(MD5Encypt(timestamp.ToString("MM")));
            securityKey.Append(MD5Encypt(timestamp.ToString("dd")));
            securityKey.Append(MD5Encypt(timestamp.ToString("HH")));
            securityKey.Append(MD5Encypt(timestamp.ToString("mm")));
            securityKey.Append(MD5Encypt(timestamp.ToString("ss")));
            return MD5Encypt(securityKey.ToString());
        }

        private static string MD5Encypt(string cpt)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(cpt, "MD5");
        }

        public static string GetAutherUrl(string token,DateTime timestamp)
        {
            var autherUrl = ConfigurationManager.AppSettings["PassportCenterUrl"];
            string returnFormat = "{0}/Passport/PassportCenter?token={1}&timestamp={2}";
            return string.Format(returnFormat, autherUrl, token, timestamp);
        }
    }
}
