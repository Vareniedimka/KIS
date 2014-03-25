using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassLibrary;

namespace GLP
{
    public class MaterialDao
    {
        private static Material Load(SqlDataReader r)
        {
            //Создаём пустой объект
            Material item = new Material();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            item.Cena = Convert.ToDouble(r["Cena"]);
            item.EdinIzm = Convert.ToString(r["Edinica_izmereniy"]);
            item.IDMateriala = Convert.ToInt32(r["ID_materiala"]);
            item.Name = Convert.ToString(r["Nazvanie_materiala"]);
                      
            return item;
        }

        public static IList<Material> GetAll()
        {

            IList<Material> items = new List<Material>();
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



        public static void Add(Material item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO [Materialy]
                               ([Nazvanie_materiala]
                               ,[Cena]
                               ,[Edinica_izmereniy])
                         VALUES
                               (@nazv
                               ,@cen
                               ,@em)
                    ";
                    cmd.Parameters.AddWithValue("@nazv", item.Name);
                    cmd.Parameters.AddWithValue("@cen", item.Cena);
                    cmd.Parameters.AddWithValue("@em", item.EdinIzm);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Material item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                         UPDATE [Materialy]
                           SET [Nazvanie_materiala] = @nazv
                              ,[Cena] = @cen
                              ,[Edinica_izmereniy] = @em
                         WHERE ID_materiala=@id
                    ";

                    cmd.Parameters.AddWithValue("@nazv", item.Name);
                    cmd.Parameters.AddWithValue("@cen", item.Cena);
                    cmd.Parameters.AddWithValue("@em", item.EdinIzm);
                    cmd.Parameters.AddWithValue("@id", item.IDMateriala);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        public static void Delete(int id)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "delete Materialy where ID_materiala=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
