using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassLibrary;

namespace GLP
{
    public class Stanok_na_proizvDao
    {
        private static Stanok_na_proizv Load(SqlDataReader r)
        {
            //Создаём пустой объект
            Stanok_na_proizv item = new Stanok_na_proizv();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            item.Invertatniy_nomer = Convert.ToString(r["Invertatniy_nomer"]);
            item.Model = Convert.ToString(r["Model"]);

            item.God_vipuska = Convert.ToDouble(r["God_vipuska"]);
            item.God_vvedeniya_v_expluat = Convert.ToString(r["God_vvedeniya_v_expluat"]);
            
            return item;
        }

        public static IList<Stanok_na_proizv> GetAll()
        {

            IList<Stanok_na_proizv> items = new List<Stanok_na_proizv>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * from Stanok_na_proizv ";
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


        public static void Add(Stanok_na_proizv item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Stanok_na_proizv(Invertatniy_nomer,Model,God_vipuska,God_vvedeniya_v_expluat) values (@Invertatniy_nomer,@Model,@God_vipuska,@God_vvedeniya_v_expluat)";
                    cmd.Parameters.AddWithValue("@Invertatniy_nomer", item.Invertatniy_nomer);
                    cmd.Parameters.AddWithValue("@Model", item.Model);
                    cmd.Parameters.AddWithValue("@God_vipuska", item.God_vipuska);
                    cmd.Parameters.AddWithValue("@God_vvedeniya_v_expluat", item.God_vvedeniya_v_expluat);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Stanok_na_proizv item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Stanok_na_proizv set Invertatniy_nomer = @Invertatniy_nomer,Model = @Model,God_vipuska = @IGod_vipuska,God_vvedeniya_v_expluat = @God_vvedeniya_v_expluat";
                    cmd.Parameters.AddWithValue("@Invertatniy_nomer", item.Invertatniy_nomer);
                    cmd.Parameters.AddWithValue("@Model", item.Model);
                    cmd.Parameters.AddWithValue("@God_vipuska", item.God_vipuska);
                    cmd.Parameters.AddWithValue("@God_vvedeniya_v_expluat", item.God_vvedeniya_v_expluat);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(Stanok_na_proizv item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "delete Stanok_na_proizv  where Invertatniy_nomer = @Invertatniy_nomer";
                    cmd.Parameters.AddWithValue("@Invertatniy_nomer", item.Invertatniy_nomer);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
