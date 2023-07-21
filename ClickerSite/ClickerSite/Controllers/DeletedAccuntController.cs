using ClickerSite.Models;
using Microsoft.AspNetCore.Mvc;
using MySql;
using MySql.Data.MySqlClient;

namespace ClickerSite.Controllers;

public class DeletedAccuntController : Controller
{
    private readonly ILogger<DeletedAccuntController> _logger;

    public DeletedAccuntController(ILogger<DeletedAccuntController> logger)
    {
        _logger = logger;
    }

    string connect = "Server=localhost;port=51363;Database=Click;Uid=root;pwd=root;charset=utf8";

    [HttpPost]
    public async Task<IActionResult> DeletedUser(User user, int id)
    {
        var sqlConnect = new MySqlConnection(connect);
        sqlConnect.Open();
        const string command = "DELETE FROM Click WHERE id = @Id";
        var sqlCommand = new MySqlCommand(command, sqlConnect);
        sqlCommand.Parameters.Add("@@Id", MySqlDbType.Int64).Value = id;
        await sqlCommand.ExecuteNonQueryAsync();
        sqlConnect.Close();

        return View();
    }
}