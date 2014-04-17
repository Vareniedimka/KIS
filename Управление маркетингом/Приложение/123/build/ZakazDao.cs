using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassLib;
namespace build
{
    public class ZakazDao
    {
        private static Zakaz Load(SqlDataReader r)
        {
            //Создаём пустой объект
            Zakaz item = new Zakaz();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных

            item.ID_zakaza = Convert.ToInt32(r["ID_zakaza"]);
            item.ID_klienta = Convert.ToString(r["ID_klienta"]);
            item.ID_DCE = Convert.ToString(r["ID_DCE"]);
            //item.NaimenovanieDCE = Convert.ToString(r["NaimenovanieDCE"]);
            //item.KlientName = Convert.ToString(r["KlientName"]);
        //    item.Avans = Convert.ToInt32(r["Avans"]);

            return item;
        }

        public static IList<Zakaz> GetAll()
        {

            IList<Zakaz> items = new List<Zakaz>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" SELECT ID_zakaza,
(select Name_klienta from Klient k where k.ID_klienta=z.ID_klienta) as ID_klienta,
(select Naimenovanie from DSE d where d.ID_DCE =z.ID_DCE) as ID_DCE from dbo.Zakaz z ";
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



        public static void Add(Zakaz item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [Zakaz]
                               (
                               [ID_klienta]
                               ,[ID_DCE],
                                [Avans])
          
                         VALUES
                               (
                               
                               (select ID_klienta from Klient k where k.Name_klienta  like @name)
                              ,(select ID_DCE from DSE d where d.Naimenovanie like  @nameDce),
                               @av


                               )
                    ";
                    cmd.Parameters.AddWithValue("@name", item.KlientName);
                    cmd.Parameters.AddWithValue("@nameDce", item.NaimenovanieDCE);
                    cmd.Parameters.AddWithValue("@av", item.Avans);


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Zakaz item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE [Zakaz]
                           SET 
                               [ID_klienta] =(select ID_klienta from Klient k where k.Name_klienta = @dof)
                               ,[ID_DCE] =(select ID_DCE from DSE d where d.Naimenovanie like  @dvi),
                                [Avans] = @av
           
                        WHERE ID_zakaza=@id
                    ";
                    
                    cmd.Parameters.AddWithValue("@dof", item.KlientName);
                    cmd.Parameters.AddWithValue("@dvi", item.NaimenovanieDCE);
                    cmd.Parameters.AddWithValue("@av", item.Avans);
                    cmd.Parameters.AddWithValue("@id", item.ID_zakaza);

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
                    cmd.CommandText = "delete Zakaz where ID_zakaza=@ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

     
    }
}
