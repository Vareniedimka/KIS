USE [AvtoK]
GO
/****** Object:  Trigger [dbo].[ZapOnotpDelete]    Script Date: 03/17/2014 09:56:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[ZapOnotpDelete] on [dbo].[Otpusk_so_sklada]
for delete
as
declare 
	@idz int,
	@idm int,
	@kolichestvo int,
	@kolichestvoNew int

select @idm=ID_materiala,@kolichestvo=kolichestvo
from deleted

update zapasi
set Kolichestvo+=@kolichestvo
where ID_materiala=@idm