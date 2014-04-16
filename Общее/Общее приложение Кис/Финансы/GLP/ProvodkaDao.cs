using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLP
{
   public class ProvodkaDao
    {
       public static Provodka Load(SqlDataReader reader)
        {
            //Создаём пустой объект
            Provodka byc = new Provodka();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            byc.ID_provodki = Convert.ToInt32(reader["ID_provodki"]);
            byc.ID_prodazhi = Convert.ToInt32(reader["ID_prodazhi"]);
            byc.ID_Pokupki = Convert.ToInt32(reader["ID_Pokupki"]);
            byc.ID_Oplaty = Convert.ToInt32(reader["ID_Oplaty"]);
            byc.Summa = Convert.ToInt32(reader["Summa"]);
            return byc;
        }

       public Provodka Get(int id)
        {

            using (var conn = Connect.GetConnect())
            {
                //Открываем соединение
                conn.Open();
                //Создаем sql команду
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды
                    cmd.CommandText = "SELECT * FROM Provodka WHERE ID_provodki = @id";
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

       public static IList<Provodka> GetAll()
        {

            IList<Provodka> tov = new List<Provodka>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Provodka ";
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



       public static void Add(Provodka tov)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Provodka (ID_prodazhi,ID_Pokupki,ID_Oplaty,Summa) values (@ID_prodazhi,@ID_Pokupki,@ID_Oplaty,@Summa)";
                    cmd.Parameters.AddWithValue("@ID_prodazhi", tov.ID_prodazhi);
                    cmd.Parameters.AddWithValue("@ID_Pokupki", tov.ID_Pokupki);
                    cmd.Parameters.AddWithValue("@ID_Oplaty", tov.ID_Oplaty);
                    cmd.Parameters.AddWithValue("@Summa", tov.Summa);
                    cmd.ExecuteNonQuery();
                }
            }
        }

       public static void Update(Provodka tov)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Provodka set ID_prodazhi=@ID_prodazhi,ID_Pokupki=@ID_Pokupki,ID_Oplaty=@ID_Oplaty,Summa=@Summa where ID_provodki=@ID";
                    cmd.Parameters.AddWithValue("@ID_prodazhi", tov.ID_prodazhi);
                    cmd.Parameters.AddWithValue("@ID_Pokupki", tov.ID_Pokupki);
                    cmd.Parameters.AddWithValue("@Summa", tov.Summa);
                    cmd.Parameters.AddWithValue("@ID", tov.ID_provodki);
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
                    cmd.CommandText = "delete Provodka where ID_provodki=@ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
