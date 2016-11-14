using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SqlServer.Server;

namespace Study.SSO.Util
{
    /// <summary>
    /// 静态变量帮助类
    /// </summary>
    public class ConstantHelper
    {
        /// <summary>
        /// 用户SessionKey
        /// </summary>
        public const string USER_SESSION_KEY="UserSessionKey";
        /// <summary>
        /// 用户CookieKey
        /// </summary>
        public const string USER_COOKIE_KEY = "UserCookieKey";

        public const string TOKEN_KEY = "TokenKey";
    }
}
