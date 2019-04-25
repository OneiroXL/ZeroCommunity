using Base.Model;
using Microsoft.AspNetCore.Mvc;
using WebBase.ControllerInfo;
using static Base.MainEnum.APIEnum;

namespace ZeroCommunityService.Controllers.ZCAccount
{
    public class ZCAccountController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Result Login()
        {
            Result result = new Result();

            result.Status = (int)APIStatusEnum.SUCCESS;
            result.Message = "成功";
            return result;
        }
        #endregion


    }
}