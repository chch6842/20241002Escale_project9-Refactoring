using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace escale.Controllers
{
  [ApiController]
  [Route("api/[controller]/[action]")]

  [ApiExplorerSettings(IgnoreApi = true)]
  public class GetinformController : ControllerBase
  {
    private readonly dbEntities _context;

    public GetinformController(dbEntities context)
    {
      _context = context;
    }


    /// <summary>
    /// 讀取資料
    /// </summary>
    /// <param name="UserNo">User No</param>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<object> Get(string UserNo)
    {
      var result = from a in _context.ScaleData
                   where a.UserNo == UserNo
                   select new
                   {
                     a.RecordDate,
                     a.Grains,
                     a.Protein,
                     a.Dairy,
                     a.Vegetables,
                     a.Fruits,
                     a.OilsNuts

                   };

      return result;
    }



    /// <summary>
    /// 新增資料
    /// </summary>
    /// <param name="newScaleData">New Data</param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post(ScaleData newScaleData)
    {

      if (newScaleData == null)
      {
        return BadRequest("Invalid data.");
      }
      // Check if UserNo is a member
      var isMember = _context.Users.Any(m => m.UserNo == newScaleData.UserNo);
      if (!isMember)
      {
        return BadRequest("User is not a member.");
      }

      _context.ScaleData.Add(newScaleData);
      _context.SaveChanges();

      return Ok(new
      {
        Message = "Data added successfully.",
        Data = newScaleData
      });
    }

  }
}
