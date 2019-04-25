using System;
using System.Collections.Generic;
using System.Text;

namespace Base.PublicTools
{
    public class RequestTool
    {
        #region 获取IP地址
        /// <summary>
        /// 获取IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIpAddress()
        {
            string result = String.Empty;
            //result = HttpContext.Current.Request.ServerVariables["HTTP_CDN_SRC_IP"];
            //if (string.IsNullOrEmpty(result))
            //    result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            //if (string.IsNullOrEmpty(result))
            //    result = HttpContext.Current.Request.UserHostAddress;

            //if (string.IsNullOrEmpty(result))
            //    return "127.0.0.1";

            return result;
        }
        #endregion
    }
}
