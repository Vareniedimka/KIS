using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassBD;
using System.Data.SqlClient;

namespace OPDao
{
    public class Otchet_o_vip_tov_planDAO
    {
        private static Otchet_o_vip_tov_plan Load(SqlDataReader reader)
        {
            //Sozdaem pustoi obekt
            Otchet_o_vip_tov_plan yy = new Otchet_o_vip_tov_plan();
            yy.Data_eshednevno = Convert.ToDateTime(reader["Data_eshednevno"]);
            yy.Kolichestvo =Convert.ToInt32(reader["Kolichestvo"]);
            yy.Nomer_izg_det = Convert.ToInt32(reader["Nomer_izg_det"]);
            yy.ID_Izg_SE = Convert.ToInt32(reader["ID_Izg_SE"]);
             return yy;

        }
        public Otchet_o_vip_tov_plan Get(DateTime yu)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = " select * from Otchet_o_vip_tov_plan where Data_eshednevno = @yu";
                    cmd.Parameters.AddWithValue("@yu", yu);


                    using (var datareader = cmd.ExecuteReader())
                    {
                        return !datareader.Read() ? null : Load(datareader);
                    }

                }
            }
        }
        public static IList<Otchet_o_vip_tov_plan> GetAll()
        {
            IList<Otchet_o_vip_tov_plan> uu = new List<Otchet_o_vip_tov_plan>();

            using (var conn = Connect.GetConnect())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = " select * from Otchet_o_vip_tov_plan";
                    using (var datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            uu.Add(Load(datareader));
                        }
                    }
                }
            }
            return uu;
        }
        public static void Add(Otchet_o_vip_tov_plan uu)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Otchet_o_vip_tov_plan (Data_eshednevno,Kolichestvo, Nomer_izg_det,ID_Izg_SE) values (@Data_eshednevno,@Kolichestvo, @Nomer_izg_det,@ID_Izg_SE)";
                    cmd.Parameters.AddWithValue("@Data_eshednevno", uu.Data_eshednevno);
                    cmd.Parameters.AddWithValue("@Kolichestvo", uu.Kolichestvo);
                    cmd.Parameters.AddWithValue("@Nomer_izg_det", uu.Nomer_izg_det);
                    cmd.Parameters.AddWithValue("@ID_Izg_SE", uu.ID_Izg_SE);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Update(Otchet_o_vip_tov_plan uu)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Otchet_o_vip_tov_plan set Kolichestvo = @Kolichestvo,Nomer_izg_det = @Nomer_izg_det, ID_Izg_SE = @ID_Izg_SE where Data_eshednevno = @yu ";
                    cmd.Parameters.AddWithValue("@Data_eshednevno", uu.Data_eshednevno);
                    cmd.Parameters.AddWithValue("@Kolichestvo", uu.Kolichestvo);
                    cmd.Parameters.AddWithValue("@Nomer_izg_det", uu.Nomer_izg_det);
                    cmd.Parameters.AddWithValue("@ID_Izg_SE", uu.ID_Izg_SE);
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public static void Delete(DateTime yu)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "delete Otchet_o_vip_tov_plan where Data_eshednevno = @yu ";
                    cmd.Parameters.AddWithValue("@yu", yu);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
