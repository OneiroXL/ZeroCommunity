using Base.Map;
using Base.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebBase.Attribute
{
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Filters.Where(p => p.ToString() == "Microsoft.AspNetCore.Mvc.Authorization.AllowAnonymousFilter").Count() == 0)
            {
                //取出Authorization
                string authorization = context.HttpContext.Request.Headers["Authorization"];

                if (!string.IsNullOrEmpty(authorization))
                {
                    if (authorization != "ZXL")
                    {
                        Result result = new Result();
                        result.Status = 10001;
                        result.Message = MessageMap.GetMessage(result.Status) + ":" + authorization;
                        context.Result = new ObjectResult(result) { StatusCode = 401 };
                    }
                }
                else
                {
                    Result result = new Result();
                    result.Status = 10002;
                    result.Message = MessageMap.GetMessage(result.Status);
                    context.Result = new ObjectResult(result) { StatusCode = 401};
                }

            }
        }
    }
}
