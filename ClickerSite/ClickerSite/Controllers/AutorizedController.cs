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

    [HttpPost]
    public async Task<IActionResult> Registartion(User user)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Registartion");
            }

            string connect = "Server=localhost;port=63705;Database=Click;Uid=root;pwd=root;charset=utf8";
            var sqlConnect = new MySqlConnection(connect);
            sqlConnect.Open();
            Console.WriteLine("connect");
            var command = "INSERT INTO Click(name,mail,pass,replace_pass) VALUES (@Name, @Mail, @Pass, @Replace_Pass)";
            var sqlCommand = new MySqlCommand(command, sqlConnect);
            sqlCommand.Parameters.Add("@Name", MySqlDbType.Text).Value = user.Name;
            sqlCommand.Parameters.Add("@Mail", MySqlDbType.Text).Value = user.Mail;
            sqlCommand.Parameters.Add("@Pass", MySqlDbType.Text).Value = user.Pass;
            sqlCommand.Parameters.Add("@Replace_Pass", MySqlDbType.Text).Value = user.ReplcePass;
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
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
            string connect = "Server=localhost;port=63705;Database=Click;Uid=root;pwd=root;charset=utf8";
            var sqlConnect = new MySqlConnection(connect);
            sqlConnect.Open();
            Console.WriteLine("connect");
            var command = "SELECT EXISTS(SELECT * FROM Click WHERE name = @Name AND pass = @Pass)";
            var sqlCommand = new MySqlCommand(command, sqlConnect);
            sqlCommand.Parameters.Add("@Name", MySqlDbType.Text).Value = user.Name;
            sqlCommand.Parameters.Add("@Pass", MySqlDbType.Text).Value = user.Pass;
            var exist = sqlCommand.ExecuteScalar();
            var converBoolean = Convert.ToBoolean(exist);
            if (!converBoolean && !ModelState.IsValid)
            {
                return RedirectToAction("Registartion");
            }
            return View();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}