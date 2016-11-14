using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Study.SSO.B.Models;

namespace Study.SSO.B.Service
{
    public class LoginService
    {
        /// <summary>
        /// 根据ticket来解密获取当前用户信息
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public UserInfoModel GetUserInfo(string ticket)
        {
            //todo 解密ticket 获取用户Id
            
            return new UserInfoModel
            {
                UserId = 123,
                UserName = "何雪峰"
            };
        }
    }
}