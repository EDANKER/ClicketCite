using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace ClickerSite.Models;

public class User
{
    [Required(ErrorMessage = "ввидите данные")]
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Pass { get; set; }
    public string ReplcePass { get; set; }
}