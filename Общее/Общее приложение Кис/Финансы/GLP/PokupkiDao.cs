using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLP
{
  public  class PokupkiDao
    {
      public static Pokupki Load(SqlDataReader reader)
        {
            //Создаём пустой объект
            Pokupki byc = new Pokupki();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            byc.ID_Pokupki = Convert.ToInt32(reader["ID_Pokupki"]);
            byc.Nomer_raschetnogo_platesha = Convert.ToInt32(reader["Nomer_raschetnogo_platesha"]);
            byc.Count = Convert.ToInt32(reader["Count"]);
            return byc;
        }

      public Pokupki Get(int id)
        {

            using (var conn = Connect.GetConnect())
            {
                //Открываем соединение
                conn.Open();
                //Создаем sql команду
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды
                    cmd.CommandText = "SELECT * FROM Pokupki WHERE ID_Pokupki = @id";
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

      public static IList<Pokupki> GetAll()
        {

            IList<Pokupki> tov = new List<Pokupki>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Pokupki ";
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



      public static void Add(Pokupki tov)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Pokupki (Nomer_raschetnogo_platesha,Count) values (@Nomer_raschetnogo_platesha,@Count)";
                    cmd.Parameters.AddWithValue("@Nomer_raschetnogo_platesha", tov.Nomer_raschetnogo_platesha);
                    cmd.Parameters.AddWithValue("@Count", tov.Count);
                    cmd.ExecuteNonQuery();
                }
            }
        }

      public static void Update(Pokupki tov)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Pokupki set Nomer_raschetnogo_platesha=@Nomer_raschetnogo_platesha,Count=@Count where ID_Pokupki=@ID";
                    cmd.Parameters.AddWithValue("@Nomer_raschetnogo_platesha", tov.Nomer_raschetnogo_platesha);
                    cmd.Parameters.AddWithValue("@Count", tov.Count);
                    cmd.Parameters.AddWithValue("@ID", tov.ID_Pokupki);
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
                    cmd.CommandText = "delete Pokupki where ID_Pokupki=@ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
