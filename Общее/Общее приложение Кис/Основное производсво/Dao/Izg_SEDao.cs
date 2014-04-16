using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassBD;
using System.Data.SqlClient;

namespace OPDao
{
    public class Izg_SEDAO
    {
        private static Izg_SE Load(SqlDataReader reader)
        {
            //Sozdaem pustoi obekt
            Izg_SE oo = new Izg_SE();
            oo.Nomer_izg_det = Convert.ToInt32(reader["Nomer_izg_det"]);
            oo.ID_Izg_SE =Convert.ToInt32(reader["ID_Izg_SE"]);
            oo.Invertatniy_nomer = Convert.ToInt32(reader["Invertatniy_nomer"]);
            oo.Date_izg = Convert.ToDateTime(reader["Date_izg"]);
            oo.Viyavl_brak = Convert.ToString(reader["Viyavl_brak"]);
            oo.Nomer_partii = Convert.ToInt32(reader["Nomer_partii"]);
            oo.Tabeln_nom = Convert.ToInt32(reader["Tabeln_nom"]);
            return oo;

        }
        public Izg_SE Get(int id)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = " select * from Izg_SE where Nomer_izg_det = @id";
                    cmd.Parameters.AddWithValue("@id", id);


                    using (var datareader = cmd.ExecuteReader())
                    {
                        return !datareader.Read() ? null : Load(datareader);
                    }

                }
            }
        }
        public static IList<Izg_SE> GetAll()
        {
            IList<Izg_SE> pp = new List<Izg_SE>();

            using (var conn = Connect.GetConnect())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = " select *from Izg_SE";
                    using (var datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            pp.Add(Load(datareader));
                        }
                    }
                }
            }
            return pp;
        }
        public static void Add(Izg_SE po)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Izg_SE (Nomer_izg_det, Tabeln_nom, ID_Izg_SE,Invertatniy_nomer,Date_izg, Viyavl_brak, Nomer_partii) values (@Nomer_izg_det, @Tabeln_nom, @ID_Izg_SE,@Invertatniy_nomer, @Date_izg, @Viyavl_brak, @Nomer_partii)";
                    cmd.Parameters.AddWithValue("@Nomer_izg_det", po.Nomer_izg_det);
                    cmd.Parameters.AddWithValue("@ID_Izg_SE", po.ID_Izg_SE);
                    cmd.Parameters.AddWithValue("@Invertatniy_nomer", po.Invertatniy_nomer);
                    cmd.Parameters.AddWithValue("@Date_izg", po.Date_izg);
                    cmd.Parameters.AddWithValue("@Viyavl_brak", po.Viyavl_brak);
                    cmd.Parameters.AddWithValue("@Nomer_partii", po.Nomer_partii);
                    cmd.Parameters.AddWithValue("Tabeln_nom", po.Tabeln_nom);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Update(Izg_SE po)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Izg_SE set Invertatniy_nomer = @Invertatniy_nomer,Tabeln_nom=@Tabeln_nom, Date_izg = @Date_izg, Viyavl_brak= @Viyavl_brak, Nomer_partii = @Nomer_partii where Nomer_izg_det = @Nomer_izg_det, ID_Izg_SE = @ID_Izg_SE ";
                    cmd.Parameters.AddWithValue("@Nomer_izg_det", po.Nomer_izg_det);
                    cmd.Parameters.AddWithValue("@ID_Izg_SE", po.ID_Izg_SE);
                    cmd.Parameters.AddWithValue("@Invertatniy_nomer", po.Invertatniy_nomer);
                    cmd.Parameters.AddWithValue("@Date_izg", po.Date_izg);
                    cmd.Parameters.AddWithValue("@Viyavl_brak", po.Viyavl_brak);
                    cmd.Parameters.AddWithValue("@Nomer_partii", po.Nomer_partii);
                    cmd.Parameters.AddWithValue("@Tabeln_nom", po.Tabeln_nom);
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
                    cmd.CommandText = "delete Izg_SE where Nomer_izg_det = @id ";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
