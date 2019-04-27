using Microsoft.AspNetCore.Http;
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
        public static string GetIpAddress(HttpContext context)
        {
            string result = String.Empty;

            string IP = context.Connection.RemoteIpAddress.ToString();
            if (!string.IsNullOrEmpty(IP))
            {
                string[] ips = IP.Split(':');
                result = ips[ips.Length - 1];
            }


            return result;
        }
        #endregion
    }
}
