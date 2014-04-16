using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClassBD;

namespace TPPDAO
{
    
    public class PolPrim
    {
        private static PolPrem Load(SqlDataReader reader)
        {
            PolPrem aa = new PolPrem();
            aa.DSEChto = Convert.ToInt32(reader["DSE_chto"]);
            aa.DSEKuda = Convert.ToInt32(reader["DSE_kuda"]);
            aa.Kolichestvo = Convert.ToInt32(reader["Kolichestvo"]);
            aa.Ichto = Convert.ToInt32(reader["izd_chto"]);
            aa.Ikuda = Convert.ToInt32(reader["izd_kuda"]);
            aa.name_chto = Convert.ToString(reader["name_chto"]);
            aa.name_kuda = Convert.ToString(reader["name_kuda"]);
            return aa;
        }

        public static IList<PolPrem> GetAll()
        {
            IList<PolPrem> dd = new List<PolPrem>();
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select *,(select Naimenovanie from DSE where ID_DCE = Polnay_primen.DSE_chto) as name_chto, (select Naimenovanie from DSE where ID_DCE = Polnay_primen.DSE_kuda) as name_kuda from Polnay_primen";
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
        /// <summary>
        /// Алгоритм разузлования
        /// </summary>
        /// <param name="aa"></param>
        /// <returns></returns>

        
        


        public void Update()
        {
            using (var conn = Connect.GetConnect())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    int n=0;
                    cmd.CommandText = "delete from Polnay_primen";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "delete from vt1";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "delete from vt2";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into vt1 (chto1,kuda1,kolvo1) select izd_chto,izd_kuda,Kolichestvo from Neposredstv_prim";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "exec while1";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "exec posled";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert Polnay_primen (DSE_chto,DSE_kuda,Kolichestvo,izd_chto,izd_kuda) select chto1,kuda1,kolvo1,'0','0' from vt1";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

/*
 create table vt1 (chto1 int, kuda1 int, kolvo1 int)
 create table vt2 (chto2 int, kuda2 int, kolvo2 int)
 create procedure while1
as
while((select COUNT(*) from vt1 where chto1 in (select kuda1 from vt1)) <> '0')
begin
	while ((select COUNT(*) from vt1 )<> '0')
	begin 
	select top 1 * from vt1;
	exec udal1;
	end;
	insert into vt1 (chto1,kuda1,kolvo1) select chto2,kuda2,kolvo2 from vt2;
	end */

/*create procedure udal1
as
declare @chto int, @kuda int,@kol int,@n int
set @chto = (select top 1 chto1 from vt1);
set @kuda = (select top 1 kuda1 from vt1);
set @kol= (select top 1 kolvo1 from vt1);
set @n= (select count(*) as nn from vt1 where @chto=chto1 and @kuda = kuda1);
if (select COUNT(*) from vt1 where chto1 = @kuda) <> 0
insert into vt2(chto2,kuda2,kolvo2) select  @chto, kuda1,kolvo1=kolvo1*@kol*@n from vt1 where chto1 = @kuda;
else insert into vt2 (chto2, kuda2,kolvo2) values (@chto ,@kuda,@kol)
delete vt1 where chto1 =@chto and kuda1 = @kuda and kolvo1 = @kol
*/

/* ALTER procedure [dbo].[posled]
as
delete from vt2;
declare @chto int, @kuda int,@kol int,@n int
while (select top 1 chto1 from vt1 group by chto1,kuda1 having COUNT(*)>1) is not null
begin
set @chto = (select top 1 chto1 from vt1 group by chto1,kuda1 having COUNT(*)>1);
set @kuda = (select top 1 kuda1 from vt1 group by chto1,kuda1 having COUNT(*)>1);
set @n = (select SUM(kolvo1) from vt1 where @chto = chto1 and @kuda = kuda1); 
delete from vt1 where (chto1 = @chto) and (kuda1=@kuda);
insert into vt1(chto1,kuda1,kolvo1) values (@chto,@kuda,@n);
end*/