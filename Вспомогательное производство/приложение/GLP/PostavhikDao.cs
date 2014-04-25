using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassLibrary;

namespace GLP
{
    public class PostavhikDao
    {
    
        private static Postavhik Load(SqlDataReader r)
        {
            //Создаём пустой объект
            Postavhik item = new Postavhik();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            item.Adres = r["Adres"].ToString();
            item.IDPostavhik = Convert.ToInt32(r["ID_postavhika"]);
            item.Name = r["Naimenovanie"].ToString();
            item.NomerScheta = r["Nomer_scheta"].ToString();
            item.Phone = r["Phone"].ToString();
           
            return item;
        }

        public static IList<Postavhik> GetAll()
        {

            IList<Postavhik> tov = new List<Postavhik>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Postavhik ";
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



        public static void Add(Postavhik item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO [Postavhik]
                                   ([Naimenovanie]
                                   ,[Adres]
                                   ,[Phone]
                                   ,[Nomer_scheta])
                             VALUES
                                   (@nam
                                   ,@adr
                                   ,@phon
                                   ,@nomSchet)
                    ";
                    cmd.Parameters.AddWithValue("@nam", item.Name);
                    cmd.Parameters.AddWithValue("@adr", item.Adres);
                    cmd.Parameters.AddWithValue("@phon", item.Phone);
                    cmd.Parameters.AddWithValue("@nomSchet", item.NomerScheta);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Postavhik item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" 
                        UPDATE [Postavhik]
                           SET [Naimenovanie] = @nam
                              ,[Adres] = @adr
                              ,[Phone] = @phon
                              ,[Nomer_scheta] = @nomSchet
                         WHERE ID_postavhika=@id";
                    cmd.Parameters.AddWithValue("@nam", item.Name);
                    cmd.Parameters.AddWithValue("@adr", item.Adres);
                    cmd.Parameters.AddWithValue("@phon", item.Phone);
                    cmd.Parameters.AddWithValue("@nomSchet", item.NomerScheta);
                    cmd.Parameters.AddWithValue("@id", item.IDPostavhik);
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
                    cmd.CommandText = "delete Postavhik where ID_postavhika=@ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
