USE [AvtoK]
GO
/****** Object:  Trigger [dbo].[addZapasplusonDelete]    Script Date: 03/17/2014 09:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[addZapasplusonDelete] on [dbo].[Zakazi]
for delete
as
declare 
	@idz int,
	@idm int,
	@statusNew varchar(20),
	@statusOld varchar(20),
	@kolichestvo int

select @idm=ID_materiala,@kolichestvo=kolichestvo
from deleted

update zapasi
set Kolichestvo-=@kolichestvo
where ID_materiala=@idm
