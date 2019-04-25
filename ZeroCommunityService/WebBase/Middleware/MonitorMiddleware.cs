using Base.PublicTools;
using Base.PublicTools.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Base.MainEnum.RedisEnum;

namespace WebBase.Middleware
{
    public class MonitorMiddleware
    {
        private readonly RequestDelegate next;
        public MonitorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string IP = RequestTool.GetIpAddress();
            IP = "127.0.0.1";
            if (!string.IsNullOrEmpty(IP))
            {
                int count = RedisTool.Get<int>(RedisKeyEnum.MonitorIP,IP);

                if (count == 0 || count <= 50)
                {
                    RedisTool.Set<int>(RedisKeyEnum.MonitorIP, IP, ++count, new TimeSpan(0, 10, 0));
                }
                else
                {
                    context.Response.ContentType = "text/plain; charset=utf-8";
                    await context.Response.WriteAsync("爱我的次数有点多，休息下吧");
                    return;
                }
                //处理结束转其它中间组件去处理
                await next(context);

            }
            else
            {
                context.Response.ContentType = "text/plain; charset=utf-8";
                await context.Response.WriteAsync("IP都没有吗?");
            }
        }
    }
}
