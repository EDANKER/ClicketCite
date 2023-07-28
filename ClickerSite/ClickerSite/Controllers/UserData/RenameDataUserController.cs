using System.Data;
using ClickerSite.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ClickerSite.Controllers;

public class RenameDataUserController : Controller
{
    private readonly ILogger<RenameDataUserController> _logger;

    public RenameDataUserController(ILogger<RenameDataUserController> logger)
    {
        _logger = logger;
    }

    string connect = "Server=localhost;port=52345;Database=Click;Uid=root;pwd=root;charset=utf8";

    [HttpPost]
    public async Task<IActionResult> UpdateDataUser(User user, ProfileDataModel profileDataModel)
    {
        var command = "UPDATE Click SET name = @Name WHERE name = @OldName ";
        var sqlConnect = new MySqlConnection(connect);
        Console.WriteLine(user.Name);
        Console.WriteLine(profileDataModel.NameProfile);
        sqlConnect.Open();
        var sqlCommand = new MySqlCommand(command, sqlConnect);
        sqlCommand.Parameters.Add("@Name", MySqlDbType.Text).Value = user.Name;
        sqlCommand.Parameters.Add("@OldName", MySqlDbType.Text).Value = profileDataModel.NameProfile;
        await sqlCommand.ExecuteNonQueryAsync();
        await sqlConnect.CloseAsync();
        return PartialView();
    }
}