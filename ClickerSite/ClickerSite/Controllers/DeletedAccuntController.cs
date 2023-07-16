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

    [HttpDelete]
    public IActionResult DeletedUser(User user)
    {
        string connect = "Server=localhost;port=63705;Database=Click;Uid=root;pwd=root;charset=utf8";
        var sqlConnect = new MySqlConnection(connect);
        sqlConnect.Open();
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
}