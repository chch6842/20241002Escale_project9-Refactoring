namespace escale.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeAsyncController : Controller
    {
        private readonly dbEntities db;
private readonly IConfiguration Configuration;

/// <summary>
/// 控制器建構子
/// </summary>
/// <param name="configuration">環境設定物件</param>
/// <param name="entities">EF資料庫管理物件</param>
public EmployeeAsyncController(IConfiguration configuration, dbEntities entities)
{
    db = entities;
    Configuration = configuration;
}

/// <summary>
/// 員工資料初始事件
/// </summary>
/// <returns></returns>
[HttpGet]
public IActionResult Init()
{
    //這裏可以寫入初始程式

    //返回員工列表
    return RedirectToAction("Index", "EmployeeAsync", new { area = "Admin" });
}

/// <summary>
/// 員工資料列表
/// </summary>
/// <returns></returns>
[HttpGet]
public async Task<ActionResult> Index()
{
    //取得員工資料列表集合
    using var sqlEmp = new z_sqlEmployees();
    var model = await sqlEmp.GetDataListAsync();
    return View(model);
}

/// <summary>
/// 員工資料新增
/// </summary>
/// <returns></returns>
/// [HttpGet]
public IActionResult Create()
{
    return RedirectToAction("CreateEdit", "EmployeeAsync", new { area = "Admin", id = 0 });
}

/// <summary>
/// 員工資料修改
/// </summary>
/// <param name="id">要修改的Key值</param>
/// <returns></returns>
/// [HttpGet]
public IActionResult Edit(int id = 0)
{
    return RedirectToAction("CreateEdit", "EmployeeAsync", new { area = "", id = id });
}

/// <summary>
/// 員工資料新增或修改輸入 (id = 0 為新增 , id > 0 為修改)
/// </summary>
/// <param name="id">要修改的Key值</param>
/// <returns></returns>
[HttpGet]
public async Task<IActionResult> CreateEdit(int id = 0)
{
    //取得新增或修改的員工資料結構及資料
    using var repoEmp = new z_sqlEmployees();
    var model = await repoEmp.GetDataAsync(id);
    return View(model);
}

/// <summary>
/// 員工資料新增或修改存檔
/// </summary>
/// <param name="model">使用者輸入的資料模型</param>
/// <returns></returns>
[HttpPost]
public async Task<IActionResult> CreateEdit(Employees model)
{
    //檢查是否有違反 Metadata 中的 Validation 驗證
    if (!ModelState.IsValid) return View(model);
    //檢查是否重覆輸入員工編號(EmpNo)值
    using var dpr = new DapperRepository();
    if (dpr.IsDuplicated(model, "EmpNo"))
    {
        ModelState.AddModelError("EmpNo", "員工編號重覆輸入!!");
        return View(model);
    }
    //執行新增或修改資料
    using var repoEmp = new z_sqlEmployees();
    await repoEmp.CreateEditAsync(model);
    //返回員工資料列表
    return RedirectToAction("Index", "EmployeeAsync", new { area = "" });
}

/// <summary>
/// 取得指定縣市的鄉鎮區資料列表
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
public JsonResult GetCityAreaList(string id)
{
    var cityArea = new z_sqlCityAreas();
    var model = cityArea.GetDropDownList(id);
    return Json(model);
}
    }
}
