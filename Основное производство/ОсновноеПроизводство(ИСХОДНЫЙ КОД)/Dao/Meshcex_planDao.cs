using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassBD;
using System.Data.SqlClient;

namespace OPDao
{
    public class Meshcex_planDAO
    {
        private static Meshcex_plan Load(SqlDataReader reader)
        {
            //Sozdaem pustoi obekt
            Meshcex_plan qq = new Meshcex_plan();
            qq.Data_nach_vip_plan_na_mesyc=Convert.ToDateTime(reader["Data_nach_vip_plan_na_mesyc"]);
qq. Data_okonch_vip_plan_na_mesyc= Convert.ToDateTime(reader["Data_okonch_vip_plan_na_mesyc"]);
 qq. ID_DCE= Convert.ToInt32(reader["ID_DCE"]);
 qq. Naimenovanie_det= Convert.ToString(reader["Naimenovanie_det"]);
 qq. Poryadok_vip_det= Convert.ToInt32(reader["Poryadok_vip_det"]);
 qq. Obhee_zaplan_kol= Convert.ToInt32(reader["Obhee_zaplan_kol"]);
qq. Obhee_fact_kol= Convert.ToInt32(reader["Obhee_fact_kol"]);
qq. Plan_det_den= Convert.ToInt32(reader["Plan_det_den"]);
qq. Ostatok_sklad= Convert.ToInt32(reader["Ostatok_sklad"]);
qq. Neobh_vip= Convert.ToInt32(reader["Neobh_vip"]);
            return qq;

        }
   public static IList< Meshcex_plan> GetAll()
        {
            IList< Meshcex_plan> qw = new List< Meshcex_plan>();

            using (var conn = Connect.GetConnect())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = " select *,(select Naimenovanie from DSE where ID_DCE = Meshcex_plan.ID_DCE)  as Naimenovanie_det from Meshcex_plan";
                    using (var datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            qw.Add(Load(datareader));
                        }
                    }
                }
            }
            return qw;
        }
        public static void Add(Meshcex_plan qww)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Meshcex_plan (Data_nach_vip_plan_na_mesyc, Data_okonch_vip_plan_na_mesyc, ID_DCE, Naimenovanie_det, Poryadok_vip_det, Obhee_zaplan_kol, Obhee_fact_kol, Plan_det_den, Ostatok_sklad, Neobh_vip ) values(@Data_nach_vip_plan_na_mesyc, @Data_okonch_vip_plan_na_mesyc, @ID_DCE,(Select d.ID_DSE  from DSE d where d.Naimenovanie = @ Naimenovanie_det), @Poryadok_vip_det, @Obhee_zaplan_kol, @Obhee_fact_kol, @Plan_det_den, @Ostatok_sklad, @Neobh_vip)";
                      cmd.Parameters.AddWithValue("@Data_nach_vip_plan_na_mesyc ", qww. Data_nach_vip_plan_na_mesyc);
                      cmd.Parameters.AddWithValue("@Data_okonch_vip_plan_na_mesyc ", qww. Data_okonch_vip_plan_na_mesyc);
                      cmd.Parameters.AddWithValue("@ID_DCE ", qww. ID_DCE);
                      cmd.Parameters.AddWithValue("@Naimenovanie_det ", qww. Naimenovanie_det);
                      cmd.Parameters.AddWithValue("@Poryadok_vip_det ", qww.Poryadok_vip_det);
                      cmd.Parameters.AddWithValue("@Obhee_zaplan_kol ", qww.Obhee_zaplan_kol);
                      cmd.Parameters.AddWithValue("@Obhee_fact_kol ", qww. Obhee_fact_kol);
                      cmd.Parameters.AddWithValue("@Plan_det_den ", qww. Plan_det_den);
                      cmd.Parameters.AddWithValue("@Ostatok_sklad ", qww. Ostatok_sklad);
                      cmd.Parameters.AddWithValue("@Neobh_vip ", qww. Neobh_vip);
                      cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Update(Meshcex_plan qww)
        {
            using (var conn = Connect.GetConnect())
            { 
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Meshcex_plan set Data_okonch_vip_plan_na_mesyc = @ Data_okonch_vip_plan_na_mesyc, ID_DCE = @ ID_DCE, Naimenovanie_det = @ Naimenovanie_det, Poryadok_vip_det = @ Poryadok_vip_det, Obhee_zaplan_kol = @ Obhee_zaplan_kol, Obhee_fact_kol = @ Obhee_fact_kol, Plan_det_den = @ Plan_det_den, Ostatok_sklad = @Ostatok_sklad, Neobh_vip= @Neobh_vip where Data_nach_vip_plan_na_mesyc = @st ";
                    cmd.Parameters.AddWithValue("@Data_nach_vip_plan_na_mesyc ", qww. Data_nach_vip_plan_na_mesyc);
                    cmd.Parameters.AddWithValue("@Data_okonch_vip_plan_na_mesyc ", qww. Data_okonch_vip_plan_na_mesyc);
                    cmd.Parameters.AddWithValue("@ID_DCE ", qww. ID_DCE);
                    cmd.Parameters.AddWithValue("@Naimenovanie_det ", qww. Naimenovanie_det);
                    cmd.Parameters.AddWithValue("@Poryadok_vip_det ", qww.Poryadok_vip_det);
                    cmd.Parameters.AddWithValue("@Obhee_zaplan_kol ", qww.Obhee_zaplan_kol);
                    cmd.Parameters.AddWithValue("@Obhee_fact_kol ", qww. Obhee_fact_kol);
                    cmd.Parameters.AddWithValue("@Plan_det_den ", qww. Plan_det_den);
                    cmd.Parameters.AddWithValue("@Ostatok_sklad ", qww. Ostatok_sklad);
                    cmd.Parameters.AddWithValue("@Neobh_vip ", qww. Neobh_vip);
                    cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                }
                }

                }
        public static void Delete(DateTime st)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "delete Meshcex_plan where Data_nach_vip_plan_na_mesyc= @st ";
                    cmd.Parameters.AddWithValue("@st", st);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

