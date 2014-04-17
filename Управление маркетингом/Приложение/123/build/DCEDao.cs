using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using СlassLib;
namespace build
{
   public class DCEDao
    {
        private static DCE Load(SqlDataReader reader)
        {
            //Sozdaem pustoi obekt
            DCE dd = new DCE();
            dd.ID_DCE = Convert.ToInt16(reader["ID_DCE"]);
            dd.Naimenovanie = reader["Naimenovanie"].ToString();
            dd.Norma_rashoda = Convert.ToInt16(reader["Norma_rashoda"]);
            dd.ID_materiala = Convert.ToInt16(reader["ID_materiala"]);
            dd.SE = Convert.ToInt16(reader["Sborochnaya_ed"]);
            dd.PE = Convert.ToInt16(reader["Pokupnoe_izd"]);
            dd.Detal = Convert.ToInt16(reader["Detal"]);
            return dd;

        }
      
        public static IList<DCE> GetAll()
        {
            IList<DCE> aa = new List<DCE>();

            using (var conn = Connect.GetConnect())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from DSE ";
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
    }
}
