using System;

namespace ConnectUser
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("1 Регистрация 2 Вход 3 посмотреть таблицы: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    var regis = new Regist();
                    Console.WriteLine(regis.InitUser());
                    break;
                case "2":
                    var login = new Login();
                    Console.WriteLine(login.SelectUser());
                    break;
                case "3":
                    var select = new Select();
                    Console.WriteLine(select.SelectDB());
                    break;
                default:
                    Console.WriteLine("такого ответа нет");
                    break;
            }
        }
    }
}

