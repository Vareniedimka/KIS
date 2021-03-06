USE [AvtoK]
GO
/****** Object:  Trigger [dbo].[addZapas_INSERT]    Script Date: 03/17/2014 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[addZapas_INSERT] on [dbo].[Zakazi]
for insert
as
declare 
	@idz int,
	@idm int,
	@statusNew varchar(20),
	@kolichestvo int

select  @idz=ID_zakaza,@idm=ID_materiala, @statusNew=[Status],@kolichestvo=kolichestvo
from inserted

if (@statusNew='Выполнен')
begin
	update zapasi
	set Kolichestvo+=@kolichestvo
	where ID_materiala=@idm
end