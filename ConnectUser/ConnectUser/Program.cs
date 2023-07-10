using System;

namespace ConnectUser
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("1 Регистрация 2 Вход: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine("такого ответа нет");
                    break;
            }
        }
    }
}

