using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace escale.Controllers
{
  public class AnalysisController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      var model = new ScaleData();
      return View(model);
    }

    [HttpPost]
    public ActionResult Index(ScaleData model)
    {
      // if (!ModelState.IsValid) return View(model);


      // 取得使用者資料
      // model.UserNo = SessionService.UserNo;
      // var user = new z_sqlUsers();
      // var userData = user.GetData(model.UserNo);

      if (!ModelState.IsValid) return View(model);

      // 取得使用者資料
      var userNo = SessionService.UserNo;
      if (string.IsNullOrEmpty(userNo))
      {
        ModelState.AddModelError("", "使用者編號不存在");
        return RedirectToAction("Login", "User", new { area = "" });
      }

      var user = new z_sqlUsers();
      var userData = user.GetData(userNo);

      // 判斷 userData 是否為 null
      if (userData == null)
      {
        ModelState.AddModelError("", "找不到使用者資料");
        return RedirectToAction("Login", "User", new { area = "" });
      }




      //儲存至資料庫
      var scale = new z_sqlScaleData();
      scale.Create(model);

      //寄送電子郵件
      var mailObject = new MailObject();
      mailObject.ToName = userData.UserName;
      mailObject.ToEmail = userData.ContactEmail;
      var sendEmail = new SendMailService();
      string str_message = sendEmail.AnalysisScale(mailObject, model);

      //取得訊息文字
      if (string.IsNullOrEmpty(str_message)) str_message = "您的營養分析結果已經寄出，請查收!!";

      //寄送line
      HttpClient httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
      httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userData.LineNotifyToken);
      var content = new Dictionary<string, string>();
      content.Add("message", str_message);
      httpClient.PostAsync("https://notify-api.line.me/api/notify", new FormUrlEncodedContent(content));

      //顯示訊息
      SessionService.MessageText = str_message;
      return RedirectToAction("Index", "Message", new { area = "" });

    }
  }
}

