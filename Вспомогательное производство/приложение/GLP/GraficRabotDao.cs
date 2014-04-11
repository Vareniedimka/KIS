using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassLibrary;

namespace GLP
{
    public class GraficRabotDao
    {
        private static GraficRabot Load(SqlDataReader r)
        {
            //Создаём пустой объект
            GraficRabot item = new GraficRabot();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            item.DateNachRemont = Convert.ToDateTime(r["DateNachRemont"]);
            item.VnepanRem = Convert.ToDateTime(r["VnepanRem"]);
            item.NaimenovanieDet = Convert.ToString(r["NaimenovanieDet"]);
            item.PlanProverkOborud = Convert.ToString(r["PlanProverkOborud"]);
            item.InvertatniyNomer = Convert.ToInt32(r["InvertatniyNomer"]);
            item.DataOkonchRem = Convert.ToDateTime(r["DataOkonchRem"]);
            item.Raschetn_koef = Convert.ToDouble(r["Raschetn_koef"]);
            return item;
        }

        public static IList<GraficRabot> GetAll()
        {

            IList<GraficRabot> items = new List<GraficRabot>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * from GraficRabot";
                       
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
        public static void Add(GraficRabot item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                { 
                    cmd.CommandText = "insert into GraficRabot(DateNachRemont,DataOkonchRem,VnepanRem,PlanProverkOborud,InvertatniyNomer,Raschetn_koef) values (@DateNachRemont,@DataOkonchRem,@VnepanRem,@PlanProverkOborud,@InvertatniyNomer,@Raschetn_koef)";
                    cmd.Parameters.AddWithValue("@DateNachRemont", item.DateNachRemont);
                    cmd.Parameters.AddWithValue("@DataOkonchRem", item.DataOkonchRem);
                    cmd.Parameters.AddWithValue("@VnepanRem", item.VnepanRem);
                    cmd.Parameters.AddWithValue("@PlanProverkOborud", item.PlanProverkOborud);
                    cmd.Parameters.AddWithValue("@InvertatniyNomer", item.InvertatniyNomer);
                    cmd.Parameters.AddWithValue("@Raschetn_koef", item.Raschetn_koef);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(GraficRabot item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                   cmd.CommandText = "update GraficRabot set DateNachRemont = @DateNachRemont,DataOkonchRem = @DataOkonchRem,VnepanRem= @VnepanRem, PlanProverkOborud= @PlanProverkOborud, InvertatniyNomer= @InvertatniyNomer, Raschetn_koef= @Raschetn_koef  " ;
                   cmd.Parameters.AddWithValue("@DateNachRemont", item.DateNachRemont);
                   cmd.Parameters.AddWithValue("@DataOkonchRem", item.DataOkonchRem);
                   cmd.Parameters.AddWithValue("@VnepanRem", item.VnepanRem);
                   cmd.Parameters.AddWithValue("@PlanProverkOborud", item.PlanProverkOborud);
                   cmd.Parameters.AddWithValue("@InvertatniyNomer", item.InvertatniyNomer);
                   cmd.Parameters.AddWithValue("@Raschetn_koef", item.Raschetn_koef);
                    cmd.ExecuteNonQuery();
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(GraficRabot item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "delete [GraficRabot] where InvertatniyNomer=@InvertatniyNome";
                    cmd.Parameters.AddWithValue("@InvertatniyNome", item.InvertatniyNomer);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
