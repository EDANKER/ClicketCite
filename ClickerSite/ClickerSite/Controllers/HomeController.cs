using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClickerSite.Models;
using MySql.Data.MySqlClient;

namespace ClickerSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Main() => View();

    [HttpPost]
    public async Task<IActionResult> Main(User user)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ошибка");
                return RedirectToAction("Main", "Home");
            }

            string connect = "Server=localhost;port=54769;Database=Click;Uid=root;pwd=root;charset=utf8";
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
    public IActionResult Authorized(User user)
    {
        var listTable = new List<string>();
        string connect = "Server=localhost;port=54769;Database=Click;Uid=root;pwd=root;charset=utf8";
        var sqlConnect = new MySqlConnection(connect);
        sqlConnect.Open();
        Console.WriteLine("connect");
        var command = "SELECT * FROM Click";
        var sqlCommand = new MySqlCommand(command, sqlConnect);
        using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlCommand))
        {
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                {
                    listTable.Add(dataRow[i].ToString());
                }
            }
        }

        foreach (var listDes in listTable)
        {
            Console.WriteLine(listDes);
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ошибка");
            }
        }

        return View();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}