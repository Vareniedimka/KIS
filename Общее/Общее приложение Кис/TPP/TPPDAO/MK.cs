using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassBD;
using System.Data.SqlClient;


namespace TPPDAO
{
  public class MKDA
    {
        private static MarshrytKarta Load(SqlDataReader reader)
        {
            MarshrytKarta ww = new MarshrytKarta();
            ww.Cex = reader["Cex"].ToString();
            ww.IdOperacii = Convert.ToInt16(reader["ID_operacii"]);
            ww.InvNom = Convert.ToInt32(reader["Invertatniy_nomer"]);
            ww.IdProf = Convert.ToInt32(reader["ID_Professii"]);
            ww.TimeSht = Convert.ToInt32(reader["Time_schtuchn"]);
            ww.TimePZ = Convert.ToInt32(reader["TimePZ"]);
            ww.ID_DCE = Convert.ToInt32(reader["ID_DCE"]);
            ww.model = Convert.ToString(reader["model"]);
            ww.name = Convert.ToString(reader["name"]); 
            return ww;
        }

        public MarshrytKarta Get(int id)
        {
            using (var conn = Connect.GetConnect())
            {
                //Открываем соеденение
                conn.Open();
                //Создаем Sql команду
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Marsrut_karta where ID_marshrut = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    //Открываем SqlDataReader для чтения полученных в результате
                    //выполнения запроса данных
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : Load(dataReader);
                    }
                }
            }
        }

        public static IList<MarshrytKarta> GetAll()
        {
            IList<MarshrytKarta> ww = new List<MarshrytKarta>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select *,(select Model from Stanok_na_proizv where Invertatniy_nomer = Marsrut_karta.Invertatniy_nomer ) as model,(select Naimenovanie from Professii where ID_Professii = Marsrut_karta.ID_Professii) as name from Marsrut_karta where ID_DCE = @id ";
                    cmd.Parameters.AddWithValue("@id",Storonee.IDDseMK);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                            ww.Add(Load(dataReader));
                    }
                }
            }
            return ww;
        }

        public static void Add(MarshrytKarta ww)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Marsrut_karta (Cex,ID_operacii,Invertatniy_nomer,ID_Professii,Time_schtuchn,TimePZ,ID_DCE) values (@cex,@idO,(select Invertatniy_nomer from Stanok_na_proizv where Model = @m),(select ID_Professii from Professii where Naimenovanie = @name),@TS,@TPZ,@IDDSE)";
                    cmd.Parameters.AddWithValue("@cex", ww.Cex);
                    cmd.Parameters.AddWithValue("@idO", ww.IdOperacii);
                    cmd.Parameters.AddWithValue("@m", ww.model);
                    cmd.Parameters.AddWithValue("@name", ww.name);
                    cmd.Parameters.AddWithValue("@TS", ww.TimeSht);
                    cmd.Parameters.AddWithValue("@TPZ", ww.TimePZ);
                    cmd.Parameters.AddWithValue("@IDDSE", Storonee.IDDseMK);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(MarshrytKarta ww)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Marsrut_karta set Cex= @cex, ID_operacii= @IDO, Invertatniy_nomer = (select Invertatniy_nomer from Stanok_na_proizv where Model = @m), ID_Professii =(select ID_Professii from Professii where Naimenovanie = @name), Time_schtuchn = @ts, TimePZ = TimePZ, ID_DCE =@IDDSE where ID_marshrut = @id";
                    cmd.Parameters.AddWithValue("@cex", ww.Cex);
                    cmd.Parameters.AddWithValue("@idO", ww.IdOperacii);
                    cmd.Parameters.AddWithValue("@m", ww.model);
                    cmd.Parameters.AddWithValue("@name", ww.name);
                    cmd.Parameters.AddWithValue("@TS", ww.TimeSht);
                    cmd.Parameters.AddWithValue("@TPZ", ww.TimePZ);
                    cmd.Parameters.AddWithValue("@IDDSE", Storonee.IDDseMK);
                    cmd.Parameters.AddWithValue("@id", ww.IdMarshrut);
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
                    cmd.CommandText = "delete Marsrut_karta where ID_marshrut = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
