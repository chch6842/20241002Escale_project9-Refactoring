using Microsoft.AspNetCore.Mvc;

namespace escale.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
// 寄信確認,加了就不會動
[HttpGet]
public IActionResult Contact()
{
    var model = new vmContact();
    return View(model);
}

[HttpPost]
public IActionResult Contact(vmContact model)
{
    if (!ModelState.IsValid) return View(model);

    //寄信給系統管理者及訊息提交者
    using var sendEmail = new SendMailService();

    var mailObject = new MailObject();
    mailObject.MailTime = DateTime.Now;
    mailObject.UserNo = "";
    mailObject.UserName = "";
    mailObject.ToName = model.ContactorName;
    mailObject.ToEmail = model.ContactorEmail;
    mailObject.MailSubject = model.ContactorSubject;
    mailObject.MailContent = model.ContactorMessage;

    SessionService.MessageText = sendEmail.ContactUs(mailObject);

    //顯示完成訊息
    SessionService.StringValue1 = "ShopIndex";
    if (string.IsNullOrEmpty(SessionService.MessageText))
        SessionService.MessageText = "您的留言訊息已提交，我們會使用電子信箱方式盡速回覆您的問題。";

    return RedirectToAction("Index", "Message", new { area = "" });
}

    }
}
