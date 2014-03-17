using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GLP
{
    public class Connect
    {
        /// <summary>
        /// Сохраняет в файл строку подключения s
        /// </summary>
        /// <param name="s">Строка подключения</param>
        public static void ConnectSave(string s) {
            ConnectSet c = ConnectSet.Default;
            c.ConnectString = s;
            c.Save();
        }
        /// <summary>
        /// Возвращает подключение
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnect()
        {
	        return new SqlConnection(ConnectSet.Default.ConnectString);
        }
 
    }
}
