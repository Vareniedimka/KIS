using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassBD;
using System.Data.SqlClient;

namespace OPDao
{
    public class Strahov_zadelDAO
    {
        private static Strahov_zadel Load(SqlDataReader reader)
        {
            //Sozdaem pustoi obekt
            Strahov_zadel dd = new Strahov_zadel();
            dd.Naimenovanie_det = Convert.ToString(reader["Naimenovanie_det "]);
            dd.Kolichestvo = Convert.ToInt32(reader["Kolichestvo"]);
            dd.Data_strahovogo_zadela = Convert.ToDateTime(reader["Data_strahovogo_zadela"]);
            return dd;

        }
        public Strahov_zadel Get(DateTime dt)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = " select * from Strahov_zadel where Data_strahovogo_zadela = @ Data_strahovogo_zadela ";
                    cmd.Parameters.AddWithValue("@dt", dt);


                    using (var datareader = cmd.ExecuteReader())
                    {
                        return !datareader.Read() ? null : Load(datareader);
                    }

                }
            }
        }
        public static IList<Strahov_zadel> GetAll()
        {
            IList<Strahov_zadel> aa = new List<Strahov_zadel>();

            using (var conn = Connect.GetConnect())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = " select from Strahov_zadel";
                    using (var datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            aa.Add(Load(datareader));
                        }
                    }
                }
            }
            return aa;
        }
        public static void Add(Strahov_zadel aa)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Strahov_zadel (Naimenovanie_det, Kolichestvo, Data_strahovogo_zadela) values (@Naimenovanie_det, @ Kolichestvo, @, @ Data_strahovogo_zadela)";
                    cmd.Parameters.AddWithValue("@Naimenovanie_det", aa.Naimenovanie_det);
                    cmd.Parameters.AddWithValue("@Kolichestvo ", aa.Kolichestvo);
                    cmd.Parameters.AddWithValue("@Data_strahovogo_zadela ", aa.Data_strahovogo_zadela);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Update(Strahov_zadel aa)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Strahov_zadel set Naimenovanie_det = @ Naimenovanie_det, Kolichestvo = @ Kolichestvo, Data_strahovogo_zadela = @ Data_strahovogo_zadela ";
                    cmd.Parameters.AddWithValue("@Naimenovanie_det ", aa.Naimenovanie_det);
                    cmd.Parameters.AddWithValue("@Kolichestvo ", aa.Kolichestvo);
                    cmd.Parameters.AddWithValue("@Data_strahovogo_zadela ", aa.Data_strahovogo_zadela);
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public static void Delete(DateTime dt)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "delete Strahov_zadel where Data_strahovogo_zadela = @dt ";
                    cmd.Parameters.AddWithValue("@dt", dt);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

