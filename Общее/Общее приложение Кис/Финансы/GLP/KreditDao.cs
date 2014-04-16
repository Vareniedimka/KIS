using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Data.SqlClient;

namespace GLP
{
   public class KreditDao
    {
        public static Kredit  Load(SqlDataReader reader)
        {
            //Создаём пустой объект
            Kredit byc = new Kredit();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            byc.ID_kredita = Convert.ToInt32(reader["ID_kredita"]);
            byc.Summa = Convert.ToInt32(reader["Summa"]);
            byc.DataSdelki = Convert.ToDateTime(reader["DataSdelki"]);
            return byc;
        }

        public Kredit Get(int id)
        {

            using (var conn = Connect.GetConnect())
            {
                //Открываем соединение
                conn.Open();
                //Создаем sql команду
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды
                    cmd.CommandText = "SELECT * FROM Kredit WHERE ID_kredita = @id";
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

        public static IList<Kredit> GetAll()
        {

            IList<Kredit> tov = new List<Kredit>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Kredit ";
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



        public static void Add(Kredit tov)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Kredit (Summa,DataSdelki) values (@Summa,@DataSdelki)";
                    cmd.Parameters.AddWithValue("@Summa", tov.Summa);
                    cmd.Parameters.AddWithValue("@DataSdelki", tov.DataSdelki);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Kredit tov)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Kredit set Summa=@Summa,DataSdelki=@DataSdelki where ID_kredita=@ID";
                    cmd.Parameters.AddWithValue("@Summa", tov.Summa);
                    cmd.Parameters.AddWithValue("@DataSdelki", tov.DataSdelki);
                    cmd.Parameters.AddWithValue("@ID", tov.ID_kredita);
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
                    cmd.CommandText = "delete Kredit where ID_kredita=@ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
