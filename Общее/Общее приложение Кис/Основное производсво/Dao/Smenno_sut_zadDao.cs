using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassBD;
using System.Data.SqlClient;
using OPDao;

namespace OPDao
{
    public class Smenno_sut_zadDAO
    {
        private static Smenno_sut_zad Load(SqlDataReader reader)
        {
            //Sozdaem pustoi obekt
            Smenno_sut_zad zz = new Smenno_sut_zad();
            zz.Nomer_SSZ = Convert.ToInt16(reader["Nomer_SSZ"]);
            zz.Tabeln_nomer =Convert.ToInt32(reader["Tabeln_nomer"]);
            zz.Data_nach_vip_plan = Convert.ToDateTime(reader["Data_nach_vip_plan"]);
            zz.Data_okonch_vip_plan = Convert.ToDateTime(reader["Data_okonch_vip_plan"]);
            zz.Cex  = Convert.ToInt32(reader["Cex"]);
            zz.ID_operacii = Convert.ToInt32(reader["ID_operacii"]);
            zz.Date = Convert.ToDateTime(reader["Date"]);
            zz.Smena  =Convert.ToInt32(reader["Smena "]);
            zz.Nomer_partii = Convert.ToInt32(reader["Nomer_partii"]);
            zz.ID_DCE = Convert.ToInt32(reader["ID_DCE"]);
            return zz;

        }
        public Smenno_sut_zad Get(int id)
        {
            using (var conn = Connect.GetConnect())
            {
               
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = " select * from Smenno_sut_zad where Nomer_SSZ = @id";
                    cmd.Parameters.AddWithValue("@id", id);


                    using (var datareader = cmd.ExecuteReader())
                    {
                        return !datareader.Read() ? null : Load(datareader);
                    }

                }
            }
        }
        public static IList<Smenno_sut_zad> GetAll()
        {
            IList<Smenno_sut_zad> mm = new List<Smenno_sut_zad>();

            using (var conn = Connect.GetConnect())
            {
            

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Smenno_sut_zad";
                    using (var datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            mm.Add(Load(datareader));
                        }
                    }
                }
            }
            return mm;
        }
        public static void Add(Smenno_sut_zad bb)
        {
            using (var conn = Connect.GetConnect())
            {
             
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Smenno_sut_zad (Tabeln_nomer, Data_nach_vip_plan, Data_okonch_vip_plan,Cex, ID_operacii, Date, Smena, Nomer_partii, ID_DCE) values (@Tabeln_nomer, @Data_nach_vip_plan, @Data_okonch_vip_plan @Cex, @ID_operacii, @Date, @Smena, @Nomer_partii, @ID_DCE)";
                    cmd.Parameters.AddWithValue("@Tabeln_nomer", bb.Tabeln_nomer);
                    cmd.Parameters.AddWithValue("@Data_nach_vip_plan", bb.Data_nach_vip_plan);
                    cmd.Parameters.AddWithValue("@Smena ", bb.Smena );
                    cmd.Parameters.AddWithValue("@Cex", bb.Cex );
                    cmd.Parameters.AddWithValue("@ID_operacii", bb.ID_operacii);
                    cmd.Parameters.AddWithValue("@Smena", bb.Smena);
                    cmd.Parameters.AddWithValue("@Date", bb.Date);
                    cmd.Parameters.AddWithValue("@Nomer_partii", bb.Nomer_partii);
                    cmd.Parameters.AddWithValue("@ID_DCE", bb.ID_DCE);
                    cmd.Parameters.AddWithValue("@Nomer_SSZ", bb.Nomer_SSZ);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Update(Smenno_sut_zad bb)
        {
            using (var conn = Connect.GetConnect())
            {
              
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Smenno_sut_zad set Tabeln_nomer=@Tabeln_nomer, Data_nach_vip_plan=@Data_nach_vip_plan, Data_okonch_vip_plan=@Data_okonch_vip_plan,Cex=@Cex, ID_operacii=@ID_operacii, Date=@Date, Smena=@Smena, Nomer_partii=@Nomer_partii, ID_DCE=@ID_DCE where Nomer_SSZ = @id ";
                    cmd.Parameters.AddWithValue("@Tabeln_nomer", bb.Tabeln_nomer);
                    cmd.Parameters.AddWithValue("@Data_nach_vip_plan", bb.Data_nach_vip_plan);
                    cmd.Parameters.AddWithValue("@Data_okonch_vip_plan", bb.Data_okonch_vip_plan);
                    cmd.Parameters.AddWithValue("@Cex ", bb.Cex );
                    cmd.Parameters.AddWithValue("@ID_operacii", bb.ID_operacii);
                    cmd.Parameters.AddWithValue("@Date", bb.Date);
                    cmd.Parameters.AddWithValue("@id", bb.Nomer_SSZ);
                    cmd.Parameters.AddWithValue("@Smena", bb.Smena);
                    cmd.Parameters.AddWithValue("@Nomer_partii", bb.Nomer_partii);
                    cmd.Parameters.AddWithValue("@ID_DCE", bb.ID_DCE);
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public static void Delete(int id)
        {
            using (var conn = Connect.GetConnect())
            {
             
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "delete Smenno_sut_zad where Nomer_SSZ = @id ";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
