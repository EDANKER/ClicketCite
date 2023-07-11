using ConnectUser.UserObject;
using MySql.Data.MySqlClient;

namespace ConnectUser;

public class Regist
{
    public string InitUser()
    {
        while (true)
        {
            try
            {
                var connect = "Server=localhost;port=58583;Database=Shop;Uid=root;pwd=root;charset=utf8";
                var mySQLConnect = new MySqlConnection(connect);

                mySQLConnect.Open();
                Console.WriteLine("конект");
                Console.Write("введите ваш id: ");
                string inputUserId = Console.ReadLine();
                int converId = Convert.ToInt32(inputUserId);
                Console.Write("введите ваш Name: ");
                string inputUserName = Console.ReadLine();
                Console.Write("введите ваш Pass: ");
                string inputUserPass = Console.ReadLine();
                int converPas = Convert.ToInt32(inputUserPass);
            
                var command = $"INSERT INTO `Shop` (Id, name, pass) VALUES ({converId},{inputUserName},{converPas})";
                MySqlCommand sqlCommand = new MySqlCommand(command, mySQLConnect);

                sqlCommand.ExecuteNonQuery().ToString();
                mySQLConnect.Close();
                return inputUserId;
            }
            catch (Exception e)
            {
                Console.WriteLine("не верный ответ");
            }
        }
    }
}