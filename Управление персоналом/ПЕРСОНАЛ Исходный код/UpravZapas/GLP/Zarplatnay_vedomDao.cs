using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassLibrary;

namespace GLP
{
    public class Zarplatnay_vedomDao
    {
        private static Zarplatnay_vedom Load(SqlDataReader r)
        {
            //Создаём пустой объект
            Zarplatnay_vedom item = new Zarplatnay_vedom();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            item.Zarabotn_Plata = Convert.ToInt32(r["Zarabotn_Plata"]);
        //    item.Raschet_zarabotn_platy = Convert.ToInt32(r["Raschet_Zarabot_platy"]);
            item.Tabeln_nom = Convert.ToInt32(r["Tabeln_nom"]);
            item.FIO = Convert.ToString(r["Fio"]);
            return item;
        }

        public static IList<Zarplatnay_vedom> GetAll()
        {

            IList<Zarplatnay_vedom> items = new List<Zarplatnay_vedom>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select *,(Select FIO from Rabociy p where p.Tabeln_nom=z.Tabeln_nom ) as Fio from Zarplatnay_vedom z";
                   
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



        public static void Add(Zarplatnay_vedom item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO [Zarplatnay_vedom]
                               ([Zarabotn_Plata]
                              
                               ,[Tabeln_nom])
                        VALUES
                               (
                                @zarp
                                ,(select Tabeln_nom
		                            from Rabociy
		                            where FIO=@Tab))
                    ";
                    cmd.Parameters.AddWithValue("@zarp", item.Zarabotn_Plata);
                //    cmd.Parameters.AddWithValue("@rasch", item.Raschet_zarabotn_platy);
                    cmd.Parameters.AddWithValue("@Tab", item.FIO);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Zarplatnay_vedom item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [Zarplatnay_vedom]
                       SET [Zarabotn_Plata] = @zarp
		                  ,[Tabeln_nom] = @Tab
                                         ";
                    cmd.Parameters.AddWithValue("@zarp", item.Zarabotn_Plata);
                //    cmd.Parameters.AddWithValue("@rasch", item.Raschet_zarabotn_platy);
                    cmd.Parameters.AddWithValue("@Tab", item.Tabeln_nom);
                    
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
                    cmd.CommandText = "delete [Zarplatnay_vedom] where Tabeln_nom=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
