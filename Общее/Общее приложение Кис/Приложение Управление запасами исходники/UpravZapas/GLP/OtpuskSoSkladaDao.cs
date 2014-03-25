using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassLibrary;

namespace GLP
{
    public class OtpuskSoSkladaDao
    {
        private static OtpuskSoSklada Load(SqlDataReader r)
        {
            //Создаём пустой объект
            OtpuskSoSklada item = new OtpuskSoSklada();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            item.DataOtgruzk = Convert.ToDateTime(r["Data_otgruzki"]);
            item.IDMateriala = Convert.ToInt32(r["ID_materiala"]);
            item.MaterialName = Convert.ToString(r["nameM"]);
            item.Kolichestvo = Convert.ToInt32(r["Kolichestvo"]);
            item.IDOtpusk = Convert.ToInt32(r["ID_otpusk_so_sklada"]);
            return item;
        }

        public static IList<OtpuskSoSklada> GetAll()
        {

            IList<OtpuskSoSklada> items = new List<OtpuskSoSklada>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT *,
                        (
                            select Nazvanie_materiala
	                        from Materialy
	                        where mup.ID_materiala = ID_materiala
                        ) as nameM
                        from Otpusk_so_sklada mup";
                   
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            items.Add(Load(dataReader));
                        }
                    }
                }
            }
            return items;
        }



        public static void Add(OtpuskSoSklada item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO [Otpusk_so_sklada]
                               ([ID_materiala]
                               ,[Data_otgruzki]
                               ,[Kolichestvo])
                        VALUES
                               (
                                (
		                            select ID_materiala
		                            from Materialy
		                            where Nazvanie_materiala=@nameM
		                        )
                               ,@Dat
                               ,@Kolichestvo)
                    ";
                    cmd.Parameters.AddWithValue("@Dat", item.DataOtgruzk);
                    cmd.Parameters.AddWithValue("@Kolichestvo", item.Kolichestvo);
                    cmd.Parameters.AddWithValue("@nameM", item.MaterialName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(OtpuskSoSklada item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [Otpusk_so_sklada]
                       SET [ID_materiala] = 
		                    (
			                    select ID_materiala
			                    from Materialy
			                    where Nazvanie_materiala=@nameM
		                    )
                          ,[Data_otgruzki] = @Dat
                          ,[Kolichestvo] = @Kolichestvo
                     WHERE ID_otpusk_so_sklada=@id
                    ";
                    cmd.Parameters.AddWithValue("@Dat", item.DataOtgruzk);
                    cmd.Parameters.AddWithValue("@Kolichestvo", item.Kolichestvo);
                    cmd.Parameters.AddWithValue("@nameM", item.MaterialName);
                    cmd.Parameters.AddWithValue("@id", item.IDOtpusk);
                    
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
                    cmd.CommandText = "delete [Otpusk_so_sklada] where ID_otpusk_so_sklada=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
