using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassBD;

namespace TPPDAO
{
    public class ProfDao
    {
        private static Prof Load(SqlDataReader r)
        {
            //Создаём пустой объект
            Prof item = new Prof();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            item.IdProf = Convert.ToInt32(r["ID_Professii"]);
            item.name = Convert.ToString(r["Naimenovanie"]);
            return item;
        }

        public static IList<Prof> GetAll()
        {

            IList<Prof> items = new List<Prof>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * from Professii";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            items.Add(Load(dataReader));
                        }
                    }
                }
            }
            return items;
        }
    }
}
