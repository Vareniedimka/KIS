using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassBD;
using System.Data.SqlClient;

namespace OPDao
{
    public class Plan_sbor_cexaDAO
    {
        private static Plan_sbor_cexa Load(SqlDataReader reader)
        {
            //Sozdaem pustoi obekt
            Plan_sbor_cexa ww= new Plan_sbor_cexa ();
            ww.Data_nach_vip_plan = Convert.ToDateTime(reader["Data_nach_vip_plan"]);
            ww.Data_okonch_vip_plan = Convert.ToDateTime(reader["Data_okonch_vip_plan"]);
            ww.Poryadok_vip_det = Convert.ToInt32(reader["Poryadok_vip_det"]);
            ww.Obhee_fact_kol = Convert.ToInt32(reader["Obhee_fact_kol"]);
            ww.Plan_det_den = Convert.ToInt32(reader["Plan_det_den"]);
            ww.Fact_det_den = Convert.ToInt32(reader["Fact_det_den"]);
            ww.ID_DCE = Convert.ToInt32(reader["ID_DCE"]);
            return ww;

        }

        public static IList<Plan_sbor_cexa> GetAll()
        {
            IList<Plan_sbor_cexa> we = new List<Plan_sbor_cexa>();

            using (var conn = Connect.GetConnect())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = " select * from Plam_sbor_cexa";
                    using (var datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            we.Add(Load(datareader));
                        }
                    }
                }
            }
            return we;
        }
        public static void Add(Plan_sbor_cexa we)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Plam_sbor_cexa (Data_nach_vip_plan, Data_okonch_vip_plan, Poryadok_vip_det, Obhee_fact_kol, Plan_det_den, Fact_det_den, ID_DCE) values (@Data_nach_vip_plan, @Data_okonch_vip_plan, @Poryadok_vip_det, @Obhee_fact_kol, @Plan_det_den, @Fact_det_den, @ID_DCE)";
                    cmd.Parameters.AddWithValue("@Data_nach_vip_plan", we.Data_nach_vip_plan);
                    cmd.Parameters.AddWithValue("@Data_okonch_vip_plan", we.Data_okonch_vip_plan);
                    cmd.Parameters.AddWithValue("@Poryadok_vip_det", we.Poryadok_vip_det);
                    cmd.Parameters.AddWithValue("@Obhee_fact_kol", we.Obhee_fact_kol);
                    cmd.Parameters.AddWithValue("@Plan_det_den", we.Plan_det_den);
                    cmd.Parameters.AddWithValue("@Fact_det_den", we.Fact_det_den);
                    cmd.Parameters.AddWithValue("@ID_DCE", we.ID_DCE);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Update(Plan_sbor_cexa we)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Plam_sbor_cexa set Data_okonch_vip_plan=@Data_okonch_vip_plan, Poryadok_vip_det=@Poryadok_vip_det, Obhee_fact_kol=@Obhee_fact_kol, Plan_det_den=@Plan_det_den, Fact_det_den=@Fact_det_den, ID_DCE = @ID_DCE where Data_nach_vip_plan=@qt";
                    cmd.Parameters.AddWithValue("@Data_nach_vip_plan", we.Data_nach_vip_plan);
                    cmd.Parameters.AddWithValue("@Data_okonch_vip_plan", we.Data_okonch_vip_plan);
                    cmd.Parameters.AddWithValue("@Poryadok_vip_det", we.Poryadok_vip_det);
                    cmd.Parameters.AddWithValue("@Obhee_fact_kol", we.Obhee_fact_kol);
                    cmd.Parameters.AddWithValue("@Plan_det_den", we.Plan_det_den);
                    cmd.Parameters.AddWithValue("@Fact_det_den", we.Fact_det_den);
                    cmd.Parameters.AddWithValue("@ID_DCE", we.ID_DCE);
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public static void Delete(DateTime qt)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "delete Plam_sbor_cexa where Data_nach_vip_plan = @qt ";
                    cmd.Parameters.AddWithValue("@qt", qt);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

