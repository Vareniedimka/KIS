USE [AvtoK]
GO
/****** Object:  Trigger [dbo].[addZapasMinus]    Script Date: 03/17/2014 09:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[addZapasMinus] on [dbo].[Zakazi]
for update
as
declare 
	@idz int,
	@idm int,
	@statusNew varchar(20),
	@statusOld varchar(20),
	@kolichestvo int

select  @idz=ID_zakaza,@idm=ID_materiala, @statusNew=[Status]
from inserted
select @statusOld =[Status],@kolichestvo=kolichestvo
from deleted

if (@statusNew<>'Выполнен'and @statusOld='Выполнен')
begin
	update zapasi
	set Kolichestvo-=@kolichestvo
	where ID_materiala=@idm
end