﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.SqlServer.Server;
using Study.SSO.B.Models;
using Study.SSO.B.Service;
using Study.SSO.Util;

namespace Study.SSO.B.Filter
{
    /// <summary>
    /// 授权枚举
    /// </summary>
    public enum AuthCodeEnum
    {
        Public = 1,
        Login = 2
    }

    /// <summary>
    /// 授权过滤器
    /// </summary>
    public class AuthAttribute : ActionFilterAttribute
    {
        /// <summary> 
        /// 权限代码 
        /// </summary> 
        public AuthCodeEnum Code { get; set; }

        /// <summary> 
        /// 验证权限
        /// </summary> 
        /// <param name="filterContext"></param> 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var session = filterContext.HttpContext.Session;
            //如果存在身份信息 
            if (Common.CurrentUser == null)
            {
                if (Code == AuthCodeEnum.Public)
                {
                    return;
                }
                string reqToken = request["Token"];
                string ticket = request["Ticket"];
                Cache cache = HttpContext.Current.Cache;
                //每次刷新页面的时候首先删除Token
                if (string.IsNullOrEmpty(reqToken) || string.IsNullOrEmpty(ticket))
                {
                    cache.Remove(ConstantHelper.TOKEN_KEY);
                }
                //没有获取到Token或者Token验证不通过或者没有取到从P回调的ticket 都进行再次请求P
                TokenModel tokenModel= cache.Get(ConstantHelper.TOKEN_KEY)==null?null:(TokenModel)cache.Get(ConstantHelper.TOKEN_KEY);
                if (string.IsNullOrEmpty(reqToken) || tokenModel == null || tokenModel.Token!= reqToken ||
                    string.IsNullOrEmpty(ticket))
                {
                    DateTime timestamp = DateTime.Now;
                    string returnUrl = request.Url.AbsoluteUri;
                    tokenModel = new TokenModel
                    {
                        TimeStamp = timestamp,
                        Token = AuthernUtil.CreateToken(timestamp)
                    };
                    //Token加入缓存中，设计过期时间为20分钟
                    cache.Add(ConstantHelper.TOKEN_KEY, tokenModel, null, DateTime.Now.AddMinutes(20),Cache.NoSlidingExpiration,CacheItemPriority.Default, null);
                    filterContext.Result = new ContentResult
                    {
                       Content = GetAuthernScript(AuthernUtil.GetAutherUrl(tokenModel.Token, timestamp), returnUrl)
                    };
                    return;
                }
                LoginService service = new LoginService();
                var userinfo = service.GetUserInfo(ticket);
                session[ConstantHelper.USER_SESSION_KEY] = userinfo;
                //验证通过,cache中去掉Token,保证每个token只能使用一次
                cache.Remove(ConstantHelper.TOKEN_KEY);
            }
        }

        /// <summary>
        /// 生成跳转脚本
        /// </summary>
        /// <param name="authernUrl">统一授权地址</param>
        /// <param name="returnUrl">回调地址</param>
        /// <returns></returns>
        private string GetAuthernScript(string authernUrl, string returnUrl)
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.Append("<script type='text/javascript'>");
            sbScript.AppendFormat("window.location.href='{0}&returnUrl=' + encodeURIComponent('{1}');", authernUrl, returnUrl);
            sbScript.Append("</script>");
            return sbScript.ToString();
        }
    }
}