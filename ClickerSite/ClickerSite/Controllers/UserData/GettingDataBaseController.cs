using System.Data;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ClickerSite.Controllers;

public class gettingDataBaseController : Controller
{
    string connect = "Server=localhost;port=49745;Database=Click;Uid=root;pwd=root;charset=utf8";

    [HttpGet]
    public async Task<IActionResult> SelectDataBase(string name)
    {
        var listIUser = new List<string>();
        var command = "SELECT * FROM Click";
        var mysqlConnect = new MySqlConnection(connect);
        await mysqlConnect.OpenAsync();
        var sqlCommand = new MySqlCommand(command, mysqlConnect);
        Console.WriteLine(name);
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

        await mysqlConnect.CloseAsync();
        return View(listIUser);
    }
}