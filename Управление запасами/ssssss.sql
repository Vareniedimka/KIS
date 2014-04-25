create procedure rasKof 
@kolichestvo int as
begin
select  (select Nazvanie_materiala from dbo.Materialy m where d.ID_materiala=m.ID_materiala) as [Материал],p.Kolichestvo*@kolichestvo
from dse d join Polnay_primen p on p.DSE_chto=d.ID_DCE
where Pokupnoe_izd=1
end