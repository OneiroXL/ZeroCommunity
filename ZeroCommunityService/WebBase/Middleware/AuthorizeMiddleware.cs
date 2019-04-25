using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace WebBase.Middleware
{
    public class AuthorizeMiddleware
    {
        private readonly RequestDelegate next;
        public AuthorizeMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            //获取授权Authorization
            StringValues authorization = "";
            context.Request.Headers.TryGetValue("Authorization", out authorization);

            string authorizationValue = authorization.ToString();
            if (!string.IsNullOrEmpty(authorizationValue))
            {
                if (authorizationValue == "ZXL")
                {
                    //处理结束转其它中间组件去处理
                    await next(context);
                }
                else
                {
                    context.Response.ContentType = "text/plain; charset=utf-8";
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("你是谁?我不认识你：" + authorizationValue);
                }
               
            }
            context.Response.StatusCode = 401;
        }
    }
}
