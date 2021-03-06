USE [AvtoK]
GO
/****** Object:  Trigger [dbo].[minZapOnotpUpdat]    Script Date: 03/17/2014 09:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[minZapOnotpUpdat] on [dbo].[Otpusk_so_sklada]
for update
as
declare 
	@idz int,
	@idm int,
	@statusNew varchar(20),
	@statusOld varchar(20),
	@kolichestvoold int,
	@kolichestvoNew int

select @idm=ID_materiala,@kolichestvoNew=kolichestvo
from inserted

select @kolichestvoOld=kolichestvo
from deleted

update zapasi
set Kolichestvo+=@kolichestvoOld-@kolichestvoNew
where ID_materiala=@idm