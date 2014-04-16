using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLP
{
  public class prodazhiDao
    {
      public static prodazhi Load(SqlDataReader reader)
        {
            //Создаём пустой объект
            prodazhi byc = new prodazhi();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            byc.ID_prodazhi = Convert.ToInt32(reader["ID_prodazhi"]);
            byc.DataSdelki = Convert.ToDateTime(reader["Data"]);
            byc.Nomer_raschetnogo_platesha = Convert.ToInt32(reader["Nomer_raschetnogo_platesha"]);
            byc.Opisanie = (reader["Opisanie"]).ToString();
            return byc;
        }

      public prodazhi Get(int id)
        {

            using (var conn = Connect.GetConnect())
            {
                //Открываем соединение
                conn.Open();
                //Создаем sql команду
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды
                    cmd.CommandText = "SELECT * FROM prodazhi WHERE ID_prodazhi = @id";
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

      public static IList<prodazhi> GetAll()
        {

            IList<prodazhi> tov = new List<prodazhi>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM prodazhi ";
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



      public static void Add(prodazhi tov)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into prodazhi (Data,Nomer_raschetnogo_platesha,Opisanie) values (@DataSdelki,@Nomer_raschetnogo_platesha,@Opisanie)";
                    cmd.Parameters.AddWithValue("@DataSdelki", tov.DataSdelki);
                    cmd.Parameters.AddWithValue("@Nomer_raschetnogo_platesha", tov.Nomer_raschetnogo_platesha);
                    cmd.Parameters.AddWithValue("@Opisanie", tov.Opisanie);
                    cmd.ExecuteNonQuery();
                }
            }
        }

      public static void Update(prodazhi tov)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update prodazhi set Data=@DataSdelki,Nomer_raschetnogo_platesha=@Nomer_raschetnogo_platesha,Opisanie=@Opisanie where ID_prodazhi=@ID";
                    cmd.Parameters.AddWithValue("@DataSdelki", tov.DataSdelki);
                    cmd.Parameters.AddWithValue("@Nomer_raschetnogo_platesha", tov.Nomer_raschetnogo_platesha);
                    cmd.Parameters.AddWithValue("@Opisanie", tov.Opisanie);
                    cmd.Parameters.AddWithValue("@ID", tov.ID_prodazhi);
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
                    cmd.CommandText = "delete prodazhi where ID_prodazhi=@ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
