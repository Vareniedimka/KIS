USE [AvtoK]
GO
/****** Object:  Trigger [dbo].[minusZapasOnotpuskInsert]    Script Date: 03/17/2014 09:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[minusZapasOnotpuskInsert] on [dbo].[Otpusk_so_sklada]
for insert
as
declare 
	@idz int,
	@idm int,
	@statusNew varchar(20),
	@statusOld varchar(20),
	@kolichestvo int

select @idm=ID_materiala,@kolichestvo=kolichestvo
from inserted
update zapasi
set Kolichestvo-=@kolichestvo
where ID_materiala=@idm
