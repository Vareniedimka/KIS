using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassBD;
using System.Data.SqlClient;

namespace OPDao
{
    public class Operaciy_SZDAO
    {
        private static Operaciy_SZ Load(SqlDataReader reader)
        {
            //Sozdaem pustoi obekt
            Operaciy_SZ ii = new Operaciy_SZ();
            ii.ID_operacii = Convert.ToInt32(reader["ID_operacii"]);
            ii.ID_marshrut = Convert.ToInt32(reader["ID_marshrut"]);
            ii.Naimenovanie_operacii =Convert.ToString(reader["Naimenovanie_operacii"]);
            ii.Time_schtucthn = Convert.ToInt32(reader["Time_schtucthn"]);
            ii.TimePZ = Convert.ToInt32(reader["TimePZ"]);
            return ii;

        }
     
        public static IList<Operaciy_SZ> GetAll()
        {
            IList<Operaciy_SZ> ii = new List<Operaciy_SZ>();

            using (var conn = Connect.GetConnect())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = " select * from Operaciy_SZ"  ;
                    using (var datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            ii.Add(Load(datareader));
                        }
                    }
                }
            }
            return ii;
        }
        public static void Add(Operaciy_SZ ii)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Operaciy_SZ (ID_operacii, ID_marshrut, Naimenovanie_operacii,Time_schtucthn, TimePZ) values (@ID_operacii, @Naimenovanie_operacii,(Select m.Time_schtucthn, m.TimePZ from MarshrytKarta m where m.ID_marshrut = @ID_marshrut))";
                    cmd.Parameters.AddWithValue("@ID_operacii", ii.ID_operacii);
                    cmd.Parameters.AddWithValue("@ID_marshrut", ii.ID_marshrut);
                    cmd.Parameters.AddWithValue("@Naimenovanie_operacii", ii.Naimenovanie_operacii);
                    cmd.Parameters.AddWithValue("@Time_schtucthn", ii.Time_schtucthn);
                    cmd.Parameters.AddWithValue("@TimePZ", ii.TimePZ);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Update(Operaciy_SZ ii)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Operaciy_SZ set ID_marshrut = @ID_marshrut,Naimenovanie_operacii = @Naimenovanie_operacii, Time_schtucthn = @Time_schtucthn, TimePZ= @TimePZ, where ID_operacii = @io ";
                    cmd.Parameters.AddWithValue("@ID_operacii", ii.ID_operacii);
                    cmd.Parameters.AddWithValue("@ID_marshrut", ii.ID_marshrut);
                    cmd.Parameters.AddWithValue("@Naimenovanie_operacii", ii.Naimenovanie_operacii);
                    cmd.Parameters.AddWithValue("@Time_schtucthn", ii.Time_schtucthn);
                    cmd.Parameters.AddWithValue("@TimePZ", ii.TimePZ);
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public static void Delete(int io)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "delete Operaciy_SZ where ID_operacii = @io ";
                    cmd.Parameters.AddWithValue("@io", io);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
