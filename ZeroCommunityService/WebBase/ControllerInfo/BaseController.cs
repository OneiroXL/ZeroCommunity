using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebBase.Attribute;

namespace WebBase.ControllerInfo
{
    [Authorization]
    public class BaseController : Controller
    {

    }
}
