using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using OPDao;

namespace OPDao
{
    public class Connect
    {
        /// <summary>
        /// Сохраняет в файл строку подключения s
        /// </summary>
        /// <param name="s">Строка подключения</param>
        public static void ConnectSave(string s)
        {
            ConnectSettings c = ConnectSettings.Default;
            c.ConnectString = s;
            c.Save();
        }
        public static SqlConnection GetConnect()
        {
            return new SqlConnection(ConnectSettings.Default.ConnectString);
        }
    }
}
