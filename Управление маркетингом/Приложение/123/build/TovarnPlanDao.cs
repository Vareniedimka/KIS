using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassLib;
namespace build
{
    public class TovarnPlanDao
    {
       
       private static TovarnPlan Load(SqlDataReader r)
        {
            //Создаём пустой объект
            TovarnPlan item = new TovarnPlan();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            item.ID_DCE = Convert.ToInt32(r["ID_DCE"]);
            item.NameIdDcE = Convert.ToString(r["NameIdDcE"]);
            item.KlientName = Convert.ToString(r["KlientName"]);
            item.ID_klienta = Convert.ToInt32(r["ID_klienta"]);
            
            item.ID_zakaza = Convert.ToInt32(r["ID_zakaza"]);
            item.Kolichestvo = Convert.ToInt32(r["Kolichestvo"]);
            item.Naimenovanie_produkta = Convert.ToString(r["Naimenovanie_produkta"]);
            item.Obhaya_stoimos = Convert.ToInt32(r["Obhaya_stoimos"]);
            item.Prioritet = Convert.ToString(r["Prioritet"]);
            item.Cena_detaly = Convert.ToInt32(r["Cena_detaly"]);
            item.Data_proizv = Convert.ToDateTime(r["Data_proizv"]);
            return item;
        }

        public static IList<TovarnPlan> GetAll()
        {

            IList<TovarnPlan> items = new List<TovarnPlan>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select tv.ID_DCE,tv.ID_klienta,tv.ID_prodazhi,tv.ID_zakaza,tv.ID_producta, tv.Naimenovanie_produkta,tv.Kolichestvo,tv.Cena_detaly,tv.Data_proizv,tv.Prioritet,tv.Obhaya_stoimos,  
(	select Name_klienta 
	from Klient k
		 where  k.ID_klienta=
				(select z.ID_klienta
				from Zakaz z where tv.ID_zakaza = z.ID_zakaza)) 
				as KlientName,
(select Naimenovanie
	 from DSE d 
		where d.ID_DCE =
				(select z.ID_DCE
				 from Zakaz z where z.ID_zakaza = tv.ID_zakaza))
				  as NameIdDcE
   from Tovarn_plan tv 
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



        public static void Add(TovarnPlan item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        Insert into 
Tovarn_plan (

		[ID_zakaza]
      ,[ID_klienta]
      ,[ID_DCE]
      ,[ID_prodazhi]
      ,[Naimenovanie_produkta]
      ,[Data_proizv]
      ,[ID_producta]
      ,[Kolichestvo]
      ,[Prioritet]
      ,[Cena_detaly]
      ,[Obhaya_stoimos]) 

values(@zakaz,(select ID_klienta from Klient k where k.Name_klienta = @name),(select ID_DCE from DSE d where d.Naimenovanie like  @nameDce),
1,@NaimenovaniePro,@Data_proizv,
1,@Kolichestvo,@Prioritet,@CenaDetal,@obshayaStoim)

                    ";
                    cmd.Parameters.AddWithValue("@NaimenovaniePro", item.Naimenovanie_produkta);
                    cmd.Parameters.AddWithValue("@CenaDetal", item.Cena_detaly);
                    cmd.Parameters.AddWithValue("@Prioritet", item.Prioritet);
                    cmd.Parameters.AddWithValue("@obshayaStoim", item.Obhaya_stoimos);
                    cmd.Parameters.AddWithValue("@Kolichestvo", item.Kolichestvo);
                    cmd.Parameters.AddWithValue("@Data_proizv", item.Data_proizv);
                    cmd.Parameters.AddWithValue("@nameDce", item.NameIdDcE);
                    cmd.Parameters.AddWithValue("@zakaz", item.ID_zakaza);
                    cmd.Parameters.AddWithValue("@name", item.KlientName);
                    
                    
                    cmd.Parameters.AddWithValue("@prodazh", item.ID_prodazhi);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(TovarnPlan item)
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"Update Tovarn_plan  set ID_klienta=(select k.ID_klienta from  Klient k where  k.Name_klienta=@Nameklienta),
						ID_DCE =(Select d.ID_DCE from DSE d where d.Naimenovanie =@NaimenovanieDet),
						Naimenovanie_produkta=@Naimenovanie_produkta,
						Cena_detaly=@Cena_detaly,
						Prioritet=@Prioritet,
						Obhaya_stoimos=@Obhaya_stoimos,
						Kolichestvo=@Kolichestvo,
						Data_proizv =@Data_proizv)
						where ID_plana=@ID_plana";

                    cmd.Parameters.AddWithValue("@Naimenovanie_produkta", item.Naimenovanie_produkta);
                    cmd.Parameters.AddWithValue("@Cena_detaly", item.Cena_detaly);
                    cmd.Parameters.AddWithValue("@Prioritet", item.Prioritet);
                    cmd.Parameters.AddWithValue("@Obhaya_stoimos", item.Obhaya_stoimos);
                    cmd.Parameters.AddWithValue("@Kolichestvo", item.Kolichestvo);
                    cmd.Parameters.AddWithValue("@Data_proizv", item.Data_proizv);
                    cmd.Parameters.AddWithValue("@Nameklienta", item.KlientName);
                    cmd.Parameters.AddWithValue("@NaimenovanieDet", item.NameIdDcE);
                    cmd.Parameters.AddWithValue("@ID_plana", item.ID_plana);
                    cmd.ExecuteNonQuery();

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
                    cmd.CommandText = "Delete Tovarn_plan where ID_plana=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
