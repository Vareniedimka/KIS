using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassLibrary;

namespace GLP
{
    public class MaterialPostavDao
    {
        private static MaterialPostav Load(SqlDataReader r)
        {
            //Создаём пустой объект
            MaterialPostav item = new MaterialPostav();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            item.IDMateriala = Convert.ToInt32(r["ID_materiala"]);
            item.IDPostavhik = Convert.ToInt32(r["ID_postavhika"]);
            
            item.MaterialName = Convert.ToString(r["nameM"]);
            item.PostavhikName = Convert.ToString(r["nameP"]);
                        
            return item;
        }

        public static IList<MaterialPostav> GetAll()
        {

            IList<MaterialPostav> items = new List<MaterialPostav>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = 
                        @"SELECT *,(
                            select Nazvanie_materiala
	                        from Materialy
	                        where mup.ID_materiala = ID_materiala
                        ) as nameM,
                        (
	                        select Naimenovanie
	                        from Postavhik
	                        where mup.ID_postavhika = ID_postavhika
                        ) as nameP
                        from Material_u_postavhikov mup";
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


        public static void Add(MaterialPostav item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        insert into Material_u_postavhikov (ID_materiala,ID_postavhika) values (
                        (
                            select ID_materiala
                            from Materialy
                            where Nazvanie_materiala=@nameM
                        ),
                        (
                            select ID_postavhika
                            from Postavhik
                            where Naimenovanie=@nameP
                        ));";
                    cmd.Parameters.AddWithValue("@nameP", item.PostavhikName);
                    cmd.Parameters.AddWithValue("@nameM", item.MaterialName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(MaterialPostav item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"update Material_u_postavhikov 
                        set
	                        ID_materiala=(
		                        select ID_materiala
		                        from Materialy
		                        where Nazvanie_materiala=@nameM
		                        ),
	                        ID_postavhika = (
		                        select ID_postavhika
		                        from Postavhik
		                        where Naimenovanie=@nameP
		                        )
                        where ID_materiala = @idM and ID_postavhika = @idP";

                    cmd.Parameters.AddWithValue("@nameM", item.MaterialName);
                    cmd.Parameters.AddWithValue("@nameP", item.PostavhikName);
                    cmd.Parameters.AddWithValue("@idM", item.IDMateriala);
                    cmd.Parameters.AddWithValue("@idP", item.IDPostavhik);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        public static void Delete(int idM, int idP)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "delete Material_u_postavhikov  where ID_materiala = @idM and ID_postavhika = @idP";
                    cmd.Parameters.AddWithValue("@idM", idM);
                    cmd.Parameters.AddWithValue("@idP", idP);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
