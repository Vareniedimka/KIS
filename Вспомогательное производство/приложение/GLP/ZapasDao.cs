using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassLibrary;

namespace GLP
{
    public class ZapasDao
    {
        private static Zapas Load(SqlDataReader r)
        {
            //Создаём пустой объект
            Zapas item = new Zapas();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            item.IDMateriala = Convert.ToInt32(r["ID_materiala"]);
            item.MaterialName = Convert.ToString(r["nameM"]);
            item.Kolichestvo = Convert.ToInt32(r["Kolichestvo"]);
                      
            return item;
        }

        public static IList<Zapas> GetAll()
        {

            IList<Zapas> items = new List<Zapas>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT *,(
                            select Nazvanie_materiala
	                        from Materialy
	                        where mup.ID_materiala = ID_materiala
                        ) as nameM
                        from Zapasi mup
                    ";
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



        public static void Add(Zapas item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO [Zapasi]
                                   ([ID_materiala]
                                   ,[Kolichestvo])
                             VALUES
                                   ((
		                                select ID_materiala
		                                from Materialy
		                                where Nazvanie_materiala=@nameM
		                            )
                                   ,@kol)
                    ";
                    cmd.Parameters.AddWithValue("@kol", item.Kolichestvo);
                    cmd.Parameters.AddWithValue("@nameM", item.MaterialName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Zapas item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                         UPDATE [Zapasi]
                           SET [ID_materiala] = (
		                                select ID_materiala
		                                from Materialy
		                                where Nazvanie_materiala=@nameM
		                            )
                              ,[Kolichestvo] = @kol
                         WHERE ID_materiala=@id
                    ";

                    cmd.Parameters.AddWithValue("@kol", item.Kolichestvo);
                    cmd.Parameters.AddWithValue("@nameM", item.MaterialName);
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
                    cmd.CommandText = "delete Zapasi where ID_materiala=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
