using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassLibrary;
namespace GLP
{
    public class DetdlyaremDao
    {
        private static Detdlyarem Load(SqlDataReader r)
        {
            //Создаём пустой объект
            Detdlyarem item = new Detdlyarem();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных

            item.NaimenovanieDet = Convert.ToString(r["Naimenovanie_det"]);
            item.Kolichestv = Convert.ToDouble(r["Kolichestv"]);
                      
            return item;
        }

        public static IList<Detdlyarem> GetAll()
        {

            IList<Detdlyarem> item = new List<Detdlyarem>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * from Det_dlya_rem ";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            item.Add(Load(dataReader));
                        }
                    }
                }
            }
            return item;
        }



        public static void Add(Detdlyarem item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO [Det_dlya_rem]
                               ([Naimenovanie_det]
                               ,[Kolichestv]
                               )
                         VALUES
                               (@nazv
                               ,@kol
                               )
                    ";
                    cmd.Parameters.AddWithValue("@nazv", item.NaimenovanieDet);
                    cmd.Parameters.AddWithValue("@kol", item.Kolichestv);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Detdlyarem item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Detdlyarem set Naimenovanie_det = @NaimenovanieDet,Kolichestv = @Kolichestv";
                    cmd.Parameters.AddWithValue("@nazv", item.NaimenovanieDet);
                    cmd.Parameters.AddWithValue("@kol", item.Kolichestv);
                    cmd.ExecuteNonQuery();
                }

                    
                }
            }
        
        
        public static void Delete( Detdlyarem item)
        {
            {
            using (var conn =  Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "delete Det_dlya_rem where  Naimenovanie_det =@Nazv ";
                    cmd.Parameters.AddWithValue("@nazv", item.NaimenovanieDet);
                    //cmd.Parameters.AddWithValue("@kol", item.Kolichestv);
                    cmd.ExecuteNonQuery();
                }

                    
                }
            }
            }
        }

    }

