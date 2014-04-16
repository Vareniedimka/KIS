Create trigger [V] on [dbo].[Operaciy_SZ]
for insert, update as
declare @id int, @ts int, @tpz int;
select @id=ID_marshrut
from inserted
begin
select @ts=Time_schtuchn, @tpz=TimePZ from Marsrut_karta o where ID_marshrut = @id

update Operaciy_SZ 
set Time_schtucthn=@ts, TimePZ=@tpz 
where @id=ID_marshrut
end
go
