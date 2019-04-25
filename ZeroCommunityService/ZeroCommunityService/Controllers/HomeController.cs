using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.ZCAcount.Data;
using System.Collections.Generic;
using System.Diagnostics;
using WebBase.ControllerInfo;
using ZCAccountModuleBLL;
using ZeroCommunityService.Models;

namespace ZeroCommunityService.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            UserBLL userBLL = new UserBLL();
            List<User> users = userBLL.GetUserList();


            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        [AllowAnonymous]
        public JsonResult Test()
        {
            UserBLL userBLL = new UserBLL();
            List<User> users = userBLL.GetUserList();

            return Json(users);

        }
    }
}
