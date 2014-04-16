using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassBD;
using System.Data.SqlClient;

namespace OPDao
{
    public class Plan_mehan_cexaDAO
    {
        private static Plan_mehan_cexa Load(SqlDataReader reader)
        {
            //Sozdaem pustoi obekt
            Plan_mehan_cexa rr = new Plan_mehan_cexa();
            rr.Data_nach_vip_plan = Convert.ToDateTime(reader["Data_nach_vip_plan"]);
            rr.Data_okonch_vip_plan =Convert.ToDateTime(reader["Data_okonch_vip_plan"]);
            rr.Poryadok_vip_det = Convert.ToInt32(reader["Poryadok_vip_det"]);
            rr.Obhee_zaplan_kol = Convert.ToInt32(reader["Obhee_zaplan_kol"]);
            rr.Obhee_fact_kol = Convert.ToInt32(reader["Obhee_fact_kol"]);
            rr.Plan_det_den = Convert.ToInt32(reader["Plan_det_den"]);
            rr.Fact_det_den = Convert.ToInt32(reader["Fact_det_den"]);
            rr.Ostatok_sklad = Convert.ToInt32(reader["Ostatok_sklad"]);
            rr.Neobh_vip = Convert.ToInt32(reader["Neobh_vip"]);
            rr.Data_strahovofgo_zadela = Convert.ToDateTime(reader["Data_strahovofgo_zadela"]);
            rr.ID_DCE = Convert.ToInt32(reader["ID_DCE"]);
            return rr;
        }
        public Plan_mehan_cexa Get(int rt)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = " select * from Plan_mehan_cexa where Data_nach_vip_plan=@rt";
                    cmd.Parameters.AddWithValue("@rt", rt);


                    using (var datareader = cmd.ExecuteReader())
                    {
                        return !datareader.Read() ? null : Load(datareader);
                    }

                }
            }
        }
        public static IList<Plan_mehan_cexa> GetAll()
        {
            IList<Plan_mehan_cexa> tt = new List<Plan_mehan_cexa>();

            using (var conn = Connect.GetConnect())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = " select * from Plan_mehan_cexa";
                    using (var datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            tt.Add(Load(datareader));
                        }
                    }
                }
            }
            return tt;
        }
        public static void Add(Plan_mehan_cexa tt)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Plan_mehan_cexa (Data_nach_vip_plan, Data_okonch_vip_plan, Poryadok_vip_det,Obhee_zaplan_kol, Obhee_fact_kol, Plan_det_den, Fact_det_den, Ostatok_sklad, Neobh_vip, Data_strahovofgo_zadela, ID_DCE ) values (@Data_nach_vip_plan, @Data_okonch_vip_plan, @Poryadok_vip_det,@Obhee_zaplan_kol, @Obhee_fact_kol, @Plan_det_den, @Fact_det_den, @Ostatok_sklad, @Neobh_vip, @Data_strahovofgo_zadela, @ID_DCE )";
                    cmd.Parameters.AddWithValue("@Data_nach_vip_plan", tt.Data_nach_vip_plan);
                    cmd.Parameters.AddWithValue("@Data_okonch_vip_plan", tt.Data_okonch_vip_plan);
                    cmd.Parameters.AddWithValue("@Poryadok_vip_det", tt.Poryadok_vip_det);
                    cmd.Parameters.AddWithValue("@Obhee_zaplan_kol", tt.Obhee_zaplan_kol);
                    cmd.Parameters.AddWithValue("@Obhee_fact_kol", tt.Obhee_fact_kol);
                    cmd.Parameters.AddWithValue("@Plan_det_den", tt.Plan_det_den);
                    cmd.Parameters.AddWithValue("@Fact_det_den", tt.Fact_det_den);
                    cmd.Parameters.AddWithValue("@Ostatok_sklad", tt.Ostatok_sklad);
                    cmd.Parameters.AddWithValue("@Neobh_vip", tt.Neobh_vip);
                    cmd.Parameters.AddWithValue("@Data_strahovofgo_zadela", tt.Data_strahovofgo_zadela);
                    cmd.Parameters.AddWithValue("@ID_DCE ", tt.ID_DCE);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Update(Plan_mehan_cexa tt)
        {
            using (var conn = Connect.GetConnect())
            { 
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Plan_mehan_cexa set Data_nach_vip_plan=@Data_nach_vip_plan, Data_okonch_vip_plan=@Data_okonch_vip_plan, Poryadok_vip_det=@Poryadok_vip_det,Obhee_zaplan_kol=@Obhee_zaplan_kol, Obhee_fact_kol=@Obhee_fact_kol, Plan_det_den=@Plan_det_den, Fact_det_den=@Fact_det_den, Ostatok_sklad=@Ostatok_sklad, Neobh_vip=@Neobh_vip, Data_strahovofgo_zadela=@Data_strahovofgo_zadela, ID_DCE=@ID_DCE)";
                    cmd.Parameters.AddWithValue("@Data_nach_vip_plan", tt.Data_nach_vip_plan);
                    cmd.Parameters.AddWithValue("@Data_okonch_vip_plan", tt.Data_okonch_vip_plan);
                    cmd.Parameters.AddWithValue("@Poryadok_vip_det", tt.Poryadok_vip_det);
                    cmd.Parameters.AddWithValue("@Obhee_zaplan_kol", tt.Obhee_zaplan_kol);
                    cmd.Parameters.AddWithValue("@Obhee_fact_kol", tt.Obhee_fact_kol);
                    cmd.Parameters.AddWithValue("@Plan_det_den", tt.Plan_det_den);
                    cmd.Parameters.AddWithValue("@Fact_det_den", tt.Fact_det_den);
                    cmd.Parameters.AddWithValue("@Ostatok_sklad", tt.Ostatok_sklad);
                    cmd.Parameters.AddWithValue("@Neobh_vip", tt.Neobh_vip);
                    cmd.Parameters.AddWithValue("@Data_strahovofgo_zadela", tt.Data_strahovofgo_zadela);
                    cmd.Parameters.AddWithValue("@ID_DCE ", tt.ID_DCE);
                    cmd.ExecuteNonQuery();
                }
                }

                }
        public static void Delete(DateTime rt)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "delete Plan_mehan_cexa where Data_nach_vip_plan = @rt ";
                    cmd.Parameters.AddWithValue("@rt", rt);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}