using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassBD;

namespace TPPDAO
{
    public class NepPrim
    {
        private static NepPrem Load(SqlDataReader reader)
        {
            NepPrem dd = new NepPrem();
            dd.IzdChto = Convert.ToInt16(reader["izd_chto"]);
            dd.IzdKuda = Convert.ToInt16(reader["izd_kuda"]);
            dd.Kolichestvo = Convert.ToInt16(reader["Kolichestvo"]);
            dd.Primichanie = Convert.ToString(reader["Primechanie"]);
            dd.name_chto = Convert.ToString(reader["name_chto"]);
            dd.name_kuda = Convert.ToString(reader["name_kuda"]);
            
            return dd;
            
        }
        public NepPrem Get(int id,int id1)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select *,(select Naimenovanie from DSE where ID_DCE = Neposredstv_prim.izd_chto) as name_chto,(select Naimenovanie from DSE where ID_DCE = Neposredstv_prim.izd_kuda) as name_kuda from Neposredstv_prim where izd_chto= @id and izd_kuda = @id1";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@id1", id1);


                    using (var datareader = cmd.ExecuteReader())
                    {
                        return !datareader.Read() ? null : Load(datareader);
                    }


                }
            } 
        }

        public static IList<NepPrem> GetAll()
        {
            IList<NepPrem> dd = new List<NepPrem>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select *,(select Naimenovanie from DSE where ID_DCE = Neposredstv_prim.izd_chto) as name_chto,(select Naimenovanie from DSE where ID_DCE = Neposredstv_prim.izd_kuda) as name_kuda from Neposredstv_prim";
                    using (var datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            dd.Add(Load(datareader));
                        }
                    } 
                        
                }
            }
            return dd;
        }

        public static void Add(NepPrem dd)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Neposredstv_prim(izd_chto,izd_kuda,Kolichestvo,Primechanie,ID_DCE) values ((select ID_DCE from DSE where Naimenovanie = @nc),(select ID_DCE from DSE where Naimenovanie = @nk),@Kolichestvo,@Primechanie,(select ID_DCE from DSE where Naimenovanie = @nc))";
                    cmd.Parameters.AddWithValue("@nc", dd.name_chto);
                    cmd.Parameters.AddWithValue("@nk", dd.name_kuda);
                    cmd.Parameters.AddWithValue("@Kolichestvo", dd.Kolichestvo);
                    cmd.Parameters.AddWithValue("@Primechanie", dd.Primichanie);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Update(NepPrem dd)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update  Neposredstv_prim set izd_chto =(select ID_DCE from DSE where Naimenovanie = @nc), izd_kuda = (select ID_DCE from DSE where Naimenovanie = @nk),Kolichestvo = @Kolichestvo, Primechanie =@Primechanie";
                    cmd.Parameters.AddWithValue("@nc", dd.name_chto);
                    cmd.Parameters.AddWithValue("@nc", dd.name_kuda);
                    cmd.Parameters.AddWithValue("@Kolichestvo", dd.Kolichestvo);
                    cmd.Parameters.AddWithValue("@Primechanie", dd.Primichanie);
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public static void Delete(int id, int id1)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = " delete Neposredstv_prim where izd_chto= @id and izd_kuda = @id1";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@id1", id1);
                    cmd.ExecuteNonQuery();
                }
            } 


        } 
    }


}
