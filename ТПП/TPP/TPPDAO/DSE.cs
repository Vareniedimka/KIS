using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassBD;
using System.Data.SqlClient;

namespace TPPDAO
{
    public class DSEDAO
    {
        private static DSE Load(SqlDataReader reader)
        {
            //Sozdaem pustoi obekt
            DSE dd = new DSE();
            dd.ID_DCE = Convert.ToInt16(reader["ID_DCE"]);
            dd.Naimenovanie = Convert.ToString(reader["Naimenovanie"]);
            dd.Norma_rashoda = Convert.ToInt16(reader["Norma_rashoda"]);
            dd.ID_materiala = Convert.ToInt16(reader["ID_materiala"]);
            dd.SE = Convert.ToInt16(reader["Sborochnaya_ed"]);
            dd.PE = Convert.ToInt16(reader["Pokupnoe_izd"]);
            dd.Detal = Convert.ToInt16(reader["Detal"]);
            dd.material = reader["material"].ToString();
            return dd;

        }
        public DSE Get(int id)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = " select *,(select Nazvanie_materiala from Materialy where ID_materiala = DSE.ID_materiala) from DSE where ID_DCE = @id";
                    cmd.Parameters.AddWithValue("@id", id);


                    using (var datareader = cmd.ExecuteReader())
                    {
                        return !datareader.Read() ? null : Load(datareader);
                    }

                }
            }
        }
        public static IList<DSE> GetAll()
        {
            IList<DSE> aa = new List<DSE>();

            using (var conn = Connect.GetConnect())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = " select *,(select Nazvanie_materiala from Materialy where ID_materiala = DSE.ID_materiala )  as material from DSE";
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
        public static void Add(DSE aa)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into DSE (Naimenovanie, Norma_rashoda, ID_materiala,Sborochnaya_ed, Pokupnoe_izd, Detal) values (@Naimenovanie, @Norma_rashoda,(Select m.ID_materiala  from Materialy m where m.Nazvanie_materiala = @material), @Sborochnaya_ed, @Pokupnoe_izd, @Detal)";
                    cmd.Parameters.AddWithValue("@Naimenovanie", aa.Naimenovanie);
                    cmd.Parameters.AddWithValue("@Norma_rashoda", aa.Norma_rashoda);
                    cmd.Parameters.AddWithValue("@material", aa.material);
                    cmd.Parameters.AddWithValue("@Sborochnaya_ed", aa.SE);
                    cmd.Parameters.AddWithValue("@Pokupnoe_izd", aa.PE);
                    cmd.Parameters.AddWithValue("@Detal", aa.Detal);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Update(DSE aa)
        {
            using (var conn = Connect.GetConnect())
            { 
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update DSE set Naimenovanie = @name, Norma_rashoda = @nm,ID_materiala = @idm, Sborochnaya_ed = @se, Pokupnoe_izd= @pe, Detal = @detal where ID_DCE = @id ";
                    cmd.Parameters.AddWithValue("@name", aa.Naimenovanie);
                    cmd.Parameters.AddWithValue("@nm", aa.Norma_rashoda);
                    cmd.Parameters.AddWithValue("@idm", aa.ID_materiala);
                    cmd.Parameters.AddWithValue("@se", aa.SE);
                    cmd.Parameters.AddWithValue("@pe", aa.PE);
                    cmd.Parameters.AddWithValue("@detal", aa.Detal);
                    cmd.Parameters.AddWithValue("@id", aa.ID_DCE);
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
                    cmd.CommandText = "delete DSE where ID_DCE = @id ";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
