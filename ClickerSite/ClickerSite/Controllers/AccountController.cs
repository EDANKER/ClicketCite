using Microsoft.AspNetCore.Mvc;

namespace ClickerSite.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    public IActionResult Profile()
    {
        return View();
    }
}