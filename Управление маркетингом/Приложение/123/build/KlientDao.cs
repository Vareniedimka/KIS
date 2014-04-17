using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassLib;
namespace build
{
    public class KlientDao
    {

        private static Klient Load(SqlDataReader r)
        {
            //Создаём пустой объект
            Klient item = new Klient();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных

            item.ID_klienta = Convert.ToInt32(r["ID_klienta"]);
            item.Name_klienta = r["Name_klienta"].ToString();
           // item.LS = r["LS"].ToString();


            return item;
        }

        public static IList<Klient> GetAll()
        {

            IList<Klient> tov = new List<Klient>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM dbo.Klient ";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            tov.Add(Load(dataReader));
                        }
                    }
                }
            }
            return tov;
        }



        public static void Add(Klient item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO [Klient]
                                   ([Name_klienta]
                                   )
                             VALUES
                                   (@nam
                                   )
                    ";
                    cmd.Parameters.AddWithValue("@nam", item.Name_klienta);
               
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Klient item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText ="Update Klient set Name_klienta=@name, LS = @ls where ID_klienta=@id";
                  
                    cmd.Parameters.AddWithValue("@name", item.Name_klienta);
                    cmd.Parameters.AddWithValue("@ls", item.LS);
                    cmd.Parameters.AddWithValue("@id", item.ID_klienta);
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
                    cmd.CommandText = "delete Klient where ID_klienta=@ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
