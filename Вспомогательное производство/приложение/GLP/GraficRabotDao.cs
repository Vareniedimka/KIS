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
            item.DateNachRemont = Convert.ToDateTime(r["Date_nach_remont"]);
            item.VnepanRem = Convert.ToDateTime(r["Vnepan_rem"]);
            item.NaimenovanieDet = Convert.ToString(r["Naimenovanie_det"]);
         //  item.PlanProverkOborud = Convert.ToString(r["PlanProverkOborud"]);
            item.InvertatniyNomer = Convert.ToInt32(r["Invertatniy_nomer"]);
            item.DataOkonchRem = Convert.ToDateTime(r["Data_okonch_rem"]);
         //   item.Raschetn_koef = Convert.ToInt32(r["Raschetn_koef"]);
            return item;
        }

        public static IList<GraficRabot> GetAll()
        {

            IList<GraficRabot> item = new List<GraficRabot>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * from Grafic_rabot";
                       
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
        public static void Add(GraficRabot item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Grafic_Rabot(Naimenovanie_det,Date_nach_remont,Data_okonch_rem,Vnepan_rem,Invertatniy_nomer) values (@naim,@DateNachRemont,@DataOkonchRem,@VnepanRem,@InvertatniyNomer)";
                    cmd.Parameters.AddWithValue("@DateNachRemont", item.DateNachRemont);
                    cmd.Parameters.AddWithValue("@DataOkonchRem", item.DataOkonchRem);
                    cmd.Parameters.AddWithValue("@VnepanRem", item.VnepanRem);
                  //  cmd.Parameters.AddWithValue("@PlanProverkOborud", item.PlanProverkOborud);
                    cmd.Parameters.AddWithValue("@InvertatniyNomer", item.InvertatniyNomer);
                    cmd.Parameters.AddWithValue("@naim", item.NaimenovanieDet);
                 //   cmd.Parameters.AddWithValue("@Raschetn_koef", item.Raschetn_koef);
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
                    cmd.CommandText = "delete Grafic_Rabot where InvertatniyNomer=@InvertatniyNome";
                    cmd.Parameters.AddWithValue("@InvertatniyNome", item.InvertatniyNomer);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
