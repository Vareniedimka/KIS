using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassLibrary;

namespace GLP
{
   public class Buhgalterski_balansDao
    {
       public static Buhgalterski_balans Load(SqlDataReader reader)
       {
           //Создаём пустой объект
           Buhgalterski_balans byc = new Buhgalterski_balans();
           //Заполняем поля объекта в соответствии с названиями полей результирующего
           // набора данных
           byc.IDByc_balans = Convert.ToInt32(reader["IDByc_balans"]);
           byc.Debit = Convert.ToInt32(reader["Balans"]);
           byc.Kredit = Convert.ToInt32(reader["Debit"]);
           byc.Balans = Convert.ToInt32(reader["Kredit"]);
           return byc;
       }

       public Buhgalterski_balans Get(int id)
       {

           using (var conn = Connect.GetConnect())
           {
               //Открываем соединение
               conn.Open();
               //Создаем sql команду
               using (var cmd = conn.CreateCommand())
               {
                   //Задаём текст команды
                   cmd.CommandText = "SELECT * FROM Buhgalterski_balans WHERE IDByc_balans = @id";
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

       public static IList<Buhgalterski_balans> GetAll()
       {

           IList<Buhgalterski_balans> tov = new List<Buhgalterski_balans>();
           using (var conn = Connect.GetConnect())
           {
               conn.Open();
               using (var cmd = conn.CreateCommand())
               {
                   cmd.CommandText = "SELECT * FROM Buhgalterski_balans ";
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



       public static void Add(Buhgalterski_balans tov)
       {
           using (var conn = Connect.GetConnect())
           {
               conn.Open();
               using (var cmd = conn.CreateCommand())
               {
                   cmd.CommandText = "insert into Buhgalterski_balans (Debit,Kredit,Balans) values (@Debit,@Kredit,@Balans)";
                   cmd.Parameters.AddWithValue("@Debit", tov.Debit);
                   cmd.Parameters.AddWithValue("@Kredit", tov.Kredit);
                   cmd.Parameters.AddWithValue("@Balans", tov.Balans);
                   cmd.ExecuteNonQuery();
               }
           }
       }

       public static void Update(Buhgalterski_balans tov)
       {
           using (var conn = Connect.GetConnect())
           {
               conn.Open();
               using (var cmd = conn.CreateCommand())
               {
                   cmd.CommandText = "update Buhgalterski_balans set Debit=@Debit,Kredit=@Kredit,Balans=@Balans where IDByc_balans=@ID";
                   cmd.Parameters.AddWithValue("@Debit", tov.Debit);
                   cmd.Parameters.AddWithValue("@Kredit", tov.Kredit);
                   cmd.Parameters.AddWithValue("@Balans", tov.Balans);
                   cmd.Parameters.AddWithValue("@ID", tov.IDByc_balans);
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
                   cmd.CommandText = "delete Buhgalterski_balans where IDByc_balans=@ID";
                   cmd.Parameters.AddWithValue("@ID", id);
                   cmd.ExecuteNonQuery();
               }
           }
       }

    }
}