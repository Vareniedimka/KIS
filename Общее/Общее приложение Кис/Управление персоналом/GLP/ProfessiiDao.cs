using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassLibrary;

namespace GLP
{
    public class ProfessiiDao
    {
        private static Professii Load(SqlDataReader r)
        {
            //Создаём пустой объект
            Professii item = new Professii();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            item.Stavka_v_chas = Convert.ToInt32(r["Stavka_v_chas"]);
            item.ID_professii = Convert.ToInt32(r["ID_professii"]);
            item.Naimenovanie = Convert.ToString(r["Naimenovanie"]);
            item.Razryad_rabochego=Convert.ToString(r["Razryad_rabochego"]);
                      
            return item;
        }
        public Professii Get(int id)
        {

            using (var conn = Connect.GetConnect())
            {
                //Открываем соединение
                conn.Open();
                //Создаем sql команду
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды
                    cmd.CommandText = "SELECT * FROM Professii WHERE ID_professii = @id ";
                    //Добавляем значение параметра
                    cmd.Parameters.AddWithValue("@id", id);
                    //Открываем SqlDataReader для чтения полученных в результате
                    //выполнения запроса данных
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : Load(dataReader);
                    }
                }
            }
        }
        public static IList<Professii> GetAll()
        {

            IList<Professii> items = new List<Professii>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * from Professii ";
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



        public static void Add(Professii item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO [Professii]
                               ([Stavka_v_chas]
                               
                               ,[Naimenovanie]
                                ,[Razryad_rabochego])
                         VALUES
                               (@stav
                               
                               ,@naim
                                ,@razr)
                    ";
                    cmd.Parameters.AddWithValue("@stav", item.Stavka_v_chas);
               
                    cmd.Parameters.AddWithValue("@naim", item.Naimenovanie);
                    cmd.Parameters.AddWithValue("@razr", item.Razryad_rabochego);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Professii item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                         UPDATE [Professii]
                           SET [Naimenovanie] = @naim
                              ,[Stavka_v_chas] = @stav
                              ,[Razryad_rabochego]=@razr
                              WHERE ID_professii=@id
                    ";

                    cmd.Parameters.AddWithValue("@naim", item.Naimenovanie);
                    cmd.Parameters.AddWithValue("@stav", item.Stavka_v_chas);
                    cmd.Parameters.AddWithValue("@razr", item.Razryad_rabochego);
                    cmd.Parameters.AddWithValue("@id", item.ID_professii);

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
                    cmd.CommandText = "delete Professii where ID_professii=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
