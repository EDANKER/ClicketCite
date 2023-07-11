using System.Data;
using MySql.Data.MySqlClient;

namespace ConnectUser;

public class Select
{
    public string SelectDB()
    {
        while (true)
        {
            try
            {
                var connect = "Server=localhost;port=58583;Database=Shop;Uid=root;pwd=root;charset=utf8";
                var mySQLConnect = new MySqlConnection(connect);

                mySQLConnect.Open();
                Console.WriteLine("connect");
                string sql = "SELECT * FROM `Shop`";
                MySqlCommand sqlCommand = new MySqlCommand(sql, mySQLConnect);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlCommand))
                {
                    DataSet dataSet = new DataSet();

                    adapter.Fill(dataSet);

                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                        {
                            Console.WriteLine(dataRow[i] + "\t");
                        }
                    }
                }
            
                return "";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}