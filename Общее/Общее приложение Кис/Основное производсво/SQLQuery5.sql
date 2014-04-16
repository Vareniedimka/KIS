Create trigger [Q] on [dbo].[Meshcex_plan]
for insert, update as
declare @id int, @n varchar(100);
select @id=ID_DCE
from inserted
begin
select @n=Naimenovanie from DSE d where ID_DCE = @id

update Meshcex_plan 
set Naimenovanie_det=@n 
where @id=ID_DCE
end
go