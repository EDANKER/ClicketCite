using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace ClickerSite.Models;

public class User
{
    [Required(ErrorMessage = "ввидите данные")]
    [MaxLength(10, ErrorMessage = "Мин")]
    public string Name { get; set; }
    [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "недопустимый формат")]
    [Required(ErrorMessage = "ввидите данные")]
    public string Mail { get; set; }
    [Required(ErrorMessage = "ввидите данные")]
    public string Pass { get; set; }
    [Required(ErrorMessage = "ввидите данные")]
    [Compare("Pass", ErrorMessage = "Пароли не савподают")]
    public string ReplcePass { get; set; }
    [Required(ErrorMessage = "ввидите данные")]
    public int balans { get; set; }
}