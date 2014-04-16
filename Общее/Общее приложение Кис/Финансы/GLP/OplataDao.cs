using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Data.SqlClient;

namespace GLP
{
   public class OplataDao
    {
       public static Oplata Load(SqlDataReader reader)
        {
            //Создаём пустой объект
            Oplata byc = new Oplata();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            byc.ID_oplati = Convert.ToInt32(reader["ID_oplati"]);
            byc.DataSdelki = Convert.ToDateTime(reader["Data"]);
            byc.Schet = Convert.ToInt32(reader["Schet"]);
            return byc;
        }

       public Oplata Get(int id)
        {

            using (var conn = Connect.GetConnect())
            {
                //Открываем соединение
                conn.Open();
                //Создаем sql команду
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды
                    cmd.CommandText = "SELECT * FROM Oplata WHERE ID_oplati = @id";
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

       public static IList<Oplata> GetAll()
        {

            IList<Oplata> tov = new List<Oplata>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Oplata ";
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



       public static void Add(Oplata tov)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Oplata (Data,Schet) values (@DataSdelki,@Schet)";
                    cmd.Parameters.AddWithValue("@DataSdelki", tov.DataSdelki);
                    cmd.Parameters.AddWithValue("@Schet", tov.Schet);
                    cmd.ExecuteNonQuery();
                }
            }
        }

       public static void Update(Oplata tov)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Oplata set Data=@DataSdelki,Schet=@Schet where ID_oplati=@ID";
                    cmd.Parameters.AddWithValue("@DataSdelki", tov.DataSdelki);
                    cmd.Parameters.AddWithValue("@Schet", tov.Schet);
                    cmd.Parameters.AddWithValue("@ID", tov.ID_oplati);
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
                    cmd.CommandText = "delete Oplata where ID_oplati=@ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
