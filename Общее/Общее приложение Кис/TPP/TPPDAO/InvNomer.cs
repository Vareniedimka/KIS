using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPPDAO;
using System.Data.SqlClient;
using ClassBD;

namespace TPPDAO
{
    public class InvNomer
    {
        private static InvN Load(SqlDataReader r)
        {
            //Создаём пустой объект
            InvN item = new InvN();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            item.InvNom = Convert.ToInt32(r["Invertatniy_nomer"]);
            item.model = Convert.ToString(r["Model"]);
            return item;
        }

        public static IList<InvN> GetAll()
        {

            IList<InvN> items = new List<InvN>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * from Stanok_na_proizv";
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
