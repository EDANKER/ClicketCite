using ConnectUser.UserObject;
using MySql.Data.MySqlClient;

namespace ConnectUser;

public class Regist
{
    public async Task<string> InitUser()
    {
        try
        {
            var connect = "Server=localhost;port=49752;Database=Shop;Uid=root;pwd=root;charset=utf8";
            var mySQLConnect = new MySqlConnection(connect);

            mySQLConnect.Open();
            Console.Write("конект");
            Console.Write("введите ваш id: ");
            string inputUserId = Console.ReadLine();
            Console.Write("введите ваш Name: ");
            string inputUserName = Console.ReadLine();
            Console.Write("введите ваш Pass: ");
            string inputUserPass = Console.ReadLine();
            
            var command = "INSERT INTO Shop (Id, name, pass) VALUES ('2', `Edg2ar`, `12342567`)";
            MySqlCommand sqlCommand = new MySqlCommand(command, mySQLConnect);
            
            int push = sqlCommand.ExecuteNonQuery();
            if (push > 0)
            {
                Console.WriteLine("good");
            }
            mySQLConnect.Close();
            return inputUserId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}