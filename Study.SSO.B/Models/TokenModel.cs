using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study.SSO.B.Models
{
    public class TokenModel
    {
        /// <summary>
        /// 唯一Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime TimeStamp { get; set; }
    }
}