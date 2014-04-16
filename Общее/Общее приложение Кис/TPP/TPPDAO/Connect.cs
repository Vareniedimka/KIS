using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TPPDAO
{
    public class Connect
    {
        private static string connectInfo;

        /// <summary>
        /// создает строку подключения с проверкой пользователя и пароля
        /// </summary>
        /// <param name="server"></param>
        /// <param name="dataBase"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public static void setConnectInfo(string server, string dataBase, string login, string password)
        {
            connectInfo = "Data Source=" + server + "; Initial Catalog=" + dataBase + "; Integrated Security=false; User ID=" + login + "; Password=" + password;
        }

        /// <summary>
        /// создает строку подклчения без проверки пользователя
        /// </summary>
        /// <param name="server"></param>
        /// <param name="dataBase"></param>
        public static void setConnectInfo(string server, string dataBase)
        {
            connectInfo = "Data Source=" + server + "; Initial Catalog=" + dataBase + "; Integrated Security=true";
        }
        /* /// <summary>
         /// Сохраняет в файл строку подключения s
         /// </summary>
         /// <param name="s">Строка подключения</param>
         public static void ConnectSave(string s) {
             ConnectSet c = ConnectSet.Default;
             c.ConnectString = s;
             c.Save();
         }*/
        /// <summary>
        /// Возвращает подключение
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnect()
        {
            return new SqlConnection(connectInfo);
            // return new SqlConnection(ConnectSet.Default.ConnectString);
        }

    }
}
