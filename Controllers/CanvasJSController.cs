using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace escale.Controllers
{
  public class CanvasJSController : Controller
  {
    /// <summary>
    /// 動態 Column 長條圖
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult ColumnDatabase()
    {
      return View();
    }

    /// <summary>
    /// 動態 Column 長條圖資料
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    [HttpGet]
    public JsonResult ColumnDatabaseData(string startDate, string endDate)
    {
      using var scale = new z_sqlScaleData();
      var data = scale.GetColumnData(startDate, endDate);
      return Json(data);
    }
  }
}

