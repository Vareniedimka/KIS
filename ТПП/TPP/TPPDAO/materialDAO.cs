using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassBD;
using System.Data.SqlClient;

namespace TPPDAO
{
    public class materialDAO
    {
        private static Materialy Load(SqlDataReader r)
        {
            //Создаём пустой объект
            Materialy item = new Materialy();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            item.IDMateriala = Convert.ToInt32(r["ID_materiala"]);
            item.Name = Convert.ToString(r["Nazvanie_materiala"]);
            return item;
        }

        public static IList<Materialy> GetAll()
        {

            IList<Materialy> items = new List<Materialy>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * from Materialy ";
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
