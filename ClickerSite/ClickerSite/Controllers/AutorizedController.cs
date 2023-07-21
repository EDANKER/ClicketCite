using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClickerSite.Models;
using MySql.Data.MySqlClient;

namespace ClickerSite.Controllers;

public class AutorizedController : Controller
{
    private readonly ILogger<AutorizedController> _logger;

    public AutorizedController(ILogger<AutorizedController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Registartion() => View();

    string connect = "Server=localhost;port=51363;Database=Click;Uid=root;pwd=root;charset=utf8";

    [HttpPost]
    public async Task<IActionResult> Registartion(User user)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Registartion");
            }

            var sqlConnect = new MySqlConnection(connect);
            await sqlConnect.OpenAsync();
            Console.WriteLine("connect");
            var command =
                "INSERT INTO Click(name,mail,pass,replace_pass, balans) VALUES (@Name, @Mail, @Pass, @Replace_Pass, @Balans)";
            var sqlCommand = new MySqlCommand(command, sqlConnect);
            sqlCommand.Parameters.Add("@Name", MySqlDbType.Text).Value = user.Name;
            sqlCommand.Parameters.Add("@Mail", MySqlDbType.Text).Value = user.Mail;
            sqlCommand.Parameters.Add("@Pass", MySqlDbType.Text).Value = user.Pass;
            sqlCommand.Parameters.Add("@Replace_Pass", MySqlDbType.Text).Value = user.ReplcePass;
            sqlCommand.Parameters.Add("@Balans", MySqlDbType.Int64).Value = 0;
            await sqlCommand.ExecuteNonQueryAsync();
            await sqlConnect.CloseAsync();
            return View();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost]
    public async Task<IActionResult> Login(User user)
    {
        try
        {
            var sqlConnect = new MySqlConnection(connect);
            sqlConnect.Open();
            Console.WriteLine("connect");
            var command = "SELECT EXISTS(SELECT * FROM Click WHERE name = @Name AND pass = @Pass)";
            var sqlCommand = new MySqlCommand(command, sqlConnect);
            sqlCommand.Parameters.Add("@Name", MySqlDbType.Text).Value = user.Name;
            sqlCommand.Parameters.Add("@Pass", MySqlDbType.Text).Value = user.Pass;
            var exist = await sqlCommand.ExecuteScalarAsync();
            var convertBoolean = Convert.ToBoolean(exist);
            if (!convertBoolean && !ModelState.IsValid)
            {
                return RedirectToAction("Registartion");
            }

            await sqlConnect.CloseAsync();
            var listName = new List<string>();
            listName.Add(user.Name);
            return View(listName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}