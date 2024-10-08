using Microsoft.AspNetCore.Mvc;
using escale.Models;
using System.Diagnostics;

namespace escale.Controllers
{
  public class ShopController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public ShopController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      return View();
    }
  }
}
