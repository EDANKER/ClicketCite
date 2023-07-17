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

    string connect = "Server=localhost;port=56691 ;Database=Click;Uid=root;pwd=root;charset=utf8";

    [HttpPut]
    public async Task<IActionResult> UpdateDataUser(User user)
    {
        var command = "UPDATE Click SET name = @Name WHERE name = @OldName ";
        var sqlConnect = new MySqlConnection(connect);
        sqlConnect.Open();
        var sqlCommand = new MySqlCommand(command, sqlConnect);
        sqlCommand.Parameters.Add("@Name", MySqlDbType.Text).Value = user.Name;
        sqlCommand.Parameters.Add("@OldName", MySqlDbType.Text).Value = user.Name;
        sqlCommand.ExecuteNonQuery();
        return View();
    }

    [HttpGet]
    public async Task<string> SelectDataBase()
    {
        var listIUser = new List<string>();
        var command = "SELECT * FROM Click";
        var mysqlConnect = new MySqlConnection(connect);
        mysqlConnect.Open();
        var sqlCommand = new MySqlCommand(command, mysqlConnect);
        var sqlAdapder = new MySqlDataAdapter(sqlCommand);
        DataSet dataSet = new DataSet();
        await sqlAdapder.FillAsync(dataSet);
        foreach (DataRow dataRow in dataSet.Tables[0].Rows)
        {
            for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
            {
                listIUser.Add(dataRow[i].ToString());
            }
        }

        var listDataUser = "";
        foreach (var listDes in listIUser)
        {
            listDataUser = listDes;
        }
        return listDataUser;
    }
}