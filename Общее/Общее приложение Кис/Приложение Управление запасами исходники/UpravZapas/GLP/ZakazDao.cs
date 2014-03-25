using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassLibrary;

namespace GLP
{
    public class ZakazDao
    {
        private static Zakaz Load(SqlDataReader r)
        {
            //Создаём пустой объект
            Zakaz item = new Zakaz();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            item.DataOform = Convert.ToDateTime(r["Data_oformleniya"]);
            if (r["data_vipolneniy"] != DBNull.Value)
            {
                item.DataVipolneni = Convert.ToDateTime(r["data_vipolneniy"]);
            }
            item.IDZakaza = Convert.ToInt32(r["ID_zakaza"]);
            item.IDMateriala = Convert.ToInt32(r["ID_materiala"]);
            item.MaterialName = Convert.ToString(r["nameM"]);
            item.Kolichestvo = Convert.ToInt32(r["Kolichestvo"]);
            item.Stoimost = Convert.ToDouble(r["Stoimost"]);
            item.Status = Convert.ToString(r["Status"]);
            item.IDPostavhika = Convert.ToInt32(r["ID_postavhika"]);
            item.PostavhikName = Convert.ToString(r["nameP"]);
            
            return item;
        }

        public static IList<Zakaz> GetAll()
        {

            IList<Zakaz> items = new List<Zakaz>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @" SELECT *,(
                            select Nazvanie_materiala
	                        from Materialy
	                        where mup.ID_materiala = ID_materiala
                        ) as nameM,
                        (
	                        select Naimenovanie
	                        from Postavhik
	                        where mup.ID_postavhika = ID_postavhika
                        ) as nameP
                        from Zakazi mup
                    ";
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



        public static void Add(Zakaz item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [Zakazi]
                               ([ID_materiala]
                               ,[Kolichestvo]
                               ,[Data_oformleniya]
                               ,[Status]
                               ,[ID_postavhika]
                               ,[data_vipolneniy])
                         VALUES
                               ((
		                            select ID_materiala
		                            from Materialy
		                            where Nazvanie_materiala=@nameM
		                        )
                               ,@kol
                               ,@dof
                               ,@stat
                               ,(
		                            select ID_postavhika
		                            from Postavhik
		                            where Naimenovanie=@nameP
		                        )
                               ,@dvi)
                    ";
                    cmd.Parameters.AddWithValue("@kol", item.Kolichestvo);
                    cmd.Parameters.AddWithValue("@dof", item.DataOform);
                    cmd.Parameters.AddWithValue("@stat", item.Status);
                    if (item.DataVipolneni == null)
                    {
                        cmd.Parameters.AddWithValue("@dvi", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@dvi", item.DataVipolneni);
                    }
                    cmd.Parameters.AddWithValue("@nameM", item.MaterialName);
                    cmd.Parameters.AddWithValue("@nameP", item.PostavhikName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Zakaz item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE [Zakazi]
                           SET [ID_materiala] = (
		                            select ID_materiala
		                            from Materialy
		                            where Nazvanie_materiala=@nameM
		                        )
                              ,[Kolichestvo] = @kol
                              ,[Data_oformleniya] = @dof
                              ,[Status] = @stat
                              ,[ID_postavhika] = (
		                            select ID_postavhika
		                            from Postavhik
		                            where Naimenovanie=@nameP
		                        )
                              ,[data_vipolneniy] = @dvi
                        WHERE ID_zakaza=@id
                    ";
                    cmd.Parameters.AddWithValue("@kol", item.Kolichestvo);
                    cmd.Parameters.AddWithValue("@dof", item.DataOform);
                    cmd.Parameters.AddWithValue("@stat", item.Status);
                    if (item.DataVipolneni == null)
                    {
                        cmd.Parameters.AddWithValue("@dvi", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@dvi", item.DataVipolneni);
                    }
                    cmd.Parameters.AddWithValue("@nameM", item.MaterialName);
                    cmd.Parameters.AddWithValue("@nameP", item.PostavhikName);
                    cmd.Parameters.AddWithValue("@id", item.IDZakaza);
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
                    cmd.CommandText = "delete Zakazi where ID_zakaza=@ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
