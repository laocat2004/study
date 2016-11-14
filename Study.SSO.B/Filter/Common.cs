using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Study.SSO.B.Models;
using Study.SSO.Util;

namespace Study.SSO.B.Filter
{
    public class Common
    {
        /// <summary>
        /// 当前用户
        /// </summary>
        public static UserInfoModel CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session[ConstantHelper.USER_SESSION_KEY] != null)
                {
                    return HttpContext.Current.Session[ConstantHelper.USER_SESSION_KEY] as UserInfoModel;
                }
                return null;
            }
        }
    }
}