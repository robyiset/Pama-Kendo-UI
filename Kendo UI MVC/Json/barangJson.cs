using Kendo_UI_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo_UI_MVC.Json
{
    public class barangJson : Controller
    {
        SQLCommand sql = new SQLCommand();
        [HttpGet]
        public JsonResult getbarang()
        {
            return Json(sql.getbarang());
        }
    }
}
