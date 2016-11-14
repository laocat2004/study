using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study.SSO.Passport.Models
{
    public class LoginResultModel
    {
        /// <summary>
        /// 成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public UserModel UserInfo { get; set; }
    }
}