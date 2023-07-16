using ClickerSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClickerSite.Controllers;

public class RenameDataUserController : Controller
{
    private readonly ILogger<RenameDataUserController> _logger;

    public RenameDataUserController(ILogger<RenameDataUserController> logger)
    {
        _logger = logger;
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDataUser(User user)
    {
        
        return View();
    }
}