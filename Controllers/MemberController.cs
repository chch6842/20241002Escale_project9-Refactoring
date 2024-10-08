using Microsoft.AspNetCore.Mvc;
using escale.Models;
using System.Diagnostics;

namespace escale.Controllers
{
  public class MemberController : Controller
  {
    private readonly ILogger<MemberController> _logger;

    public MemberController(ILogger<MemberController> logger)
    {
      _logger = logger;
    }
    [HttpGet]
    public IActionResult Index()
    {
      return View();
    }
    [HttpGet]
    public IActionResult Join()
    {
      return View();
    }
    public IActionResult Login()
    {
      return View();
    }
    public IActionResult Reset()
    {
      return View();
    }
  }
}
