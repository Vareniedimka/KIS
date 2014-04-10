using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassLibrary;

namespace GLP
{
    public class RabociyDao
    {
        private static Rabociy Load(SqlDataReader r)
        {
            //Создаём пустой объект
            Rabociy item = new Rabociy();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            item.Tabeln_nom = Convert.ToInt32(r["Tabeln_nom"]);
            item.IDProfesii = Convert.ToInt32(r["ID_Professii"]);
            item.Naimenovanie =  Convert.ToString(r["Naimenovanie"]);
            item.FIO = Convert.ToString(r["FIO"]);
            item.Zareg_brak = Convert.ToString(r["Zareg_brak"]);
                        
            return item;
        }
       
        public static IList<Rabociy> GetAll()
        {

            IList<Rabociy> items = new List<Rabociy>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                       @"select *,(Select Naimenovanie from Professii p where p.ID_Professii=r.ID_Professii ) as Naimenovanie from Rabociy r "; ; 
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


        public static void Add(Rabociy item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO [Rabociy]
                               ([Tabeln_nom]
                               ,[ID_Professii]
                               ,[Zareg_brak]
                               ,[FIO]  )    
                         VALUES
                               (@tab
                               ,( select ID_Professii
		                            from Professii
		                            where Naimenovanie=@naim)
                               ,@zareg
                               ,@FIO    )";
                    cmd.Parameters.AddWithValue("@tab", item.Tabeln_nom);
                    cmd.Parameters.AddWithValue("@naim", item.Naimenovanie);
                    cmd.Parameters.AddWithValue("@zareg", item.Zareg_brak);
                    cmd.Parameters.AddWithValue("@FIO", item.FIO);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Rabociy item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [Rabociy]
                           SET [Tabeln_nom] = @tab
                              ,[Zareg_brak] = @stav
                              ,[FIO]=@fio
                              WHERE ID_professii=@id
                    ";

                    cmd.Parameters.AddWithValue("@tab", item.Tabeln_nom);
                    cmd.Parameters.AddWithValue("@id", item.IDProfesii);
                    cmd.Parameters.AddWithValue("@zare", item.Zareg_brak);
                    cmd.Parameters.AddWithValue("@fio", item.FIO);



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
                    cmd.CommandText = "delete Rabociy  where Tabeln_nom = @id ";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
